//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IncidentType.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IncidentType.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Incident type.
    /// </summary>
    public class IncidentType
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty(PropertyName = "IncidentType")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the how to respond.
        /// </summary>
        /// <value>The how to respond.</value>
        public string HowToRespond { get; set; }

        /// <summary>
        /// Gets or sets the severity.
        /// </summary>
        /// <value>The severity.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public IncidentSeverity Severity { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact user.
        /// </summary>
        /// <value>The name of the contact user.</value>
        public string ContactUserName { get; set; }

        /// <summary>
        /// Gets or sets the contact details.
        /// </summary>
        /// <value>The contact details.</value>
        public Contact ContactDetails { get; set; }

        /// <summary>
        /// Gets or sets the name of the backup contact user.
        /// </summary>
        /// <value>The name of the backup contact user.</value>
        public string BackupContactUserName { get; set; }

        /// <summary>
        /// Gets or sets the backup contact.
        /// </summary>
        /// <value>The backup contact.</value>
        public Contact BackupContact { get; set; }
    }
}
