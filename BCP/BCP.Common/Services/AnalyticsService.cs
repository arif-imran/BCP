//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AnalyticsService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AnalyticsService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Grosvenor.Forms.Core.Services;
    using Grosvenor.Forms.Core.Utils;

    /// <summary>
    /// Analytics service.
    /// </summary>
    public class AnalyticsService : IAnalyticsService
    {
        /// <summary>
        ///     The download prefix
        /// </summary>
        private const string DownloadPrefix = "Download";

        /// <summary>The serarch prefix.</summary>
        private const string SerarchPrefix = "Search";

        /// <summary>The analytics provider.</summary>
        private readonly IAnalyticsProvider analyticsProvider = SharedContainer.ResolveType<IAnalyticsProvider>();

        /// <summary>Tracks the download event.</summary>
        /// <param name="filename">Name of the event.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task TrackDownloadEvent(string filename)
        {
            var events = new Dictionary<string, string> { { "filename", filename } };
            this.TrackEvent(DownloadPrefix, events).Forget();
        }

        /// <summary>The track event.</summary>
        /// <param name="name">The name.</param>
        /// <param name="events">The events.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task TrackEvent(string name, Dictionary<string, string> events = null)
        {
            if (events == null)
            {
                events = new Dictionary<string, string>();
            }

            try
            {
                this.analyticsProvider.TrackEvent(name, events);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Tracks the exception.
        /// </summary>
        /// <param name="exception">Exception param.</param>
        public void TrackException(Exception exception)
        {
            return;
        }

        /// <summary>Tracks the page view event.</summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="events">The events.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task TrackPageViewEvent(string eventName, Dictionary<string, string> events = null)
        {
            var trimmedEventName = eventName.Replace("ViewModel", string.Empty);

            if (events == null)
            {
                events = new Dictionary<string, string>();
            }

            try
            {
                this.analyticsProvider.TrackPageView(trimmedEventName, events);
            }
            catch
            {
            }
        }

        /// <summary>The track search event.</summary>
        /// <param name="eventName">The event name.</param>
        /// <param name="events">The events.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task TrackSearchEvent(string eventName, Dictionary<string, string> events = null)
        {
            var trimmedEventName = eventName.Replace("ViewModel", string.Empty);

            if (events == null)
            {
                events = new Dictionary<string, string>();
            }

            this.TrackEvent($"{SerarchPrefix} {trimmedEventName}", events).Forget();
        }
    }
}
