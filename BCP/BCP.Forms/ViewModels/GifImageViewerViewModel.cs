//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="GifImageViewerViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   GifImageViewerViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Windows.Input;
    using BCP.Facade.Facades;
    using Prism.Commands;
    using Prism.Services;

    /// <summary>
    /// GIF image viewer view model.
    /// </summary>
    public class GifImageViewerViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The button title.
        /// </summary>
        private string buttonTitle = "Start";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.GifImageViewerViewModel"/> class.
        /// </summary>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="dialogService">Dialog service.</param>
        public GifImageViewerViewModel(
            IAuthenticationFacade authenticationFacade,
            IPageDialogService dialogService)
        : base(dialogService, authenticationFacade)
        {
            this.Animate = new DelegateCommand(() =>
            {
                this.IsBusy = !this.IsBusy;
                ButtonTitle = buttonTitle == "Start" ? "End" : "Start";
            });
        }

        /// <summary>
        /// Gets or sets the animate.
        /// </summary>
        /// <value>The animate.</value>
        public ICommand Animate { get; set; }

        /// <summary>
        /// Gets or sets the button title.
        /// </summary>
        /// <value>The button title.</value>
        public string ButtonTitle
        {
            get
            {
                return this.buttonTitle;
            }

            set
            {
                this.SetProperty(ref this.buttonTitle, value);
            }
        }
    }
}
