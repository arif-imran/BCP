//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IncidentApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IncidentApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Common.Services;
    using BCP.DataAccess.Services;

    /// <summary>
    /// Incident API.
    /// </summary>
    public class IncidentApi : IIncidentApi
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
        /// Initializes a new instance of the <see cref="T:BCP.DataAccess.Api.IncidentApi"/> class.
        /// </summary>
        /// <param name="restService">Rest service.</param>
        /// <param name="cacheService">Cache service.</param>
        public IncidentApi(ISimpleRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;
        }

        /// <summary>
        /// Gets the incident type list.
        /// </summary>
        /// <returns>The incident type list.</returns>
        /// <param name="location">the Location.</param>
        public async Task<IEnumerable<IncidentType>> GetIncidentTypeList(string location)
        {
            try
            {
                string requestUrl = ApiRequestHelper.GetIncidentList(location);
                var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, async () => await this.restService.GetObjectFromAPI<IEnumerable<IncidentType>>(requestUrl, new HttpMethod("GET")));
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
				Debug.WriteLine("{0} GetIncidentTypeList Exception: {1}", GetType().Name, ex.Message);
#endif 
                throw ex;
            }
        }
    }
}
