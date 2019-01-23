//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CustomSearchBarRenderer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CustomSearchBarRenderer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

using System;
using BCP.Forms.Controls;
using BCP.IOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]

namespace BCP.IOS.Renderers
{
    /// <summary>
    /// Custom search bar renderer.
    /// </summary>
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        // There might be a better place for this, but I don't know where it is
        // public override void Draw(RectangleF rect)
        // {
        // var csb = (CustomSearchBar)Element;
        // if (csb.BarTint != null)
        // Control.BarTintColor = csb.BarTint.GetValueOrDefault().ToUIColor();
        // Control.BarStyle = (UIBarStyle)Enum.Parse(typeof(UIBarStyle), csb.BarStyle);
        // Control.SearchBarStyle = (UISearchBarStyle)Enum.Parse(typeof(UISearchBarStyle), csb.BarStyle);
        // base.Draw(rect);
        // }

        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E param.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                var csb = (CustomSearchBar)Element;
                if (csb.BarTint != null)
                {
                    Control.BarTintColor = csb.BarTint.GetValueOrDefault().ToUIColor();
                }

                Control.BarStyle = (UIBarStyle)Enum.Parse(typeof(UIBarStyle), csb.BarStyle);
                Control.SearchBarStyle = (UISearchBarStyle)Enum.Parse(typeof(UISearchBarStyle), "Minimal");
                Control.SetNeedsDisplay();
            }
        }
    }
}
