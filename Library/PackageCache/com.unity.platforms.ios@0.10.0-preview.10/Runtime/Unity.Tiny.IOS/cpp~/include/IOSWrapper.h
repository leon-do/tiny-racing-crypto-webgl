#import <UIKit/UIKit.h>

extern "C" UIViewController* get_viewcontroller() __attribute__ ((deprecated));

extern "C" UIViewController* Unity_Get_ViewController();
