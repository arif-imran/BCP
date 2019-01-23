//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ErrorResult.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ErrorResult.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Model
{
    /// <summary>
    /// Error result.
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        ///     Gets or sets the status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        ///     Gets or sets the status description.
        /// </summary>
        public string StatusDescription { get; set; }
    }
}