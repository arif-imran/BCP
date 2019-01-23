//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ReportPage.xaml.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ReportPage.xaml.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Views
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// Report page.
    /// </summary>
    public partial class ReportPage : ContentPage
    {
        /// <summary>
        /// The old text value.
        /// </summary>
        private string oldTextValue = "Filter By Keyword";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Views.ReportPage"/> class.
        /// </summary>
        public ReportPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Ons the appearing.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ////
            ////if (this.isFirstLoad)
            ////{
            ////    // Waiting some time
            ////    await Task.Delay(5);
            ////    // Start animation
            ////    await Task.WhenAll(
            ////        Logo.FadeTo(0, 200),
            ////        Task.Delay(100),
            ////        SplashGrid.FadeTo(0, 500)
            ////        );
            ////    this.isFirstLoad = false;
            ////}
            //// 
            this.searchImageButton.IsVisible = true;
            this.clearSearchButton.IsVisible = false;
            this.clearSearchButton.Opacity = 0;
            var clearTapperRecognizer = new TapGestureRecognizer();
            clearTapperRecognizer.Tapped += this.ClearSearchTapped;
            this.clearSearchButton.GestureRecognizers.Add(clearTapperRecognizer);
        }

        /// <summary>
        /// Searchs the text changed.
        /// </summary>
        /// <param name="sender">the Sender.</param>
        /// <param name="e">Event args </param>
        private void SearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                // hide clear button
                this.searchImageButton.FadeTo(1, 200, Easing.CubicOut);
                this.searchImageButton.IsVisible = true;
                this.clearSearchButton.FadeTo(0, 200, Easing.CubicIn);
                this.clearSearchButton.IsVisible = false;
            }
            else
            {
                // show clear button
                this.searchImageButton.FadeTo(0, 200, Easing.CubicOut);
                this.searchImageButton.IsVisible = false;
                this.clearSearchButton.FadeTo(1, 200, Easing.CubicIn);
                this.clearSearchButton.IsVisible = true;
            }
        }

        /// <summary>
        /// Clears the search tapped.
        /// </summary>
        /// <param name="sender">the Sender.</param>
        /// <param name="e">event args.</param>
        private void ClearSearchTapped(object sender, EventArgs e)
        {
            if (searchField.Text != (this.oldTextValue))
            {
                this.searchField.Text = string.Empty;
            }
        }
    }
}