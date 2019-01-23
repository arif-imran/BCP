//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ContentVisibilityConverter.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ContentVisibilityConverter.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    /// <summary>
    /// Content visibility converter.
    /// </summary>
    public class ContentVisibilityConverter : IValueConverter
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
            if (value is string)
            {
                return !(string.IsNullOrEmpty((string)value));
            }
            else
            {
                return value != null;
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
