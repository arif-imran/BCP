//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="FlowSeparatorVisibilityConverter.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   FlowSeparatorVisibilityConverter.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Converters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Xamarin.Forms;

    /// <summary>
    /// Flow separator visibility converter.
    /// </summary>
    public class FlowSeparatorVisibilityConverter : IValueConverter
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
            if (value == null || parameter == null)
            {
                return true;
            }

            var index = ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            var count = ((ListView)parameter).ItemsSource.Cast<object>().ToList().Count();
            return !(index == count - 1);
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <returns>The back.</returns>
        /// <param name="value">Object Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Obejct Parameter.</param>
        /// <param name="culture">Culture info.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
