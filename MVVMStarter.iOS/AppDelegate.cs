using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace MVVMStarter.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<Core.App, App>, Core.App, App>
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            ConfigureApplicationTheming();

            return base.FinishedLaunching(app, options);
        }

        private void ConfigureApplicationTheming()
        {            
            UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(21, 144, 163);
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.Gray }, UIControlState.Normal);
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.FromRGB(21, 144, 163) }, UIControlState.Selected);
            // Other options
            //UIProgressView.Appearance.ProgressTintColor = UIColor.FromRGB(21, 144, 163);
            //UINavigationBar.Appearance.TintColor = UIColor.White;
            //UINavigationBar.Appearance.BarTintColor = UtilsGlobal.PRIMARY.ToUIColor();
            //UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes { ForegroundColor = UIColor.White };
            //UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White }, UIControlState.Normal);
            //UITabBar.Appearance.TintColor = UIColor.FromRGB(21, 144, 163);
            //UITabBar.Appearance.BarTintColor = UIColor.White;
        }
    }
}
