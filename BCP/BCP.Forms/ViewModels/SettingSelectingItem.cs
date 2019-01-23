//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="SettingSelectingItem.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   SettingSelectingItem.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms
{
    using Prism.Mvvm;

    /// <summary>
    /// Setting selecting item.
    /// </summary>
    public class SettingSelectingItem : BindableBase
    {
        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The isselected.
        /// </summary>
        private bool isselected;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BCP.Forms.SettingSelectingItem"/> is selected.
        /// </summary>
        /// <value><c>true</c> if is selected; otherwise, <c>false</c>.</value>
        public bool IsSelected
        {
            get { return this.isselected; }
            set { this.SetProperty(ref this.isselected, value); }
        }
    }
}
