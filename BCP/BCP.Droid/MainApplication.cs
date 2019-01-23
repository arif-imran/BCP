//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="MainApplication.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   MainApplication.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Droid
{
    using System;
    using Android.App;
    using Android.OS;
    using Android.Runtime;
    using Plugin.CurrentActivity;

    // You can specify additional application information in this attribute

    /// <summary>
    /// Main application.
    /// </summary>
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Droid.MainApplication"/> class.
        /// </summary>
        /// <param name="handle">The Handle.</param>
        /// <param name="transer">Transer Object.</param>
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        /// <summary>
        /// Ons the create.
        /// </summary>
        public override void OnCreate()
        {
            base.OnCreate();
            this.RegisterActivityLifecycleCallbacks(this);

            // A great place to initialize Xamarin.Insights and Dependency Services!
        }

        /// <summary>
        /// Ons the terminate.
        /// </summary>
        public override void OnTerminate()
        {
            base.OnTerminate();
            this.UnregisterActivityLifecycleCallbacks(this);
        }

        /// <summary>
        /// Ons the activity created.
        /// </summary>
        /// <param name="activity">Activity Object.</param>
        /// <param name="savedInstanceState">Saved instance state.</param>
        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        /// <summary>
        /// Ons the activity destroyed.
        /// </summary>
        /// <param name="activity">Activity Object.</param>
        public void OnActivityDestroyed(Activity activity)
        {
        }

        /// <summary>
        /// Ons the activity paused.
        /// </summary>
        /// <param name="activity">Activity Object.</param>
        public void OnActivityPaused(Activity activity)
        {
        }

        /// <summary>
        /// Ons the activity resumed.
        /// </summary>
        /// <param name="activity">Activity Object.</param>
        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        /// <summary>
        /// Ons the state of the activity save instance.
        /// </summary>
        /// <param name="activity">Activity Object.</param>
        /// <param name="outState">Out state.</param>
        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        /// <summary>
        /// Ons the activity started.
        /// </summary>
        /// <param name="activity">Activity Object.</param>
        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        /// <summary>
        /// Ons the activity stopped.
        /// </summary>
        /// <param name="activity">Activity Object.</param>
        public void OnActivityStopped(Activity activity)
        {
        }
    }
}