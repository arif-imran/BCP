//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IAnalyticsProvider.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IAnalyticsProvider.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// Analytics provider.
    /// </summary>
    public interface IAnalyticsProvider
    {
        /// <summary>
        /// Sets the user.
        /// </summary>
        /// <param name="username">Username param.</param>
        void SetUser(string username);

        /// <summary>
        /// Tracks the event.
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="events">Events param.</param>
        void TrackEvent(string eventName, Dictionary<string, string> events = null);

        /// <summary>
        /// Tracks the page view.
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="events">Events param.</param>
        void TrackPageView(string eventName, Dictionary<string, string> events = null);
    }
}
