//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="HomeTabbedPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   HomeTabbedPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System;
    using BCP.Facade.Facades;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Home tabbed page view model.
    /// </summary>
    public class HomeTabbedPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The dialog service.
        /// </summary>
        private IPageDialogService dialogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.HomeTabbedPageViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        public HomeTabbedPageViewModel(
            IPageDialogService dialogService,
            INavigationService navigationService,
            IAuthenticationFacade authenticationFacade)
            : base(dialogService, authenticationFacade)
        {
            this.dialogService = dialogService;
        }
    }
}
