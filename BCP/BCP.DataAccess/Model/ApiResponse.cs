//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ApiResponse.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ApiResponse.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Model
{
    /// <summary>
    /// API response.
    /// </summary>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public T Content { get; set; }

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