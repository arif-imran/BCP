//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ResourcesFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ResourcesFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.DataAccess.Api;

    /// <summary>
    /// Resources facade.
    /// </summary>
    public class ResourcesFacade : IResourcesFacade
    {
        /// <summary>
        /// The resource API.
        /// </summary>
        private readonly IResourceApi resourceApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Facade.Facades.ResourcesFacade"/> class.
        /// </summary>
        /// <param name="resourceApi">Resource API.</param>
        public ResourcesFacade(IResourceApi resourceApi)
        {
            this.resourceApi = resourceApi;
        }

        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <returns>The resources.</returns>
        public async Task<IEnumerable<Resource>> GetResources()
        {
            return await this.resourceApi.GetResourcesList();
        }
    }
}