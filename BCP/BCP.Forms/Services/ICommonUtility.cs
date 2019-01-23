// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ICommonUtility.cs" company="Grosvenor">
// //   
// // </copyright>
// // <summary>
// //   ICommonUtility
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Services
{
    /// <summary>
    /// Common utility.
    /// </summary>
    public interface ICommonUtility
    {
          /// <summary>
        /// Gets the height of the status bar.
        /// </summary>
        /// <value>The height of the status bar.</value>
        int StatusBarHeight { get; }

        /// <summary>
        /// Gets the height of the page header.
        /// </summary>
        /// <value>The height of the page header.</value>
        int PageHeaderHeight { get; }

        /// <summary>
        /// Screens the height.
        /// </summary>
        /// <returns>The height.</returns>
        int ScreenHeight();

        /// <summary>
        /// Screens the width.
        /// </summary>
        /// <returns>The width.</returns>
        int ScreenWidth();
    }
}
