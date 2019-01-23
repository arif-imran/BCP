//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IRespondFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IRespondFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Respond facade.
    /// </summary>
    public interface IRespondFacade
    {
        /// <summary>
        /// Gets the content of the respond.
        /// </summary>
        /// <returns>The respond content.</returns>
        /// <param name="role">the Role.</param>
        /// <param name="location">the Location.</param>
        Task<RespondContent> GetRespondContent(string role, string location);
    }
}
