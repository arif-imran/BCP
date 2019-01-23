//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ResourceApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ResourceApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Common.Services;
    using BCP.DataAccess.Api;
    using BCP.DataAccess.Services;

    /// <summary>
    /// Resource API.
    /// </summary>
    public class ResourceApi : IResourceApi
    {
        /// <summary>
        /// The rest service.
        /// </summary>
        private readonly ISimpleRestService restService;

        /// <summary>
        /// The cache service.
        /// </summary>
        private readonly ICacheService cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.DataAccess.ResourceApi"/> class.
        /// </summary>
        /// <param name="restService">Rest service.</param>
        /// <param name="cacheService">Cache service.</param>
        public ResourceApi(ISimpleRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;
        }

        /// <summary>
        /// Gets the resources list.
        /// </summary>
        /// <returns>The resources list.</returns>
        public async Task<IEnumerable<Resource>> GetResourcesList()
        {
            try
            {
                var requestUrl = ApiRequestHelper.GetResourcesList();
                var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, async () => await this.restService.GetObjectFromAPI<IEnumerable<Resource>>(requestUrl, new HttpMethod("GET")));
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("{0} GetResourcesList Exception: {1}", GetType().Name, ex.Message);
#endif
                throw ex;
            }
        }
    }
}
