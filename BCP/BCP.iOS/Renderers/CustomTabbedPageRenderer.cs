//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CustomTabbedPageRenderer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CustomTabbedPageRenderer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

using BCP.IOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]

namespace BCP.IOS.Renderers
{
    /// <summary>
    /// Custom tabbed page renderer.
    /// </summary>
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E param.</param>
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            TabBar.TintColor = UIColor.FromRGB(26, 133, 117);
            TabBar.BarTintColor = UIColor.FromRGB(43, 41, 38);
            TabBar.BackgroundColor = UIColor.Gray;
        }
    }
}
