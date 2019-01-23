//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AppDelegate.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AppDelegate.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.IOS
{
    using AI.XamarinSDK;
    using BCP.Common;
    using BCP.Forms;
    using Foundation;
    using Grosvenor.Forms.MobileIron.iOS;
    using ImageCircle.Forms.Plugin.iOS;
    using UIKit;

    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.

    /// <summary>
    /// App delegate.
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.

        /// <summary>
        /// Finisheds the launching.
        /// </summary>
        /// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
        /// <param name="app">App Parameter.</param>
        /// <param name="options">Options Parameter.</param>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            bool isFake = true;
#if MOBILE_IRON
            isFake = false;
#endif
            GrosvenorAppConnect.Initialise(isFake);

            global::Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();
            Xamarin.FormsMaps.Init();
            Grosvenor.Forms.iOS.GestureEffects.Effects.Init();

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

            this.SetupAnalytics();

            this.LoadApplication(new App(new IOSInitializer()));

            GrosvenorAppConnect.StartWithLaunchOptions(options);
            return base.FinishedLaunching(app, options);
        }

        /// <summary>
        /// Setups the analytics.
        /// </summary>
        private void SetupAnalytics()
        {
            CrossApplicationInsights.Current.Setup(SharedConfig.ApplicationInsightsId);
            CrossApplicationInsights.Current.Start();
            CrossApplicationInsights.Current.SetAutoPageViewTrackingDisabled(true);
        }
    }
}
