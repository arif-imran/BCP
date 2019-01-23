//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IConnectivityService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IConnectivityService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Services
{
    using Plugin.Connectivity.Abstractions;

    /// <summary>
    /// Connectivity service.
    /// </summary>
    public interface IConnectivityService
    {
        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>The instance.</value>
        IConnectivity Instance { get; set; }
    }
}
