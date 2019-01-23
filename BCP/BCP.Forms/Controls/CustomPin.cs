//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CustomPin.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CustomPin.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Controls
{
    using BCP.DataAccess.Model;
    using Xamarin.Forms.Maps;

    /// <summary>
    /// Custom pin.
    /// </summary>
    public class CustomPin 
    {
        /// <summary>
        /// Gets or sets the pin.
        /// </summary>
        /// <value>The pin.</value>
        public Pin Pin { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public EmergencyContactType Type { get; set; }
    }
}
