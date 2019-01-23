//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CustomMap.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CustomMap.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Controls
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using BCP.DataAccess.Model;
    using BCP.Forms.Extensions;
    using BCP.Forms.Helpers;
    using Plugin.Geolocator;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;

    /// <summary>
    /// Custom map.
    /// </summary>
    public class CustomMap : Map
    {
        ////public static readonly BindableProperty PinTappedCommandProperty = BindableProperty.Create(nameof(PinTappedCommand), typeof(ICommand), typeof(CustomMap), null, propertyChanged: OnCommandPropertyChanged);
        ////public static readonly BindableProperty PinTappedCommandProperty = BindableProperty.Create<CustomMap, ICommand>(x => x.PinTappedCommand, default(ICommand), propertyChanged: OnCommandPropertyChanged);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Controls.CustomMap"/> class.
        /// </summary>
        public CustomMap()
        {
            this.BindingContext = this;
            this.CustomPins = new List<CustomPin>();
        }

        /// <summary>
        /// Gets or sets the custom pins.
        /// </summary>
        /// <value>The custom pins.</value>
        public List<CustomPin> CustomPins { get; set; }

        /// <summary>
        /// Gets or sets the pin tapped command.
        /// </summary>
        /// <value>The pin tapped command.</value>
        public ICommand PinTappedCommand { get; set; }

        /// <summary>
        /// Gets or sets the pin deselected command.
        /// </summary>
        /// <value>The pin deselected command.</value>
        public ICommand PinDeselectedCommand { get; set; }

        /// <summary>
        /// Updates the pins.
        /// </summary>
        /// <param name="items">the Items.</param>
        public async void UpdatePins(IEnumerable<EmergencyContact> items)
        {
            this.CustomPins.Clear();

            var latitudes = new List<double>();
            var longitudes = new List<double>();

            var locator = CrossGeolocator.Current;
            var userPosition = await locator.GetPositionAsync();
            latitudes.Add(userPosition.Latitude);
            longitudes.Add(userPosition.Longitude);

            foreach (var item in items)
            {
                this.CustomPins.Add(item.AsPin());
                Pins.Add(item.AsPin().Pin);
                latitudes.Add(item.Latitude);
                longitudes.Add(item.Longitude);
            }

            this.CenterMapOnPinsAndUserLocation(latitudes, longitudes);
        }

        /// <summary>
        /// Ons the command property changed.
        /// </summary>
        /// <param name="bindable">Bindable objects.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        /// <summary>
        /// Centers the map on pins and user location.
        /// </summary>
        /// <param name="latitudes">Latitudesi is used to pin on map.</param>
        /// <param name="longitudes">Longitudes is used to pin on map.</param>
        private void CenterMapOnPinsAndUserLocation(List<double> latitudes, List<double> longitudes)
        {
            double lowestLat = latitudes.Min();
            double highestLat = latitudes.Max();
            double lowestLong = longitudes.Min();
            double highestLong = longitudes.Max();
            double finalLat = (lowestLat + highestLat) / 2;
            double finalLong = (lowestLong + highestLong) / 2;
            double distance = DistanceCalculation.GeoCodeCalc.CalcDistance(lowestLat, lowestLong, highestLat, highestLong, DistanceCalculation.GeoCodeCalcMeasurement.Kilometers);

            this.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(finalLat, finalLong), Distance.FromKilometers(distance)));
        }
    }
}
