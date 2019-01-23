//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ICallTreeApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ICallTreeApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Call tree API.
    /// </summary>
    public interface ICallTreeApi
    {
        /// <summary>
        /// Gets the call tree.
        /// </summary>
        /// <returns>The call tree.</returns>
        /// <param name="location">the Location.</param>
        Task<IEnumerable<Contact>> GetCallTree(string location);
    }
}
