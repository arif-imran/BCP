//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="SeverityImageConverter.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   SeverityImageConverter.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Converters
{
    using System;
    using System.Globalization;
    using BCP.Common.Models;
    using Xamarin.Forms;

    /// <summary>
    /// Severity image converter.
    /// </summary>
    public class SeverityImageConverter : IValueConverter
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
            var severity = (IncidentSeverity)value;
            switch (severity)
            {
                case IncidentSeverity.Bronze:
                    return "icon_bronze_warning.png";
                case IncidentSeverity.Silver:
                    return "icon_silver_warning.png";
                case IncidentSeverity.Gold:
                    return "icon_gold_warning.png";
                default:
                    return "icon_bronze_warning.png";
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
