// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="BaseViewModel.cs" company="Grosvenor">
// //   ${CopyrightHolder}
// // </copyright>
// // <summary>
// //   BaseViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Ui.ViewModels;
    using Prism.Services;

    /// <summary>
    /// Base view model.
    /// </summary>
    public class BaseViewModel : GrosvenorBaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.BaseViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        public BaseViewModel(IPageDialogService dialogService, IAuthenticationFacade authenticationFacade) : base(dialogService)
        {
            this.AuthenticationFacade = authenticationFacade;
            this.DialogService = dialogService;
        }

        /// <summary>
        /// Gets or sets the authentication facade.
        /// </summary>
        /// <value>The authentication facade.</value>
        protected IAuthenticationFacade AuthenticationFacade { get; set; }
    }
}
