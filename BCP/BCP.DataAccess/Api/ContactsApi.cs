//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ContactsApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ContactsApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BCP.Common.Services;
    using BCP.DataAccess.Model;
    using BCP.DataAccess.Services;

    /// <summary>
    /// Contacts API.
    /// </summary>
    public class ContactsApi : IContactsApi
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
        /// Initializes a new instance of the <see cref="T:BCP.DataAccess.Api.ContactsApi"/> class.
        /// </summary>
        /// <param name="restService">Rest service.</param>
        /// <param name="cacheService">Cache service.</param>
        public ContactsApi(ISimpleRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;
        }

        /// <summary>
        /// Gets the content of the emergency contacts.
        /// </summary>
        /// <returns>The emergency contacts content.</returns>
        /// <param name="location">the Location.</param>
        public async Task<EmergencyContactsContent> GetEmergencyContactsContent(string location)
        {
            try
            {
                string requestUrl = ApiRequestHelper.GetEmergencyContactsContent(location);
                var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, async () => await this.restService.GetObjectFromAPI<EmergencyContactsContent>(requestUrl, new HttpMethod("GET")));
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("{0} GetEmergencyContactsContent Exception: {1}", GetType().Name, ex.Message);
#endif
                throw ex;
            }
        }
    }
}
