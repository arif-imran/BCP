//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="UserSettings.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   UserSettings.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Models
{
    /// <summary>
    /// User settings.
    /// </summary>
    public class UserSettings
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        public string FullName 
        { 
            get 
            { 
                return this.FirstName + " " + this.LastName; 
            } 
        }

        /// <summary>Gets or sets the location.</summary>
        public string Location { get; set; }

        /// <summary>Gets or sets the role.</summary>
        public string Role { get; set; }
    }
}