//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="SplashScreen.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   SplashScreen.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;

    /// <summary>
    /// Splash screen.
    /// </summary>
    [Activity(Icon = "@drawable/icon", Theme = "@style/SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity
    {
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.StartActivity(typeof(MainActivity));
            this.Finish();

            // Disable activity slide-in animation
            this.OverridePendingTransition(0, 0);
        }
    }
}
