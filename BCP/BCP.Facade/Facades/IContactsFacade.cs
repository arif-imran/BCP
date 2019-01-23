//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IContactsFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IContactsFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Threading.Tasks;
    using BCP.DataAccess.Model;

    /// <summary>
    /// Contacts facade.
    /// </summary>
    public interface IContactsFacade
    {
        /// <summary>
        /// Gets the content of the emergency contacts.
        /// </summary>
        /// <returns>The emergency contacts content.</returns>
        /// <param name="location">the Location.</param>
        Task<EmergencyContactsContent> GetEmergencyContactsContent(string location);
    }
}
