//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="SelectedOrUnselectedConverter.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   SelectedOrUnselectedConverter.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    /// <summary>
    /// Selected or unselected converter.
    /// </summary>
    public class SelectedOrUnselectedConverter : IValueConverter
    {
        /// <summary>
        /// Convert the specified value, targetType, parameter and culture.
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="value">the Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">the Parameter.</param>
        /// <param name="culture">the Culture.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selected = (bool)value;
            if (selected)
            {
                return "icon_circle_selected.png";
            }
            else
            {
                return "icon_circle_unselected.png";
            }
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <returns>The back.</returns>
        /// <param name="value">the Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">the Parameter.</param>
        /// <param name="culture">the Culture.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}