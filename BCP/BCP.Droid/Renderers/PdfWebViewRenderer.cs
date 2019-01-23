//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="PdfWebViewRenderer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   PdfWebViewRenderer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

[assembly: Xamarin.Forms.ExportRenderer(typeof(BCP.Forms.Controls.PdfWebView), typeof(BCP.Droid.Renderers.PdfWebViewRenderer))]

namespace BCP.Droid.Renderers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Reactive.Linq;
    using Akavache;
    using BCP.Droid.Renderers;
    using BCP.Forms.Controls;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// Pdf web view renderer.
    /// </summary>
    public class PdfWebViewRenderer : WebViewRenderer
    {
        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">PropertyChangedEventArgs E.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.Settings.AllowUniversalAccessFromFileURLs = true;

                var customWebView = Element as PdfWebView;
                if (customWebView != null)
                {
                    this.LoadUri(customWebView);
                }
            }
        }

        /// <summary>
        /// Ons the element property changed.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">PropertyChangedEventArgs E.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Uri")
            {
                PdfWebView customWebView = sender as PdfWebView;
                this.LoadUri(customWebView);
            }
        }

        /// <summary>
        /// Loads the URI.
        /// </summary>
        /// <param name="customWebView">Custom web view.</param>
        private void LoadUri(PdfWebView customWebView)
        {
            if (customWebView.Uri != null)
            {
                var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "temp1.pdf");
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                File.WriteAllBytes(filename, customWebView.Uri);

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (Control == null)
                    {
                        return;
                    }

                    string formattedUrl = string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", filename);
                    Control.LoadUrl(formattedUrl);
                });
            }
        }
    }
}
