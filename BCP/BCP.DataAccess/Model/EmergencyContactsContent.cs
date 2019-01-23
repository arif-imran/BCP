//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="EmergencyContactsContent.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   EmergencyContactsContent.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Emergency contacts content.
    /// </summary>
    public class EmergencyContactsContent
    {
        /// <summary>
        /// Gets or sets the emergency contacts.
        /// </summary>
        /// <value>The emergency contacts.</value>
        public IEnumerable<EmergencyContact> EmergencyContacts { get; set; }

        /// <summary>
        /// Gets or sets the national emergency contacts.
        /// </summary>
        /// <value>The national emergency contacts.</value>
        public IEnumerable<NationalEmergencyNumber> NationalEmergencyContacts { get; set; }
    }
}
