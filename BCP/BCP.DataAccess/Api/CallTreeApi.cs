//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CallTreeApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CallTreeApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Common.Services;
    using BCP.DataAccess.Services;

    /// <summary>
    /// Call tree API.
    /// </summary>
    public class CallTreeApi : ICallTreeApi
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
        /// Initializes a new instance of the <see cref="T:BCP.DataAccess.Api.CallTreeApi"/> class.
        /// </summary>
        /// <param name="restService">Rest service.</param>
        /// <param name="cacheService">Cache service.</param>
        public CallTreeApi(ISimpleRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;
        }

        /// <summary>
        /// Gets the call tree.
        /// </summary>
        /// <returns>The call tree.</returns>
        /// <param name="location">the Location.</param>
        public async Task<IEnumerable<Contact>> GetCallTree(string location)
        {
            try
            {
                string requestUrl = ApiRequestHelper.GetCallTree(WebUtility.UrlEncode(location));
                var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, async () => await this.restService.GetObjectFromAPI<IEnumerable<Contact>>(requestUrl, new HttpMethod("GET")));
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("{0} GetCallTree Exception: {1}", GetType().Name, ex.Message);
#endif
                throw ex;
            }
        }
    }
}