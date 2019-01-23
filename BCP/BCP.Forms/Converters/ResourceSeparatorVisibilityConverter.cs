//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ResourceSeparatorVisibilityConverter.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ResourceSeparatorVisibilityConverter.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Converters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using BCP.Forms.Models;
    using BCP.Forms.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// Resource separator visibility converter.
    /// </summary>
    public class ResourceSeparatorVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Convert the specified value, targetType, parameter and culture.
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="value">Object Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Object Parameter.</param>
        /// <param name="culture">Culture info.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }

            foreach (var group_item in ((ListView)parameter).ItemsSource.Cast<object>().ToList())
            {
                var sublist = (group_item as ResourceGroup).ToList();
                var i = (sublist).IndexOf((BCP.Common.Models.Resource)value);
                if (i > 0)
                {
                    return (i == sublist.Count - 1);
                }
            }

            {
                return false;
            }
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <returns>The back.</returns>
        /// <param name="value">Object Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Object Parameter.</param>
        /// <param name="culture">Culture info.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
