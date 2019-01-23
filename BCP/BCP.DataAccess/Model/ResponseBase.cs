//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ResponseBase.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ResponseBase.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Model
{
    /// <summary>
    /// Response base.
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Gets or sets the content status.
        /// </summary>
        /// <value>The content status.</value>
        public ResponseContentStatus ContentStatus { get; set; }

        /// <summary>
        /// Gets or sets the error response.
        /// </summary>
        /// <value>The error response.</value>
        public ErrorResult ErrorResponse { get; set; }
    }
}