#include <Unity/Runtime.h>

#import <QuartzCore/CAMetalLayer.h>
#import <Metal/Metal.h>
#import <MetalKit/MetalKit.h>
#import <Foundation/Foundation.h>

#if UNITY_MACOSX
#   include <Cocoa/Cocoa.h>
#endif

#if UNITY_IOS
#	import <UIKit/UIKit.h>
#endif

DOTS_EXPORT(bool)
create_metal_layer_for_window(NSWindow* nsWindow, CAMetalLayer** layerOut)
{
    NSView* contentView = [nsWindow contentView];

    CAMetalLayer* metalLayer = nil;
	CALayer* layer = contentView.layer;
    if (NULL != layer && [layer isKindOfClass:NSClassFromString(@"CAMetalLayer")])
    {
        metalLayer = (CAMetalLayer*)layer;
    }
    else
    {
        [contentView setWantsLayer:YES];
        metalLayer = [CAMetalLayer layer];
        [contentView setLayer:metalLayer];
    }

    *layerOut = metalLayer;
    return true;
}

DOTS_EXPORT(void)
release_nsobject(NSObject *obj)
{
    [obj release];
}