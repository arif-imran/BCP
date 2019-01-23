//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IncidentFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IncidentFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.DataAccess.Api;

    /// <summary>
    /// Incident facade.
    /// </summary>
    public class IncidentFacade : IIncidentFacade
    {
        /// <summary>
        /// The incident API.
        /// </summary>
        private readonly IIncidentApi incidentApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Facade.Facades.IncidentFacade"/> class.
        /// </summary>
        /// <param name="incidentApi">Incident API.</param>
        public IncidentFacade(IIncidentApi incidentApi)
        {
            this.incidentApi = incidentApi;
        }

        /// <summary>
        /// Gets the incident type list.
        /// </summary>
        /// <returns>The incident type list.</returns>
        /// <param name="location">the Location.</param>
        public async Task<IEnumerable<IncidentType>> GetIncidentTypeList(string location)
        {
            return await this.incidentApi.GetIncidentTypeList(location);
        }
    }
}
