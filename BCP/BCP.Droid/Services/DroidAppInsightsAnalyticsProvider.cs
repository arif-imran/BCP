//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="DroidAppInsightsAnalyticsProvider.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   DroidAppInsightsAnalyticsProvider.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Droid.Services
{
    using AI.XamarinSDK;
    using BCP.Common;
    using BCP.Common.Services;

    /// <summary>The droid app insights analytics provider.</summary>
    public class DroidAppInsightsAnalyticsProvider : AppInsightsAnalyticsProvider
    {
        /// <summary>Initializes a new instance of the <see cref="DroidAppInsightsAnalyticsProvider"/> class.</summary>
        public DroidAppInsightsAnalyticsProvider()
        {
            CrossApplicationInsights.Current.Setup(SharedConfig.ApplicationInsightsId);
            this.ApplicationInsights = CrossApplicationInsights.Current;
            this.TelemetryManager = CrossTelemetryManager.Current;
        }
    }
}
