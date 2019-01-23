//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="Settings.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   Settings.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Model
{
    using Grosvenor.Forms.DataAccess.Model;
    using SQLite;

    /// <summary>
    /// the Settings.
    /// </summary>
    [Table("Settings")]
    public class Settings : BaseEntity
    {
        /// <summary>
        /// The username.
        /// </summary>
        private string username;

        /// <summary>
        /// The location.
        /// </summary>
        private string location;

        /// <summary>
        /// The role.
        /// </summary>
        private string role;

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.SetProperty(ref this.username, value);
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.SetProperty(ref this.location, value);
            }
        }

        /// <summary>Gets or sets the role.</summary>
        public string Role
        {
            get
            {
                return this.role;
            }

            set
            {
                this.SetProperty(ref this.role, value);
            }
        }
    }
}