//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="PdfWebViewRenderer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   PdfWebViewRenderer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

using BCP.Forms.Controls;
using BCP.IOS.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PdfWebView), typeof(PdfWebViewRenderer))]

namespace BCP.IOS.Renderers
{
    /// <summary>
    /// Pdf web view renderer.
    /// </summary>
    public class PdfWebViewRenderer : ViewRenderer<PdfWebView, UIWebView>
    {
        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E param.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<PdfWebView> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                this.SetNativeControl(new UIWebView());
            }

            if (e.OldElement != null)
            {
                // Cleanup
            }

            if (e.NewElement != null)
            {
                var customWebView = Element as PdfWebView;

                this.LoadUri(customWebView);
                Control.ScalesPageToFit = true;
            }
        }

        /// <summary>
        /// Ons the element property changed.
        /// </summary>
        /// <param name="sender">Sender param.</param>
        /// <param name="e">E param.</param>
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
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (Control == null)
                    {
                        return;
                    }

                    Control.LoadData(NSData.FromArray(customWebView.Uri), "application/pdf", string.Empty, new NSUrl(string.Empty));
                    Control.ScalesPageToFit = true;

                    customWebView.IsBusy = false;
                });
            }
        }
    }
}
