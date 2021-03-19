#import "TinyViewController.h"
#import "UnityTinyIOS.h"
#import "iPhoneInputImpl.h"
#import <QuartzCore/CAEAGLLayer.h>

#if __IPHONE_8_0 && !TARGET_IPHONE_SIMULATOR
#import <Metal/Metal.h>
#import <QuartzCore/CAMetalLayer.h>
#define HAS_METAL_SDK
#endif

#ifdef HAS_METAL_SDK
static id<MTLDevice> m_device = NULL;
#else
static void* m_device = NULL;
#endif

static void* m_nwh = NULL;

static UIInterfaceOrientationMask m_orientationMask;
extern UIInterfaceOrientationMask m_interfaceOrientationMask;

static BOOL appStarted = NO;

extern bool waitForManagedDebugger;

@implementation TinyView

@synthesize m_visible;
@synthesize m_preventRemoveFromSuperview;

+ (Class)layerClass
{
#ifdef HAS_METAL_SDK
    Class metalClass = NSClassFromString(@"CAMetalLayer");    // is metal runtime sdk available
    if (metalClass != nil)
    {
        m_device = MTLCreateSystemDefaultDevice(); // is metal supported on this device (is there a better way to do this - without creating device ?)
        if (m_device)
        {
            // TODO: get rid of OpenGLES for iOS when problem with Metal on A7/A8 based devices is fixed
            if ([m_device supportsFeatureSet:MTLFeatureSet_iOS_GPUFamily3_v1])
                return metalClass;
        }
    }
#endif

    return [CAEAGLLayer class];
}

- (id)initWithFrame:(CGRect)rect
{
    self = [super initWithFrame:rect];
    if (nil != self)
    {
        m_nwh = (__bridge void*)self.layer;
        m_orientationMask = UIInterfaceOrientationMaskAll;
        // do we need to pass m_device to PlatformData.context ?
        InputInit(self);
    }
    m_preventRemoveFromSuperview = NO;
    m_updateWindow = NO;
    return self;
}

- (void)removeFromSuperview
{
    if (!m_preventRemoveFromSuperview)
    {
        [super removeFromSuperview];
    }
    m_preventRemoveFromSuperview = NO;
    m_visible = NO;
}

- (void)layoutSubviews
{
    CancelTouches();
    m_updateWindow = YES;
}

- (void)setResolutionWidth: (int)width Height:(int)height
{
    if ([self.layer isKindOfClass:[CAMetalLayer class]])
    {
        CAMetalLayer* layer = (CAMetalLayer*)self.layer;
        layer.drawableSize = CGSizeMake(width, height);
    }
    else // OpenGLES
    {
        // TODO: get rid of OpenGLES for iOS when problem with Metal on A7/A8 based devices is fixed
        int frameW = (int)self.frame.size.width;
        int frameH = (int)self.frame.size.height;
        self.layer.contentsScale = MAX((width - 1) / frameW, (height - 1) / frameH) + 1.0f;
        float rectX = (float)width / frameW / self.layer.contentsScale;
        float rectY = (float)height / frameH / self.layer.contentsScale;
        self.layer.contentsRect = CGRectMake(0, 1.0f - rectY, rectX, rectY);
    }
}

- (void)start
{
    if (nil == m_displayLink)
    {
        m_displayLink = [self.window.screen displayLinkWithTarget:self selector:@selector(renderFrame:)];
        [m_displayLink addToRunLoop:[NSRunLoop currentRunLoop] forMode:NSRunLoopCommonModes]; // or NSDefaultRunLoopMode ?
    }
}

- (void)stop
{
    if (nil != m_displayLink)
    {
        [m_displayLink invalidate];
        m_displayLink = nil;
    }
}

