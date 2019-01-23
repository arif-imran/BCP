//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CustomWebView.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CustomWebView.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Controls
{
    using System;
    using System.Net;
    using Xamarin.Forms;

    /// <summary>
    /// Custom web view.
    /// </summary>
    public class CustomWebView : WebView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Controls.CustomWebView"/> class.
        /// </summary>
        public CustomWebView()
        {
            this.Navigating += (object sender, WebNavigatingEventArgs e) =>             {                 if (e.Url.StartsWith("http://", StringComparison.CurrentCulture) || e.Url.StartsWith("https://", StringComparison.CurrentCulture) || e.Url.StartsWith("mailto:", StringComparison.CurrentCulture) || e.Url.StartsWith("tel:", StringComparison.CurrentCulture))                 {                     Device.OpenUri(new Uri(WebUtility.HtmlDecode(e.Url)));                     e.Cancel = true;                 }             };
        }
    }
}
