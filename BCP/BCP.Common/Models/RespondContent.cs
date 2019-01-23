//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="RespondContent.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   RespondContent.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Respond content.
    /// </summary>
    public class RespondContent
    {
        /// <summary>
        /// Gets or sets the respond header.
        /// </summary>
        /// <value>The respond header.</value>
        public string RespondHeader { get; set; }

        /// <summary>
        /// Gets or sets the useful tools.
        /// </summary>
        /// <value>The useful tools.</value>
        public IEnumerable<Resource> UsefulTools { get; set; }

        /// <summary>
        /// Gets or sets the flowchart.
        /// </summary>
        /// <value>The flowchart.</value>
        public IEnumerable<string> Flowchart { get; set; }

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>The additional information.</value>
        public string AdditionalInformation { get; set; }
    }
}
