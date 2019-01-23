//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="DistanceCalculation.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   DistanceCalculation.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Helpers
{
    using System;

    /// <summary>
    /// Distance calculation.
    /// </summary>
    public class DistanceCalculation
    {
        /// <summary>
        /// Geo code calculate measurement.
        /// </summary>
        public enum GeoCodeCalcMeasurement : int
        {
            /// <summary>
            /// The miles.
            /// </summary>
            Miles = 0,

            /// <summary>
            /// The kilometers.
            /// </summary>
            Kilometers = 1
        }

        /// <summary>
        /// Geo code calculate.
        /// </summary>
        public static class GeoCodeCalc
        {
            /// <summary>
            /// The earth radius in miles.
            /// </summary>
            public const double EarthRadiusInMiles = 3956.0;

            /// <summary>
            /// The earth radius in kilometers.
            /// </summary>
            public const double EarthRadiusInKilometers = 6367.0;

            /// <summary>
            /// Tos the radian.
            /// </summary>
            /// <returns>The radian.</returns>
            /// <param name="val">the Value.</param>
            public static double ToRadian(double val)
            {
                return val * (Math.PI / 180);
            }

            /// <summary>
            /// Diffs the radian.
            /// </summary>
            /// <returns>The radian.</returns>
            /// <param name="val1">Val 1.</param>
            /// <param name="val2">Val 2.</param>
            public static double DiffRadian(double val1, double val2)
            {
                return ToRadian(val2) - ToRadian(val1);
            }

            /// <summary>
            /// Calculates the distance.
            /// </summary>
            /// <returns>The distance.</returns>
            /// <param name="lat1">Lat 1.</param>
            /// <param name="lng1">Lng 1.</param>
            /// <param name="lat2">Lat 2.</param>
            /// <param name="lng2">Lng 2.</param>
            public static double CalcDistance(double lat1, double lng1, double lat2, double lng2)
            {
                return CalcDistance(lat1, lng1, lat2, lng2, GeoCodeCalcMeasurement.Miles);
            }

            /// <summary>
            /// Calculates the distance.
            /// </summary>
            /// <returns>The distance.</returns>
            /// <param name="lat1">Lat 1.</param>
            /// <param name="lng1">Lng 1.</param>
            /// <param name="lat2">Lat 2.</param>
            /// <param name="lng2">Lng 2.</param>
            /// <param name="m">the M.</param>
            public static double CalcDistance(double lat1, double lng1, double lat2, double lng2, GeoCodeCalcMeasurement m)
            {
                double radius = GeoCodeCalc.EarthRadiusInMiles;

                if (m == GeoCodeCalcMeasurement.Kilometers)
                {
                    radius = GeoCodeCalc.EarthRadiusInKilometers;
                }

                return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lng1, lng2)) / 2.0), 2.0)))));
            }
        }
    }
}