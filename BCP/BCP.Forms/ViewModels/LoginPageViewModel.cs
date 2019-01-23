// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LoginPageViewModel.cs" company="Grosvenor">
// //   ${CopyrightHolder}
// // </copyright>
// // <summary>
// //   LoginPageViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Core.Utils;
    using Prism.Commands;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Login page view model.
    /// </summary>
    public class LoginPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// The authentication facade.
        /// </summary>
        private readonly IAuthenticationFacade authenticationFacade;

        /// <summary>
        /// The username.
        /// </summary>
        private string username;

        /// <summary>
        /// The password.
        /// </summary>
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.LoginPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="dialogService">Dialog service.</param>
        public LoginPageViewModel(
            INavigationService navigationService,
            IAuthenticationFacade authenticationFacade,
            IPageDialogService dialogService)
            : base(dialogService, authenticationFacade)
        {
            this.authenticationFacade = authenticationFacade;
            this.navigationService = navigationService;
            this.LoginCommand = new DelegateCommand(() => { this.ExecuteAsyncTask(this.LoginAction).Forget(); })
                .ObservesCanExecute(() => this.CanLogin)
                .ObservesProperty(() => this.Username)
                .ObservesProperty(() => this.Password);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:BCP.Forms.ViewModels.LoginPageViewModel"/> can login.
        /// </summary>
        /// <value><c>true</c> if can login; otherwise, <c>false</c>.</value>
        public bool CanLogin
        {
            get
            {
                return !string.IsNullOrEmpty(this.Username) && !string.IsNullOrEmpty(this.Password);
            }
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.SetProperty(ref this.username, value);
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.SetProperty(ref this.password, value);
            }
        }

        /// <summary>
        /// Gets or sets the login command.
        /// </summary>
        /// <value>The login command.</value>
        public ICommand LoginCommand 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Ons the navigated from.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigating to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        /// <summary>
        /// Logins the action.
        /// </summary>
        /// <returns>The action.</returns>
        private async Task LoginAction()
        {
            this.authenticationFacade.LoginAsync(this.Username, this.Password);

            this.navigationService.NavigateAsync("MainMasterDetailPage/NavigationPage/HomeTabbedPage/ReportPage", animated: false).Forget();
        }
    }
}
