// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="CustomMapRenderer.cs" company="Grosvenor">
// //   Grosvenor
// // </copyright>
// // <summary>
// //   CustomMapRenderer
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

[assembly: Xamarin.Forms.ExportRenderer(typeof(BCP.Forms.Controls.CustomMap), typeof(BCP.Droid.Renderers.CustomMapRenderer))]

namespace BCP.Droid.Renderers
{
    using System;
    using System.Collections.Generic;
    using Android.Gms.Maps;
    using Android.Gms.Maps.Model;
    using Android.Views;
    using BCP.Droid.Renderers;
    using BCP.Forms.Controls;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;
    using Xamarin.Forms.Maps.Android;

    /// <summary>
    /// Custom map renderer.
    /// </summary>
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        /// <summary>
        /// The pin identifier.
        /// </summary>
        private const string PinIdentifier = "CustomPin";

        /// <summary>
        /// The custom map.
        /// </summary>
        private CustomMap customMap;

        /// <summary>
        /// The custom pins.
        /// </summary>
        private List<CustomPin> customPins;

        /// <summary>
        /// The draw count.
        /// </summary>
        private int drawCount;

        /// <summary>
        /// Gets the info contents.
        /// </summary>
        /// <returns>The info contents.</returns>
        /// <param name="marker">The Marker.</param>
        public Android.Views.View GetInfoContents(Marker marker)
        {
            return null;
        }

        /// <summary>
        /// Gets the info window.
        /// </summary>
        /// <returns>The info window.</returns>
        /// <param name="marker">The Marker.</param>
        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">ElementChangedEventArgs E.</param>
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.MarkerClick -= this.OnMarkerClick;
            }

            if (e.NewElement != null)
            {
                this.customMap = (CustomMap)e.NewElement;
                this.customPins = this.customMap.CustomPins;
                ((MapView)Control).GetMapAsync(this);
            }
        }

        /// <summary>
        /// Ons the element property changed.
        /// </summary>
        /// <param name="sender">The Sender.</param>
        /// <param name="e">PropertyChangedEventArgs E.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            // map is usually drawn once before the pins are loaded
            if (e.PropertyName.Equals("VisibleRegion") && this.drawCount < 2)
            {
                NativeMap.Clear();
                NativeMap.MarkerClick += this.OnMarkerClick;
                NativeMap.SetInfoWindowAdapter(this);

                foreach (var pin in this.customPins)
                {
                    var marker = new MarkerOptions();
                    marker.SetPosition(new LatLng(pin.Pin.Position.Latitude, pin.Pin.Position.Longitude));
                    marker.SetTitle(pin.Pin.Label);
                    marker.SetSnippet(pin.Pin.Address);
                    switch (pin.Type)
                    {
                        case DataAccess.Model.EmergencyContactType.Hospital:
                            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.icon_map_hospital_green));
                            break;
                        case DataAccess.Model.EmergencyContactType.PoliceStation:
                            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.icon_map_police_blue));
                            break;
                        case DataAccess.Model.EmergencyContactType.FireStation:
                            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.icon_map_fire_red));
                            break;
                    }

                    NativeMap.AddMarker(marker);
                }

                this.drawCount++;
            }
        }

        /// <summary>
        /// Ons the marker click.
        /// </summary>
        /// <param name="sender">The Sender.</param>
        /// <param name="e">The E.</param>
        private void OnMarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        {
            var customPin = this.GetCustomPin(e.Marker);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }

            this.customMap.PinTappedCommand.Execute(customPin);
        }

        /// <summary>
        /// Gets the custom pin.
        /// </summary>
        /// <returns>The custom pin.</returns>
        /// <param name="annotation">This Annotation.</param>
        private CustomPin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in this.customPins)
            {
                if (pin.Pin.Position == position)
                {
                    return pin;
                }
            }

            return null;
        }
    }
}