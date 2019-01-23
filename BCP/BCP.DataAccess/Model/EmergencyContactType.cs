//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="EmergencyContactType.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   EmergencyContactType.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Emergency contact type.
    /// </summary>
    public enum EmergencyContactType
    {
        /// <summary>
        /// The hospital.
        /// </summary>
        Hospital = 1,

        /// <summary>
        /// The fire station.
        /// </summary>
        [EnumMember(Value = "Fire Station")]
        FireStation = 2,

        /// <summary>
        /// The police station.
        /// </summary>
        [EnumMember(Value = "Police Station")]
        PoliceStation = 3
    }
}
