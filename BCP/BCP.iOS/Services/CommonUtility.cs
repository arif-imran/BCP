//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CommonUtility.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CommonUtility.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

using BCP.Forms.Services;
using BCP.IOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(CommonUtility))]

namespace BCP.IOS.Services
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
                return (int)UIApplication.SharedApplication.StatusBarFrame.Height;
            }
        }

        /// <summary>
        /// Gets the height of the page header.
        /// </summary>
        /// <value>The height of the page header.</value>
        public int PageHeaderHeight => this.StatusBarHeight * 3;

        /// <summary>
        /// Screens the height.
        /// </summary>
        /// <returns>The height.</returns>
        public int ScreenHeight()
        {
            int height = (int)UIScreen.MainScreen.Bounds.Size.Height;
            return height;
        }

        /// <summary>
        /// Screens the width.
        /// </summary>
        /// <returns>The width.</returns>
        public int ScreenWidth()
        {
            int height = (int)UIScreen.MainScreen.Bounds.Size.Width;
            return height;
        }
    }
}