//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IDocumentApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IDocumentApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System.Threading.Tasks;

    /// <summary>
    /// Document API.
    /// </summary>
    public interface IDocumentApi
    {
        /// <summary>
        /// Gets the BCPD ocument.
        /// </summary>
        /// <returns>The BCPD ocument.</returns>
        /// <param name="url">the URL.</param>
        Task<byte[]> GetBCPDocument(string url);
    }
}
