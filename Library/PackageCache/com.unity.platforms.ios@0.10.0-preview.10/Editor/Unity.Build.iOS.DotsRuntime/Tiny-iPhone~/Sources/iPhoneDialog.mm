#import "AppDelegate.h"
#import <Foundation/NSObject.h>
#import <MediaPlayer/MediaPlayer.h>
#import <UIKit/UIViewController.h>

typedef void(*BroadcastFunction)();
extern bool waitForManagedDebugger;

void ShowDebuggerAttachDialogImpl(const char* message, BroadcastFunction broadcast)
{
    __block int result = -1;

    UIAlertController * alert = [UIAlertController
                                 alertControllerWithTitle: @"Debug"
                                 message: [NSString stringWithUTF8String: message]
                                 preferredStyle: UIAlertControllerStyleAlert];

    UIAlertAction* button0 =    [UIAlertAction
                                 actionWithTitle: @"Ok"
                                 style: UIAlertActionStyleDefault
                                 handler:^(UIAlertAction * action) {
                                     result = 0;
                                 }];


    [alert addAction: button0];

    UIViewController *vc = [((AppDelegate*)[[UIApplication sharedApplication] delegate]).m_window rootViewController];

    [vc presentViewController: alert animated: NO completion: nil];
    while (result == -1)
    {
        if (broadcast)
            broadcast();
        [[NSRunLoop currentRunLoop] runUntilDate: [NSDate dateWithTimeIntervalSinceNow: 0.1f]];
    }

    waitForManagedDebugger = false;
}
