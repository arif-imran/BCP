//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="NationalEmergencyNumber.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   NationalEmergencyNumber.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Model
{
    /// <summary>
    /// National emergency number.
    /// </summary>
    public class NationalEmergencyNumber
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BCP.DataAccess.Model.NationalEmergencyNumber"/> is police.
        /// </summary>
        /// <value><c>true</c> if is police; otherwise, <c>false</c>.</value>
        public bool IsPolice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BCP.DataAccess.Model.NationalEmergencyNumber"/> is fire.
        /// </summary>
        /// <value><c>true</c> if is fire; otherwise, <c>false</c>.</value>
        public bool IsFire { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BCP.DataAccess.Model.NationalEmergencyNumber"/> is ambulance.
        /// </summary>
        /// <value><c>true</c> if is ambulance; otherwise, <c>false</c>.</value>
        public bool IsAmbulance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BCP.DataAccess.Model.NationalEmergencyNumber"/> is
        /// health and safety executive.
        /// </summary>
        /// <value><c>true</c> if is health and safety executive; otherwise, <c>false</c>.</value>
        public bool IsHealthAndSafetyExecutive { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                string name = string.Empty;
                if (this.IsFire)
                {
                    name = "Fire service";
                }

                if (this.IsPolice)
                {
                    name = "Police service";
                }

                if (this.IsAmbulance)
                {
                    name = "Ambulance service";
                }

                if (this.IsFire && this.IsPolice && this.IsAmbulance)
                {
                    name = "Fire, Police and Ambulance service ";
                }

                if (this.IsFire && this.IsAmbulance)
                {
                    name = "Fire and Ambulance service";
                }

                return name;
            }
        }
    }
}