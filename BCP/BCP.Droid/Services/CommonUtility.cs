//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CommonUtility.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CommonUtility.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

using System;
using Android.Content.Res;
using BCP.Droid.Services;
using BCP.Forms.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CommonUtility))]

namespace BCP.Droid.Services
{
    /// <summary>
    /// Common utility.
    /// </summary>
    public class CommonUtility : ICommonUtility
    {
        /// <summary>
        /// Gets the height of the status bar.
        /// </summary>
        /// <value>The height of the status bar.</value>
        public int StatusBarHeight
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the height of the page header.
        /// </summary>
        /// <value>The height of the page header.</value>
        public int PageHeaderHeight => 60;

        /// <summary>
        /// Screens the height.
        /// </summary>
        /// <returns>The height.</returns>
        public int ScreenHeight()
        {
            return (int)(Xamarin.Forms.Forms.Context.Resources.DisplayMetrics.HeightPixels / Xamarin.Forms.Forms.Context.Resources.DisplayMetrics.Density);
        }

        /// <summary>
        /// Screens the width.
        /// </summary>
        /// <returns>The width.</returns>
        public int ScreenWidth()
        {
            return (int)(Xamarin.Forms.Forms.Context.Resources.DisplayMetrics.WidthPixels / Xamarin.Forms.Forms.Context.Resources.DisplayMetrics.Density);
        }
    }
}
