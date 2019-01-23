//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="HyperLinkLabelRenderer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   HyperLinkLabelRenderer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

using BCP.Forms.Controls;
using BCP.IOS.Renderers;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HyperLinkLabel), typeof(HyperLinkLabelRenderer))]

namespace BCP.IOS.Renderers
{
    /// <summary>
    /// Hyper link label renderer.
    /// </summary>
    public class HyperLinkLabelRenderer : ViewRenderer
    {
        /// <summary>
        /// The text view.
        /// </summary>
        private UITextView textView;

        /// <summary>
        /// Ons the element property changed.
        /// </summary>
        /// <param name="sender">Sender param.</param>
        /// <param name="e">E param.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (HyperLinkLabel)Element;
            if (view == null) 
            { 
                return; 
            }

            if (this.textView == null)
            {
                this.textView = new UITextView(new CGRect(0, 0, view.Width, view.Height));
            }

            this.textView.Text = view.Text;
            this.textView.Font = UIFont.SystemFontOfSize((float)view.FontSize);
            this.textView.Editable = false;

            // Setting the data detector types mask to capture all types of link-able data
            this.textView.DataDetectorTypes = UIDataDetectorType.All;
            this.textView.BackgroundColor = UIColor.Clear;
            this.textView.TintColor = UIColor.FromRGB(20, 127, 111);
            this.textView.TextColor = UIColor.FromRGB(26, 133, 117);

            // overriding Xamarin Forms Label and replace with our native control
            this.SetNativeControl(this.textView);
        }
    }
}
