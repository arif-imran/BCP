//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IosAppInsightsAnalyticsProvider.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IosAppInsightsAnalyticsProvider.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.IOS.Services
{
    using AI.XamarinSDK;
    using BCP.Common.Services;

    /// <summary>
    /// Ios app insights analytics provider.
    /// </summary>
    public class IosAppInsightsAnalyticsProvider : AppInsightsAnalyticsProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.IOS.Services.IosAppInsightsAnalyticsProvider"/> class.
        /// </summary>
        public IosAppInsightsAnalyticsProvider()
        {
            this.ApplicationInsights = CrossApplicationInsights.Current;
            this.TelemetryManager = CrossTelemetryManager.Current;
        }
    }
}