//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="RespondApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   RespondApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Common.Services;
    using BCP.DataAccess.Services;

    /// <summary>
    /// Respond API.
    /// </summary>
    public class RespondApi : IRespondApi
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
        /// Initializes a new instance of the <see cref="T:BCP.DataAccess.Api.RespondApi"/> class.
        /// </summary>
        /// <param name="restService">Rest service.</param>
        /// <param name="cacheService">Cache service.</param>
        public RespondApi(ISimpleRestService restService, ICacheService cacheService)
        {
            this.cacheService = cacheService;
            this.restService = restService;
        }

        /// <summary>
        /// Gets the content of the respond.
        /// </summary>
        /// <returns>The respond content.</returns>
        /// <param name="role">the Role.</param>
        /// <param name="location">the Location.</param>
        public async Task<RespondContent> GetRespondContent(string role, string location)
        {
            try
            {
                var requestUrl = ApiRequestHelper.GetRespondContent(role, location);
                var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, async () => await this.restService.GetObjectFromAPI<RespondContent>(requestUrl, new HttpMethod("GET")));
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("{0} GetRespondContent Exception: {1}", GetType().Name, ex.Message);
#endif
                throw ex;
            }
        }
    }
}
