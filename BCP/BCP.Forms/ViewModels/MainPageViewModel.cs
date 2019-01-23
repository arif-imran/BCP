//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="MainPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   MainPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using Prism.Mvvm;
    using Prism.Navigation;

    /// <summary>
    /// Main page view model.
    /// </summary>
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        /// <summary>
        /// The title.
        /// </summary>
        private string title;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }

        /// <summary>
        /// Ons the navigated from.
        /// </summary>
        /// <param name="parameters"> the Parameters.</param>
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
            {
                this.Title = (string)parameters["title"] + " and Prism";
            }
        }

        /// <summary>
        /// Ons the navigating to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}