//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AppLinker.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AppLinker.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.IOS.Services
{
    using System;
    using System.Diagnostics;
    using BCP.Forms.Services;
    using Foundation;
    using UIKit;

    /// <summary>
    /// App linker.
    /// </summary>
    public class AppLinker : IAppLinker
    {
        /// <summary>
        /// Opens the link.
        /// </summary>
        /// <param name="uRL">URL Parameter.</param>
        /// <param name="fallBackURL">Fall back URL.</param>
        public void OpenLink(string uRL, string fallBackURL)
        {
            try
            {
                if (!string.IsNullOrEmpty(uRL))
                {
                    bool isOpened = UIApplication.SharedApplication.OpenUrl(new NSUrl(uRL));
                    if (isOpened == false && UIApplication.SharedApplication.CanOpenUrl(new NSUrl(uRL)))
                    {
                        UIApplication.SharedApplication.OpenUrl(new NSUrl(uRL));
                    }
                    else
                    {
                        UIApplication.SharedApplication.OpenUrl(new NSUrl(fallBackURL));
                    }
                }
                else
                {
                    UIApplication.SharedApplication.OpenUrl(new NSUrl(fallBackURL));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot open url: {0}, Error: {1}", uRL, ex.Message);
            }
        }
    }
}
