//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IResourceApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IResourceApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Resource API.
    /// </summary>
    public interface IResourceApi
    {
        /// <summary>
        /// Gets the resources list.
        /// </summary>
        /// <returns>The resources list.</returns>
        Task<IEnumerable<Resource>> GetResourcesList();
    }
}
