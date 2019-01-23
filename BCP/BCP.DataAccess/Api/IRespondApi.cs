//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IRespondApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IRespondApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Respond API.
    /// </summary>
    public interface IRespondApi
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
