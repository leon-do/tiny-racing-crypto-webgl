#include <cassert>
#include <csignal>
#import "AppDelegate.h"
#import "UnityTinyIOS.h"

UIInterfaceOrientationMask m_interfaceOrientationMask;

@implementation AppDelegate

@synthesize m_window;
@synthesize m_view;
@synthesize m_viewController;
@synthesize m_splashController;
@synthesize m_tinyStarted;
@synthesize m_tinyPaused;

- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
{
    // iOS terminates open sockets when an application enters background mode.
    // The next write to any of such socket causes SIGPIPE signal being raised,
    // even if the request has been done from scripting side. This disables the signal.
    std::signal(SIGPIPE, SIG_IGN);
    // setting path to read resources
    NSString *placeholderFile = @"placeholder";
    NSString *path = [[NSBundle mainBundle] pathForResource:placeholderFile ofType:@""];
    chdir([path substringToIndex: (path.length - placeholderFile.length)].UTF8String);

    CGRect rect = [[UIScreen mainScreen] bounds];
    m_window = [[UIWindow alloc] initWithFrame: rect];
    m_tinyStarted = NO;
    m_tinyPaused = NO;

    [self showSplashScreen];

    m_interfaceOrientationMask = [application supportedInterfaceOrientationsForWindow:m_window];

    return YES;
}

- (void)showSplashScreen
{
    NSString* launchScreen = [[NSBundle mainBundle].infoDictionary[@"UILaunchStoryboardName"] stringByDeletingPathExtension];
    assert(launchScreen != nil && "UILaunchStoryboardName key is missing from info.plist");
    const BOOL hasStoryboard = launchScreen != nil && [[NSBundle mainBundle] pathForResource: launchScreen ofType: @"storyboardc"] != nil;
    assert(hasStoryboard && "Launch storyboard not found in resources");
    if (hasStoryboard)
    {
        UIStoryboard *storyboard = [UIStoryboard storyboardWithName: launchScreen bundle: [NSBundle mainBundle]];

        m_splashController = [storyboard instantiateInitialViewController];
        [m_window setRootViewController: m_splashController];
    }
    else
    {
        // should never happen
        [self startTiny];
    }

    [m_window makeKeyAndVisible];
}

- (void)initViewController
{
    m_viewController = [[TinyViewController alloc] init];
    [m_viewController setView: m_view];
    set_viewcontroller_ios(m_viewController);
}

- (void)startTiny
{
    m_view = [[TinyView alloc] initWithFrame: m_window.frame];
    float scaleFactor = [[UIScreen mainScreen] scale];
    [m_view setContentScaleFactor: scaleFactor];

    [self initViewController];
    [m_window setRootViewController: m_viewController];
    m_splashController = nil;

    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(deviceOrientationChanged:) name:UIDeviceOrientationDidChangeNotification object:[UIDevice currentDevice]];
    m_tinyStarted = YES;
    
    if (!m_tinyPaused)
    {
        [m_view start];
    }
}

-(void)reInitViewController
{
    UIViewController* prevController = m_viewController;
    m_view.m_preventRemoveFromSuperview = YES;
    [m_viewController setView: nil];
    [self initViewController];
    
    [UIView transitionWithView:self.m_window duration:0.15 options:UIViewAnimationOptionTransitionNone animations:^{
            [self.m_window setRootViewController:self.m_viewController];
            [self.m_window makeKeyAndVisible];
    } completion:^(BOOL){
        [prevController dismissViewControllerAnimated:NO completion:nil];
        [self.m_view setNeedsLayout];
    }];
}

- (void)applicationWillResignActive:(UIApplication *)application
{
    m_tinyPaused = YES;
    if (m_tinyStarted)
    {
        [m_view stop];
        pauseapp_ios(1);
    }
}

- (void)applicationDidEnterBackground:(UIApplication *)application
{
}

- (void)applicationWillEnterForeground:(UIApplication *)application
{
}

- (void)applicationDidBecomeActive:(UIApplication *)application
{
    m_tinyPaused = NO;
    if (m_tinyStarted)
    {
        pauseapp_ios(0);
        [m_view start];
    }
    else
    {
        [self performSelector: @selector(startTiny) withObject: nil afterDelay: 1];
    }
}


- (void)applicationWillTerminate:(UIApplication *)application
{
    if (m_tinyStarted)
    {
        destroyapp_ios();
        m_tinyStarted = NO;
    }
}

- (void)deviceOrientationChanged:(NSNotification *)note
{
    if (m_tinyStarted)
    {
        deviceOrientationChanged_ios((uint32_t)[[note object] orientation]);
    }
}

@end

void setResolution(int width, int height)
{
    [((AppDelegate*)[[UIApplication sharedApplication] delegate]).m_view setResolutionWidth: width Height: height];
}

void rotateToDeviceOrientation()
{
    [UIViewController attemptRotationToDeviceOrientation];
}

void rotateToAllowedOrientation()
{
    [((AppDelegate*)[[UIApplication sharedApplication] delegate]) reInitViewController];
}
