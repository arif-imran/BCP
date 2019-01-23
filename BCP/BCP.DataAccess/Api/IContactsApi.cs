//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IContactsApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IContactsApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System.Threading.Tasks;
    using BCP.DataAccess.Model;

    /// <summary>
    /// Contacts API.
    /// </summary>
    public interface IContactsApi
    {
        /// <summary>
        /// Gets the content of the emergency contacts.
        /// </summary>
        /// <returns>The emergency contacts content.</returns>
        /// <param name="location">the Location.</param>
        Task<EmergencyContactsContent> GetEmergencyContactsContent(string location);
    }
}
