//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="HyperLinkLabelRenderer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   HyperLinkLabelRenderer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

[assembly: Xamarin.Forms.ExportRenderer(typeof(BCP.Forms.Controls.HyperLinkLabel), typeof(BCP.Droid.Renderers.HyperLinkLabelRenderer))]

namespace BCP.Droid.Renderers
{
    using System;
    using Android.Text.Util;
    using Android.Util;
    using Android.Widget;
    using BCP.Droid.Renderers;
    using BCP.Forms.Controls;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// Hyper link label renderer.
    /// </summary>
    public class HyperLinkLabelRenderer : LabelRenderer
    {
        /// <summary>
        /// The text view.
        /// </summary>
        private TextView textView;

        /// <summary>
        /// Ons the element property changed.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Args </param>
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
                this.textView = new TextView(Context);
            }

            this.textView.LayoutParameters = new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            this.textView.SetTextColor(view.TextColor.ToAndroid());

            //// Setting the auto link mask to capture all types of link-able data
            this.textView.AutoLinkMask = MatchOptions.All;
            //// Make sure to set text after setting the mask
            this.textView.Text = view.Text;
            this.textView.SetTextSize(ComplexUnitType.Dip, (float)view.FontSize);
            this.textView.SetTextColor(Android.Graphics.Color.Argb(255, 26, 133, 117));
            this.textView.SetLinkTextColor(Android.Graphics.Color.Argb(255, 26, 133, 117));
            //// overriding Xamarin Forms Label and replace with our native control
            this.SetNativeControl(this.textView);
        }
    }
}
