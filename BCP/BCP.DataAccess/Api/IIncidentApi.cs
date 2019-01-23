//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IIncidentApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IIncidentApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Incident API.
    /// </summary>
    public interface IIncidentApi
    {
        /// <summary>
        /// Gets the incident type list.
        /// </summary>
        /// <returns>The incident type list.</returns>
        /// <param name="location">the Location.</param>
        Task<IEnumerable<IncidentType>> GetIncidentTypeList(string location);
    }
}
