#pragma once

#import <UIKit/UIKit.h>

void InputInit(UIView* view);
void InputShutdown();
void InputProcess();
void CancelTouches();
void ProcessTouchEvents(UIView* view, NSSet* touches, NSSet* allTouches);
