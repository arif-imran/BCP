//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ISimpleRestService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ISimpleRestService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Services
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BCP.DataAccess.Model;

    /// <summary>
    /// Simple rest service.
    /// </summary>
    public interface ISimpleRestService
    {
        /// <summary>
        /// Makes the open request async.
        /// </summary>
        /// <returns>The open request async.</returns>
        /// <param name="requestUrl">Request URL.</param>
        /// <param name="verb">the Verb.</param>
        /// <param name="failSilent">If set to <c>true</c> fail silent.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<ApiResponse<T>> MakeOpenRequestAsync<T>(string requestUrl, HttpMethod verb, bool failSilent = false);

        /// <summary>
        /// Gets the object from API.
        /// </summary>
        /// <returns>The object from API.</returns>
        /// <param name="requestUrl">Request URL.</param>
        /// <param name="verb">the Verb.</param>
        /// <param name="failSilent">If set to <c>true</c> fail silent.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> GetObjectFromAPI<T>(string requestUrl, HttpMethod verb, bool failSilent = false);
    }
}