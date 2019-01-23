//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="RespondFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   RespondFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.DataAccess.Api;

    /// <summary>
    /// Respond facade.
    /// </summary>
    public class RespondFacade : IRespondFacade
    {
        /// <summary>
        /// The respond API.
        /// </summary>
        private readonly IRespondApi respondApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Facade.Facades.RespondFacade"/> class.
        /// </summary>
        /// <param name="respondApi">Respond API.</param>
        public RespondFacade(IRespondApi respondApi)
        {
            this.respondApi = respondApi;
        }

        /// <summary>
        /// Gets the content of the respond.
        /// </summary>
        /// <returns>The respond content.</returns>
        /// <param name="role">the Role.</param>
        /// <param name="location">the Location.</param>
        public async Task<RespondContent> GetRespondContent(string role, string location)
        {
            return await this.respondApi.GetRespondContent(role, location);
        }
    }
}
