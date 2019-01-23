//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IDocumentFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IDocumentFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Document facade.
    /// </summary>
    public interface IDocumentFacade
    {
        /// <summary>
        /// Gets the BCPD ocument.
        /// </summary>
        /// <returns>The BCPD ocument.</returns>
        /// <param name="url">the URL.</param>
        Task<byte[]> GetBCPDocument(string url);
    }
}
