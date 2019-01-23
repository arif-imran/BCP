//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ResourceGroup.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ResourceGroup.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------
namespace BCP.Forms.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using BCP.Common.Models;

    /// <summary>
    /// Resource group.
    /// </summary>
    public class ResourceGroup : ObservableCollection<Resource>, INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category
        {
            get;
            set;
        }

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
