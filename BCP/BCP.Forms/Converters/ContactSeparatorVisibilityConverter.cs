//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ContactSeparatorVisibilityConverter.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ContactSeparatorVisibilityConverter.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------
namespace BCP.Forms.Converters
{
    using System;
    using System.Globalization;
    using BCP.Common.Models;
    using Xamarin.Forms;

    /// <summary>
    /// Contact separator visibility converter.
    /// </summary>
    public class ContactSeparatorVisibilityConverter : IValueConverter
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
            if (value is Contact)
            {
                var contact = (Contact)value;
                return (!string.IsNullOrEmpty(contact.Phone1) && !string.IsNullOrEmpty(contact.Phone2));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <returns>The back.</returns>
        /// <param name="value">The Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">The Parameter.</param>
        /// <param name="culture">The Culture.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
