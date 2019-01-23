//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="LocationOrRoleChangedEvent.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   LocationOrRoleChangedEvent.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Events
{
    using Prism.Events;

    /// <summary>
    /// Location or role changed event.
    /// </summary>
    public class LocationOrRoleChangedEvent : PubSubEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Common.Events.LocationOrRoleChangedEvent"/> class.
        /// </summary>
        public LocationOrRoleChangedEvent()
        {
        }
    }
}
