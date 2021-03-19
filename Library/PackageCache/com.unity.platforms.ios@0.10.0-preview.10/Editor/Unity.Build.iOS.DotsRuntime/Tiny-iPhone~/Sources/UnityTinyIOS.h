// methods exported by Unity,Tiny.IOS package

extern "C" {
void init_window_ios(void *nwh, int width, int height, int orientation);
void set_viewcontroller_ios(UIViewController* viewController);
void step_ios(double timestamp);
void pauseapp_ios(int paused);
void destroyapp_ios(void);
void startapp_ios(void);
void touchevent_ios(int id, int action, int xpos, int ypos);
void screenSizeChanged_ios(int width, int height);
void deviceOrientationChanged_ios(int orientation);
}
