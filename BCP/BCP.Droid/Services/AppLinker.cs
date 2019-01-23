//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AppLinker.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AppLinker.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Droid.Services
{
    using System;
    using Android.App;
    using Android.Content;
    using BCP.Forms.Services;

    /// <summary>
    /// App linker.
    /// </summary>
    [Activity(Label = "OpenAppAndroid")]
    public class AppLinker : Activity, IAppLinker
    {
       /// <summary>
       /// Opens the link.
       /// </summary>
       /// <param name="url">The URL.</param>
       /// <param name="fallBackURL">Fall back URL.</param>
        public void OpenLink(string url, string fallBackURL)
        {
            try
            {
                this.OpenUrlAsIntent(url);
            }
            catch (ActivityNotFoundException)
            {
                this.OpenUrlAsIntent(fallBackURL);
            }
        }

        /// <summary>
        /// Opens the URL as an intent, which will launch the appropriate app if it is installed.
        /// </summary>
        /// <param name="url">URL String.</param>
        private void OpenUrlAsIntent(string url)
        {
            var uri = Android.Net.Uri.Parse(url);
            var intent = new Intent(Intent.ActionView, uri);
            intent.SetFlags(ActivityFlags.NewTask);
            Xamarin.Forms.Forms.Context.StartActivity(intent);
        }

        /// <summary>
        /// Opens the URL in the Play Store. Only works if it is a package name.
        /// </summary>
        /// <param name="url">URL. String</param>
        private void OpenUrlInStore(string url)
        {
            var intent = new Intent(Intent.ActionView);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.SetData(Android.Net.Uri.Parse("market://details?id=" + url));
            Xamarin.Forms.Forms.Context.StartActivity(intent);
        }
    }
}
