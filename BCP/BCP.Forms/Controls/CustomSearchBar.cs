//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CustomSearchBar.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CustomSearchBar.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Controls
{
    using Xamarin.Forms;

    /// <summary>
    /// Custom search bar.
    /// </summary>
    public class CustomSearchBar : SearchBar
    {
        //// Use Bindable properties to maintain XAML binding compatibility

        /// <summary>
        /// The search style property.
        /// </summary>
        public static readonly BindableProperty SearchStyleProperty = BindableProperty.Create<CustomSearchBar, string>(p => p.SearchStyle, "Default");

        /// <summary>
        /// The bar tint property.
        /// </summary>
        public static readonly BindableProperty BarTintProperty = BindableProperty.Create<CustomSearchBar, Color?>(p => p.BarTint, null);

        /// <summary>
        /// The bar style property.
        /// </summary>
        public static readonly BindableProperty BarStyleProperty = BindableProperty.Create<CustomSearchBar, string>(p => p.BarStyle, "Default");

        /// <summary>
        /// Gets or sets the bar tint.
        /// </summary>
        /// <value>The bar tint.</value>
        public Color? BarTint
        {
            get { return (Color?)GetValue(BarTintProperty); }
            set { this.SetValue(BarTintProperty, value); }
        }
             
        /// <summary>
        /// Gets or sets the search style.
        /// </summary>
        /// <value>The search style.</value>
        public string SearchStyle
        {
            get { return (string)GetValue(SearchStyleProperty); }
            set { this.SetValue(SearchStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the bar style.
        /// </summary>
        /// <value>The bar style.</value>
        public string BarStyle
        {
            get { return (string)GetValue(BarStyleProperty); }
            set { this.SetValue(BarStyleProperty, value); }
        }
    }
}