- (void)updateWindowSize
{
    float scale = [[UIScreen mainScreen] scale];
    uint32_t frameW = (uint32_t)(scale * self.frame.size.width);
    uint32_t frameH = (uint32_t)(scale * self.frame.size.height);
    uint32_t orientation = 0;
#ifdef __IPHONE_13_0
    if (@available(iOS 13, *))
    {
        orientation = (uint32_t)[(UIWindowScene*)[[UIApplication sharedApplication] connectedScenes].allObjects.firstObject interfaceOrientation];
    }
    else
#endif
    {
        orientation = (uint32_t)[[UIApplication sharedApplication] statusBarOrientation];
    }
    init_window_ios(m_nwh, frameW, frameH, orientation);
}

- (void)renderFrame:(CADisplayLink *)sender
{
    if (waitForManagedDebugger)
    {
        return;
    }
    if (m_visible && m_updateWindow)
    {
        [self updateWindowSize];
        m_updateWindow = NO;
    }

    //sender.timestamp is in CACurrentMediaTime() 'coordinate space'.

    InputProcess();
    step_ios(sender.timestamp);
}
@end

@interface TinyViewController()
@end

@implementation TinyViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
}

- (void)viewWillDisappear:(BOOL)animated
{
    [super viewWillDisappear:animated];
    if (self.view != nil && [self.view class] == [TinyView class])
    {
        ((TinyView*)self.view).m_visible = NO;
    }
}

- (void)viewWillAppear:(BOOL)animated
{
    [super viewWillAppear:animated];
    if (self.view != nil && [self.view class] == [TinyView class])
    {
        ((TinyView*)self.view).m_visible = YES;
    }
}

- (void)viewDidAppear:(BOOL) animated
{
    [super viewDidAppear:animated];
    if (!appStarted)
    {
        startapp_ios();
        appStarted = YES;
    }
}

- (BOOL)shouldAutorotate
{
    return YES;
}

- (UIInterfaceOrientationMask)supportedInterfaceOrientations
{
    return m_orientationMask;
}

- (void)viewWillTransitionToSize:(CGSize)size withTransitionCoordinator:(id<UIViewControllerTransitionCoordinator>)coordinator
{
    [coordinator animateAlongsideTransition: nil completion:^(id<UIViewControllerTransitionCoordinatorContext> context)
    {
        [self.view setNeedsLayout];
    }];
    [super viewWillTransitionToSize: size withTransitionCoordinator: coordinator];
}

- (BOOL)prefersStatusBarHidden {
    return YES;
}

- (void)touchesBegan:(NSSet<UITouch *> *)touches withEvent:(UIEvent *)event
{
    ProcessTouchEvents(self.view, touches, [event allTouches]);
}

- (void)touchesMoved:(NSSet<UITouch *> *)touches withEvent:(UIEvent *)event
{
    ProcessTouchEvents(self.view, touches, [event allTouches]);
}

- (void)touchesEnded:(NSSet<UITouch *> *)touches withEvent:(UIEvent *)event
{
    ProcessTouchEvents(self.view, touches, [event allTouches]);
}

- (void)touchesCancelled:(NSSet<UITouch *> *)touches withEvent:(UIEvent *)event
{
    ProcessTouchEvents(self.view, touches, [event allTouches]);
}

@end

BOOL portraitUpsideDownAllowed()
{
    if (@available(iOS 11, *))
    {
        // Portrait upside down is not allowed for iPhones without physical Home button
        // For such iPhones safe area from the bottom is not 0  
        return [[UIDevice currentDevice] userInterfaceIdiom] != UIUserInterfaceIdiomPhone ||
               [[[UIApplication sharedApplication] keyWindow] safeAreaInsets].bottom == 0;
    }
    return YES;
}

bool setOrientationMask(int orientation)
{
    if ((UIInterfaceOrientationMask)orientation == UIInterfaceOrientationMaskPortraitUpsideDown && !portraitUpsideDownAllowed())
    {
        return false;
    }
    if ((m_interfaceOrientationMask & orientation) == 0)
    {
        return false;
    }
    m_orientationMask = (UIInterfaceOrientationMask)orientation;
    return true;
}


