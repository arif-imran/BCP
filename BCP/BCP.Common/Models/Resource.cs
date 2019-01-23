//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="Resource.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   Resource.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Resource Model.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets the i OSA pp URL.
        /// </summary>
        /// <value>The iOS App URL.</value>
        public string IOSAppURL { get; set; }

        /// <summary>
        /// Gets or sets the android app bundle.
        /// </summary>
        /// <value>The android app bundle.</value>
        public string AndroidAppBundle { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        [JsonProperty(PropertyName = "ResourceType")]

        [JsonConverter(typeof(StringEnumConverter))]

        public ResourceType Category { get; set; }

        /// <summary>
        /// Gets or sets the IOS Fall back URL.
        /// </summary>
        /// <value>The IOS Fall back URL.</value>
        public string IOSFallBackURL { get; set; }

        /// <summary>
        /// Gets or sets the android fall back URL.
        /// </summary>
        /// <value>The android fall back URL.</value>
        public string AndroidFallBackURL { get; set; }
    }
}
