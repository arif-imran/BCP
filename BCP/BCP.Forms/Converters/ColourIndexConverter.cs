//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ColourIndexConverter.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ColourIndexConverter.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Converters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Xamarin.Forms;

    /// <summary>
    /// Colour index converter.
    /// </summary>
    public class ColourIndexConverter : IValueConverter
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
            if (value == null || parameter == null)
            {
                return Color.White;
            }

            var index = ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            switch (index % 6)
            {
                case 1:
                    return Color.FromHex("E35330");
                case 2:
                    return Color.FromHex("E770A5");
                case 3:
                    return Color.FromHex("5FAA34");
                case 4:
                    return Color.FromHex("4E78BF");
                case 5:
                    return Color.FromHex("686BB2");
                default:
                    return Color.FromHex("F7D04F");
            }
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <returns>The back.</returns>
        /// <param name="value">the Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">The Parameter .</param>
        /// <param name="culture">Culture. information </param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
