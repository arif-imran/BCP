//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="DocumentApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   DocumentApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BCP.Common.Services;
    using BCP.DataAccess.Services;

    /// <summary>
    /// Document API.
    /// </summary>
    public class DocumentApi : IDocumentApi
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
        /// Initializes a new instance of the <see cref="T:BCP.DataAccess.Api.DocumentApi"/> class.
        /// </summary>
        /// <param name="restService">Rest service.</param>
        /// <param name="cacheService">Cache service.</param>
        public DocumentApi(ISimpleRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;
        }

        /// <summary>
        /// Gets the BCPD ocument.
        /// </summary>
        /// <returns>The BCPD ocument.</returns>
        /// <param name="url">the URL.</param>
        public async Task<byte[]> GetBCPDocument(string url)
        {
            try
            {
                var result = await this.cacheService.GetOrFetchObjectByKey(url, async () => await this.restService.GetObjectFromAPI<byte[]>(url, new HttpMethod("GET")));
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
