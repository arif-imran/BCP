//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ContactsFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ContactsFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Threading.Tasks;
    using BCP.DataAccess.Api;
    using BCP.DataAccess.Model;

    /// <summary>
    /// Contacts facade.
    /// </summary>
    public class ContactsFacade : IContactsFacade
    {
        /// <summary>
        /// The contacts API.
        /// </summary>
        private readonly IContactsApi contactsApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Facade.Facades.ContactsFacade"/> class.
        /// </summary>
        /// <param name="contactsApi">Contacts API.</param>
        public ContactsFacade(IContactsApi contactsApi)
        {
            this.contactsApi = contactsApi;
        }

        /// <summary>
        /// Gets the content of the emergency contacts.
        /// </summary>
        /// <returns>The emergency contacts content.</returns>
        /// <param name="location">the Location.</param>
        public async Task<EmergencyContactsContent> GetEmergencyContactsContent(string location)
        {
            return await this.contactsApi.GetEmergencyContactsContent(location);
        }
    }
}