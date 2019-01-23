//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IDeviceService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IDeviceService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Services
{
    using System;

    /// <summary>
    /// Device service.
    /// </summary>
    public interface IDeviceService
    {
        /// <summary>
        /// Gets the runtime platform.
        /// </summary>
        /// <value>The runtime platform.</value>
        string RuntimePlatform { get; }

        /// <summary>
        /// Opens the URI.
        /// </summary>
        /// <param name="uri">URI param.</param>
        void OpenURI(Uri uri);
    }
}
