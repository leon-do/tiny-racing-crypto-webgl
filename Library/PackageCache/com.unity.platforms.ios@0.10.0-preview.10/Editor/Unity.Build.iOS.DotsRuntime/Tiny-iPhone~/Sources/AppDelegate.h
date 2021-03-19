#import <UIKit/UIKit.h>
#import "TinyViewController.h"

@interface AppDelegate : UIResponder <UIApplicationDelegate>

@property (strong, nonatomic) UIWindow *m_window;
@property (strong, nonatomic) TinyView *m_view;
@property (strong, nonatomic) TinyViewController *m_viewController;
@property (strong, nonatomic) UIViewController *m_splashController;
@property (nonatomic, readonly) BOOL m_tinyStarted;
@property (nonatomic, readonly) BOOL m_tinyPaused;

@end

