//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CallTreeFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CallTreeFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.DataAccess.Api;

    /// <summary>
    /// Call tree facade.
    /// </summary>
    public class CallTreeFacade : ICallTreeFacade
    {
        /// <summary>
        /// The call tree API.
        /// </summary>
        private readonly ICallTreeApi callTreeApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Facade.Facades.CallTreeFacade"/> class.
        /// </summary>
        /// <param name="callTreeApi">Call tree API.</param>
        public CallTreeFacade(ICallTreeApi callTreeApi)
        {
            this.callTreeApi = callTreeApi;
        }

        /// <summary>
        /// Gets the call tree.
        /// </summary>
        /// <returns>The call tree.</returns>
        /// <param name="location">the Location.</param>
        public async Task<IEnumerable<Contact>> GetCallTree(string location)
        {
            return await this.callTreeApi.GetCallTree(location);
        }
    }
}