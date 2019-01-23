//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="DocumentFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   DocumentFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Threading.Tasks;
    using BCP.DataAccess.Api;

    /// <summary>
    /// Document facade.
    /// </summary>
    public class DocumentFacade : IDocumentFacade
    {
        /// <summary>
        /// The document API.
        /// </summary>
        private readonly IDocumentApi documentApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Facade.Facades.DocumentFacade"/> class.
        /// </summary>
        /// <param name="documentApi">Document API.</param>
        public DocumentFacade(IDocumentApi documentApi)
        {
            this.documentApi = documentApi;
        }

        /// <summary>
        /// Gets the BCPD ocument.
        /// </summary>
        /// <returns>The BCPD ocument.</returns>
        /// <param name="url">the URL.</param>
        public async Task<byte[]> GetBCPDocument(string url)
        {
            return await this.documentApi.GetBCPDocument(url);
        }
    }
}