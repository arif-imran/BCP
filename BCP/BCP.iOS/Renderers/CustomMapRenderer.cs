//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CustomMapRenderer.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CustomMapRenderer.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using BCP.Forms.Controls;
using BCP.IOS.Renderers;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]

namespace BCP.IOS.Renderers
{
    /// <summary>
    /// Custom map renderer.
    /// </summary>
    public class CustomMapRenderer : MapRenderer
    {
        /// <summary>
        /// The pin identifier.
        /// </summary>
        private const string PinIdentifier = "CustomPin";

        /// <summary>
        /// The custom pin view.
        /// </summary>
        private UIView customPinView;

        /// <summary>
        /// The custom map.
        /// </summary>
        private CustomMap customMap;

        /// <summary>
        /// The custom pins.
        /// </summary>
        private List<CustomPin> customPins;

        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E param.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                if (nativeMap != null)
                {
                    nativeMap.RemoveAnnotations(nativeMap.Annotations);
                    nativeMap.GetViewForAnnotation = null;
                    nativeMap.DidSelectAnnotationView -= this.OnDidSelectAnnotationView;
                    nativeMap.DidDeselectAnnotationView -= this.OnDidSelectAnnotationView;
                }
            }

            if (e.NewElement != null)
            {
                this.customMap = (CustomMap)e.NewElement;
                var nativeMap = Control as MKMapView;
                this.customPins = this.customMap.CustomPins;

                nativeMap.GetViewForAnnotation = this.GetViewForAnnotation;
                nativeMap.DidSelectAnnotationView += this.OnDidSelectAnnotationView;
                nativeMap.DidDeselectAnnotationView += this.OnDidSelectAnnotationView;
            }
        }

        /// <summary>
        /// Gets the view for annotation.
        /// </summary>
        /// <returns>The view for annotation.</returns>
        /// <param name="mapView">Map view.</param>
        /// <param name="annotation">Annotation param.</param>
        private MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation is MKUserLocation)
            {
                return null;
            }

            var anno = annotation as MKPointAnnotation;
            if (anno == null)
            {
                return null;
            }

            var position = new Position(annotation.Coordinate.Latitude, annotation.Coordinate.Longitude);
            var customPin = this.customPins.FirstOrDefault(pin => pin.Pin.Position == position);

            annotationView = mapView.DequeueReusableAnnotation(customPin.Type.ToString());
            if (annotationView == null)
            {
                UIImage iconImage = null;
                if (customPin != null)
                {
                    switch (customPin.Type)
                    {
                        case DataAccess.Model.EmergencyContactType.Hospital:

                            iconImage = UIImage.FromFile("icon_map_hospital_green.png");
                            break;
                        case DataAccess.Model.EmergencyContactType.PoliceStation:

                            iconImage = UIImage.FromFile("icon_map_police_blue.png");
                            break;
                        case DataAccess.Model.EmergencyContactType.FireStation:

                            iconImage = UIImage.FromFile("icon_map_fire_red.png");
                            break;
                    }
                }

                annotationView = new MKAnnotationView(annotation, PinIdentifier)
                {
                    Image = iconImage
                };
            }

            annotationView.CanShowCallout = false;
            return annotationView;
        }

        // void OnCalloutAccessoryControlTapped(object sender, MKMapViewAccessoryTappedEventArgs e)
        // {
        //    var customView = e.View as CustomMKAnnotationView;
        //    if (!string.IsNullOrWhiteSpace(customView.Url))
        //    {
        //        UIApplication.SharedApplication.OpenUrl(new Foundation.NSUrl(customView.Url));
        //    }
        // }

        /// <summary>
        /// Ons the did select annotation view.
        /// </summary>
        /// <param name="sender">Sender param.</param>
        /// <param name="e">E param.</param>
        private void OnDidSelectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            var coordinates = e.View.Annotation.Coordinate;
            var selectedPin = this.customMap.CustomPins.Where(p => p.Pin.Position == new Position(coordinates.Latitude, coordinates.Longitude)).FirstOrDefault();
            this.customMap.PinTappedCommand.Execute(selectedPin);
        }

        /// <summary>
        /// Ons the did deselect annotation view.
        /// </summary>
        /// <param name="sender">Sender param.</param>
        /// <param name="e">E param.</param>
        private void OnDidDeselectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            this.customMap.PinDeselectedCommand.Execute(null);

            // if (!e.View.Selected)
            // {
            //    customPinView.RemoveFromSuperview();
            //    customPinView.Dispose();
            //    customPinView = null;
            // }
        }

        // CustomPin GetCustomPin(MKPointAnnotation annotation)
        // {
        //    var position = new Position(annotation.Coordinate.Latitude, annotation.Coordinate.Longitude);
        //    return customPins.FirstOrDefault(pin => pin.Pin.Position == position);
        // }
    }
}
