//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ResourceCategoryIconConverter.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ResourceCategoryIconConverter.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Converters
{
    using System;
    using System.Globalization;
    using BCP.Common.Models;
    using Xamarin.Forms;

    /// <summary>
    /// Resource category icon converter.
    /// </summary>
    public class ResourceCategoryIconConverter : IValueConverter
    {
        /// <summary>
        /// Convert the specified value, targetType, parameter and culture.
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="value">Object Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Object Parameter.</param>
        /// <param name="culture">Culture Info.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ResourceType)value)
            {
                case ResourceType.Link:
                    return "icon_unlock_white.png";
                case ResourceType.Apps:
                    return "icon_app_white.png";
                default:
                    return "icon_file_white.png";
            }
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <returns>The back.</returns>
        /// <param name="value">Object Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Object Parameter.</param>
        /// <param name="culture">Culture Info.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
