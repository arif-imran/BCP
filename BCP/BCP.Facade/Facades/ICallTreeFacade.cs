//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ICallTreeFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ICallTreeFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Call tree facade.
    /// </summary>
    public interface ICallTreeFacade
    {
        /// <summary>
        /// Gets the call tree.
        /// </summary>
        /// <returns>The call tree.</returns>
        /// <param name="location">the Location.</param>
        Task<IEnumerable<Contact>> GetCallTree(string location);
    }
}