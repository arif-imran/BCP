//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="PdfWebView.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   PdfWebView.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Controls
{
    using Xamarin.Forms;

    /// <summary>
    /// Pdf web view.
    /// </summary>
    public class PdfWebView : WebView
    {
        /// <summary>
        /// The URI property.
        /// </summary>
        public static readonly BindableProperty UriProperty = BindableProperty.Create(
            propertyName: "Uri",
            returnType: typeof(byte[]),
            declaringType: typeof(PdfWebView),
            defaultValue: default(byte[]));
            
        /// <summary>
        /// The is busy property.
        /// </summary>
        public static readonly BindableProperty IsBusyProperty =
            BindableProperty.Create("IsBusy", typeof(bool), typeof(PdfWebView), false);

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        public byte[] Uri
        {
            get { return (byte[])GetValue(UriProperty); }
            set { this.SetValue(UriProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:GPK.Forms.Controls.PdfWebViewControl"/> is busy.
        /// </summary>
        /// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { this.SetValue(IsBusyProperty, value); }
        }
    }
}
