//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="Document.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   Document.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Models
{
    using System;

    /// <summary>
    /// Document Model.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime UpdatedDate { get; set; }
    }
}
