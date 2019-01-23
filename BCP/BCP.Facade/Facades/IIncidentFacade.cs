//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IIncidentFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IIncidentFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Incident facade.
    /// </summary>
    public interface IIncidentFacade
    {
        /// <summary>
        /// Gets the incident type list.
        /// </summary>
        /// <returns>The incident type list.</returns>
        /// <param name="location">the Location.</param>
        Task<IEnumerable<IncidentType>> GetIncidentTypeList(string location);
    }
}