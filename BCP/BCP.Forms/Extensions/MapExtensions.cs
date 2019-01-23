//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="MapExtensions.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   MapExtensions.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Extensions
{
    using BCP.DataAccess.Model;
    using BCP.Forms.Controls;
    using Xamarin.Forms.Maps;

    /// <summary>
    /// Map extensions.
    /// </summary>
    public static class MapExtensions
    {
        /// <summary>
        /// Ases the pin.
        /// </summary>
        /// <returns>The pin.</returns>
        /// <param name="item">the Item.</param>
        public static CustomPin AsPin(this EmergencyContact item)
        {
            return new CustomPin() { Id = item.Id, Type = item.Type, Pin = new Pin() { Address = item.Address, Label = item.Name, Position = new Position(item.Latitude, item.Longitude) } };
        }
    }
}
