//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IncidentCategoryGroup.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IncidentCategoryGroup.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Input;
    using BCP.Common.Models;
    using Xamarin.Forms;

    /// <summary>
    /// Incident category group.
    /// </summary>
    public class IncidentCategoryGroup : ObservableCollection<IncidentType>, INotifyPropertyChanged
    {
        /// <summary>
        /// The expanded.
        /// </summary>
        private bool expanded;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.IncidentCategoryGroup"/> class.
        /// </summary>
        /// <param name="title">the Title.</param>
        /// <param name="expanded">If set to <c>true</c> expanded.</param>
        public IncidentCategoryGroup(string title, bool expanded = false)
        {
            this.Title = title;
            this.Expanded = expanded;
        }

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        protected new event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BCP.Forms.ViewModels.IncidentCategoryGroup"/> is expanded.
        /// </summary>
        /// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
        public bool Expanded
        {
            get
            {
                return this.expanded;
            }

            set
            {
                if (this.expanded != value)
                {
                    this.expanded = value;
                    this.OnPropertyChanged("Expanded");
                    this.OnPropertyChanged("StateIcon");
                }
            }
        }

        /// <summary>
        /// Gets the state icon.
        /// </summary>
        /// <value>The state icon.</value>
        public string StateIcon
        {
            get
            {
                return this.Expanded ? "icon_left_arrow.png" : "icon_down_arrow.png";
            }
        }

        /// <summary>
        /// Gets or sets the incident group selected command.
        /// </summary>
        /// <value>The incident group selected command.</value>
        public ICommand IncidentGroupSelectedCommand { get; set; }

        ////public static void ColourPicker()
        ////{
        ////    if indexPath,row == 0
        ////}

        /// <summary>
        /// Convert the specified value, targetType, parameter and culture.
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="value">the Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">the Parameter.</param>
        /// <param name="culture">the Culture.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color rowcolor = Color.Transparent;
            if (value == null || parameter == null)
            {
                return Color.White;
            }

            var index = ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value);
            if (index % 2 == 0)
            {
                rowcolor = Color.Pink;
            }

            return rowcolor;
        }

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