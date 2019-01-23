//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="Contact.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   Contact.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Models
{
   /// <summary>
   /// Contact Model.
   /// </summary>
    public class Contact
    {   
        /// <summary>
        /// The avatar.
        /// </summary>
        private string avatar = string.Empty;

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public string Location { get; set; }
       
        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>The job title.</value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the phone1.
        /// </summary>
        /// <value>The phone1.</value>
        public string Phone1 { get; set; }

        /// <summary>
        /// Gets or sets the phone2.
        /// </summary>
        /// <value>The phone2.</value>
        public string Phone2 { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the office.
        /// </summary>
        /// <value>The office.</value>
        public string Office { get; set; }

        /// <summary>
        /// Gets or sets the avatar.
        /// </summary>
        /// <value>The avatar.</value>
        public string Avatar
        {
            get
            { 
                return this.avatar;
            }

            set
            {
                this.avatar = value.Split(',')[0];
            }
        }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        // This probably shouldn't be here, maybe a separate class in ViewModels?

        /// <summary>
        /// Gets the name sort.
        /// </summary>
        /// <value>The name sort.</value>
        public string NameSort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.FirstName) || this.FirstName.Length == 0)
                {
                    return "?";
                }

                return this.FirstName[0].ToString().ToUpper();
            }
        }
    }
}
