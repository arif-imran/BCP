//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="UserApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   UserApi.cs
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
    /// User API.
    /// </summary>
    public class UserApi : IUserApi
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
        /// Initializes a new instance of the <see cref="T:BCP.DataAccess.Api.UserApi"/> class.
        /// </summary>
        /// <param name="restService">Rest service.</param>
        /// <param name="cacheService">Cache service.</param>
        public UserApi(ISimpleRestService restService, ICacheService cacheService)
        {
            this.restService = restService;
            this.cacheService = cacheService;
        }

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <returns>The user profile.</returns>
        /// <param name="username">the Username.</param>
        public async Task<UserSettings> GetUserProfile(string username)
        {
            try
            {
                string requestUrl = ApiRequestHelper.GetUserProfile(username);
                var result = await this.cacheService.GetOrFetchSettings(requestUrl, async () => await this.restService.GetObjectFromAPI<UserSettings>(requestUrl, new HttpMethod("GET")));
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("{0} GetUserProfile Exception: {1}", GetType().Name, ex.Message);
#endif
                throw ex;
            }
        }

        /// <summary>
        /// Gets the user profile pic.
        /// </summary>
        /// <returns>The user profile pic.</returns>
        /// <param name="username">the Username.</param>
        public async Task<byte[]> GetUserProfilePic(string username)
        {
            try
            {
                string requestUrl = ApiRequestHelper.GetUserProfilePic(username);
                var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, async () => await this.restService.GetObjectFromAPI<byte[]>(requestUrl, new HttpMethod("GET"), true));
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("{0} GetUserProfilePic Exception: {1}", GetType().Name, ex.Message);
#endif
                throw ex;
            }
        }

        /// <summary>
        /// Gets all user locations.
        /// </summary>
        /// <returns>The all user locations.</returns>
        public async Task<IEnumerable<string>> GetAllUserLocations()
        {
            try
            {
                string requestUrl = ApiRequestHelper.GetAllUserLocations();
                var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, async () => await this.restService.GetObjectFromAPI<IEnumerable<string>>(requestUrl, new HttpMethod("GET")));
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("{0} GetAllUserLocations Exception: {1}", GetType().Name, ex.Message);
#endif
                throw ex;
            }
        }

        /// <summary>
        /// Gets all user roles.
        /// </summary>
        /// <returns>The all user roles.</returns>
        public async Task<IEnumerable<string>> GetAllUserRoles()
        {
            try
            {
                string requestUrl = ApiRequestHelper.GetAllUserRoles();
                var result = await this.cacheService.GetOrFetchObjectByKey(requestUrl, async () => await this.restService.GetObjectFromAPI<IEnumerable<string>>(requestUrl, new HttpMethod("GET")));
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine("{0} GetAllUserRoles Exception: {1}", GetType().Name, ex.Message);
#endif
                throw ex;
            }
        }
    }
}
