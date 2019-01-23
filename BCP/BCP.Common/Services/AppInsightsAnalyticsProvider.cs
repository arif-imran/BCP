//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AppInsightsAnalyticsProvider.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AppInsightsAnalyticsProvider.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Services
{
    using System.Collections.Generic;
    using AI.XamarinSDK;

    /// <summary>
    /// App insights analytics provider.
    /// </summary>
    public abstract class AppInsightsAnalyticsProvider : IAnalyticsProvider
    {
        /// <summary>
        /// Gets or sets the application insights.
        /// </summary>
        /// <value>The application insights.</value>
        protected IApplicationInsights ApplicationInsights
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the telemetry manager.
        /// </summary>
        /// <value>The telemetry manager.</value>
        protected ITelemetryManager TelemetryManager
        {
            get;
            set;
        }

        /// <summary>The set user.</summary>
        /// <param name="username">The username.</param>
        public virtual void SetUser(string username)
        {
            // As per discussion with Elaine Kelly this should not be tracked. 
            // this.ApplicationInsights.SetUserId(username);
        }

        /// <summary>The track event.</summary>
        /// <param name="eventName">The event name.</param>
        /// <param name="events">The events.</param>
        public virtual void TrackEvent(string eventName, Dictionary<string, string> events = null)
        {
            this.TelemetryManager.TrackEvent(eventName, events);
        }

        /// <summary>The track page view.</summary>
        /// <param name="eventName">The event name.</param>
        /// <param name="events">The events.</param>
        public virtual void TrackPageView(string eventName, Dictionary<string, string> events = null)
        {
            if (events == null || events.Count == 0)
            {
                this.TelemetryManager.TrackPageView(eventName);
            }
            else
            {
                this.TelemetryManager.TrackPageView(eventName, 1, events);
            }
        }
    }
}
