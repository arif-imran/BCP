//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IResourcesFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IResourcesFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Resources facade.
    /// </summary>
    public interface IResourcesFacade
    {
        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <returns>The resources.</returns>
        Task<IEnumerable<Resource>> GetResources();
    }
}