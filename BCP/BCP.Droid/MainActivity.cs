//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="MainActivity.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   MainActivity.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Droid
{
    using System.Threading.Tasks;
    using AI.XamarinSDK;
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using BCP.Common;
    using BCP.Forms;
    using Plugin.Permissions;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// Main activity.
    /// </summary>
    [Activity(Label = "BCP.Forms", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, Theme = "@style/AppTheme")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// Ons the request permissions result.
        /// </summary>
        /// <param name="requestCode">Request code.</param>
        /// <param name="permissions">Array of Permissions.</param>
        /// <param name="grantResults">Grant results.</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Shows the alert.
        /// </summary>
        /// <returns>The alert.</returns>
        /// <param name="title">The Title.</param>
        /// <param name="msg">The Message.</param>
        public async Task ShowAlert(string title, string msg)
        {
            this.RunOnUiThread(() =>
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(Xamarin.Forms.Forms.Context);
                AlertDialog alert = dialog.Create();
                alert.SetTitle(title);
                alert.SetMessage(msg);
                alert.SetButton("OK", (c, ev) => { });
                alert.Show();
            });
        }

        /// <summary>
        /// Ons the start.
        /// </summary>
        protected override void OnStart()
        {
            CrossApplicationInsights.Current.Setup(SharedConfig.ApplicationInsightsId);
            CrossApplicationInsights.Current.Start();
            CrossApplicationInsights.Current.SetAutoPageViewTrackingDisabled(true);
            base.OnStart();
        }

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="bundle">The Bundle.</param>
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.FormsMaps.Init(this, bundle);

            this.LoadApplication(new App(new AndroidInitializer()));
        }
    }
}
