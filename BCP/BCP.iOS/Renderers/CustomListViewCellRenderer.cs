//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CustomListViewCellRenderer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CustomListViewCellRenderer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

using BCP.IOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomListViewCellRenderer))]

namespace BCP.IOS.Renderers
{
    /// <summary>
    /// Custom list view cell renderer.
    /// </summary>
    public class CustomListViewCellRenderer : ViewCellRenderer
    {
        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <returns>The cell.</returns>
        /// <param name="item">Item Parameter.</param>
        /// <param name="reusableCell">Reusable cell.</param>
        /// <param name="tv">Tv Parameter.</param>
        public override UIKit.UITableViewCell GetCell(Xamarin.Forms.Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
        {
            // return base.GetCell(item, reusableCell, tv);
            var cell = base.GetCell(item, reusableCell, tv);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            return cell;
        }
    }
}
