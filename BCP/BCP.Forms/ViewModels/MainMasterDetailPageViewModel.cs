//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="MainMasterDetailPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   MainMasterDetailPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using BCP.Common;
    using BCP.Common.Events;
    using BCP.Common.Models;
    using BCP.Common.Services;
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Core.Utils;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Version.Plugin;

    /// <summary>
    /// Main master detail page view model.
    /// </summary>
    public class MainMasterDetailPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        ///     The navigation service.
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The event aggregator.
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The data fetcher service.
        /// </summary>
        private readonly IDataFetcherService dataFetcherService;

        /// <summary>
        ///     The username.
        /// </summary>
        private string username;

        /// <summary>
        /// The user settings.
        /// </summary>
        private UserSettings userSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.MainMasterDetailPageViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="dataFetcherService">Data fetcher service.</param>
        /// <param name="settingsFacade">Settings facade.</param>
        /// <param name="eventAggregator">Event aggregator.</param>
        public MainMasterDetailPageViewModel(
            IPageDialogService dialogService,
            INavigationService navigationService,
            IAuthenticationFacade authenticationFacade,
            IDataFetcherService dataFetcherService,
            ISettingsFacade settingsFacade,
            IEventAggregator eventAggregator)
            : base(dialogService, authenticationFacade)
        {
            this.navigationService = navigationService;
            this.settingsFacade = settingsFacade;
            this.eventAggregator = eventAggregator;
            this.dataFetcherService = dataFetcherService;
            this.ExecuteAsyncTask(this.UpdateUserSettings).Forget();

            this.LogoutCommand = new DelegateCommand(() => { this.ExecuteAsyncTask(this.LogoutAction).Forget(); });

            this.ReportCommand = new DelegateCommand(() =>
            {
                this.ExecuteAsyncTask(this.LoadReportPage).Forget();
            });

            this.RespondCommand = new DelegateCommand(() =>
            {
                this.ExecuteAsyncTask(this.LoadRespondPage).Forget();
            });

            this.CallTreeCommand = new DelegateCommand(() =>
            {
                this.ExecuteAsyncTask(this.LoadCallTreePage).Forget();
            });

            this.ContactsCommand = new DelegateCommand(() =>
            {
                this.ExecuteAsyncTask(this.LoadContactsPage).Forget();
            });

            this.ResourcesCommand = new DelegateCommand(() =>
            {
                this.ExecuteAsyncTask(this.LoadResourcesPage).Forget();
            });

            this.FullBCPDocumentCommand = new DelegateCommand(() =>
            {
                this.ExecuteAsyncTask(this.LoadFullBCPDocumentPage).Forget();
            });

            this.GetRefreshCommand = new DelegateCommand(() =>
            {
                this.ExecuteAsyncTask(this.LoadRefreshContentPage).Forget();
            });

            this.SettingsCommand = new DelegateCommand(() =>
            {
                this.ExecuteAsyncTask(this.LoadSettingsPage).Forget();
            });
            this.eventAggregator.GetEvent<LocationOrRoleChangedEvent>().Subscribe(this.UpdateUserLocation, ThreadOption.BackgroundThread);
        }

        /// <summary>
        /// Gets or sets the user settings.
        /// </summary>
        /// <value>The user settings.</value>
        public UserSettings UserSettings
        {
            get
            {
                return this.userSettings;
            }

            set
            {
                this.SetProperty(ref this.userSettings, value);
            }
        }

        /// <summary>
        /// Gets the app version.
        /// </summary>
        /// <value>The app version.</value>
        public string AppVersion
        {
            get
            {
                string versionNumber = CrossVersion.Current.Version;
                var versionArray = versionNumber.Split('.');
                string lastNumber = versionArray.Last();
                string formattedLastNumber = $"({lastNumber})";
                versionArray[versionArray.Count() - 1] = formattedLastNumber;
                string newVersion = string.Join(".", versionArray);
                newVersion = newVersion.Remove(newVersion.LastIndexOf('.'), 1);
                var completedVersion = "Current Version:" + newVersion;

                return completedVersion;
            }
        }

        /// <summary>
        /// Gets or sets the report command.
        /// </summary>
        /// <value>The report command.</value>
        public ICommand ReportCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the respond command.
        /// </summary>
        /// <value>The respond command.</value>
        public ICommand RespondCommand { get; set; }

        /// <summary>
        /// Gets or sets the call tree command.
        /// </summary>
        /// <value>The call tree command.</value>
        public ICommand CallTreeCommand { get; set; }

        /// <summary>
        /// Gets or sets the contacts command.
        /// </summary>
        /// <value>The contacts command.</value>
        public ICommand ContactsCommand { get; set; }

        /// <summary>
        /// Gets or sets the resources command.
        /// </summary>
        /// <value>The resources command.</value>
        public ICommand ResourcesCommand { get; set; }

       

        /// <summary>
        /// Gets or sets the full BCPD ocument command.
        /// </summary>
        /// <value>The full BCPD ocument command.</value>
        public ICommand FullBCPDocumentCommand { get; set; }

        /// <summary>
        /// Gets or sets the settings command.
        /// </summary>
        /// <value>The settings command.</value>
        public ICommand SettingsCommand { get; set; }

        /// <summary>
        /// Gets or sets the get refresh command.
        /// </summary>
        /// <value>The get refresh command.</value>
        public ICommand GetRefreshCommand { get; set; }

        /// <summary>
        ///     Gets or sets the logout command.
        /// </summary>
        /// <value>The logout command.</value>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        ///     Gets or sets the username.
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
        /// Updates the user settings.
        /// </summary>
        /// <returns>The user settings.</returns>
        public async Task UpdateUserSettings()
        {
            var user = await this.settingsFacade.GetUserName();
            this.Username = user;
            this.UserSettings = await this.settingsFacade.GetSettings();
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        /// <summary>
        /// Loads the report page.
        /// </summary>
        /// <returns>The report page.</returns>
        private async Task LoadReportPage()
        {
            await this.navigationService.NavigateAsync("NavigationPage/HomeTabbedPage/ReportPage", animated: false);
        }

        /// <summary>
        /// Loads the respond page.
        /// </summary>
        /// <returns>The respond page.</returns>
        private async Task LoadRespondPage()
        {
            await this.navigationService.NavigateAsync("NavigationPage/HomeTabbedPage/RespondPage", animated: false);
        }

        /// <summary>
        /// Loads the call tree page.
        /// </summary>
        /// <returns>The call tree page.</returns>
        private async Task LoadCallTreePage()
        {
            await this.navigationService.NavigateAsync("NavigationPage/CallTreePage", animated: false);
        }

        /// <summary>
        /// Loads the contacts page.
        /// </summary>
        /// <returns>The contacts page.</returns>
        private async Task LoadContactsPage()
        {
            await this.navigationService.NavigateAsync("NavigationPage/HomeTabbedPage/ContactsPage", animated: false);
        }

        /// <summary>
        /// Loads the resources page.
        /// </summary>
        /// <returns>The resources page.</returns>
        private async Task LoadResourcesPage()
        {
            await this.navigationService.NavigateAsync("NavigationPage/ResourcesPage", animated: false);
        }

        /// <summary>
        /// Loads the refresh content page.
        /// </summary>
        /// <returns>The refresh content page.</returns>
        private async Task LoadRefreshContentPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("IsInitialLoad", false);
            await this.navigationService.NavigateAsync("NavigationPage/RefreshContentPage", navParams, animated: false);
        }

        /// <summary>
        /// Loads the full BCPD ocument page.
        /// </summary>
        /// <returns>The full BCPD ocument page.</returns>
        private async Task LoadFullBCPDocumentPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("Title", "BCP Document");
            await this.navigationService.NavigateAsync("NavigationPage/PdfViewerPage", navParams, animated: false);
        }



        /// <summary>
        /// Loads the settings page.
        /// </summary>
        /// <returns>The settings page.</returns>
        private async Task LoadSettingsPage()
        {
            await this.navigationService.NavigateAsync("NavigationPage/SettingsPage", animated: false);
        }

        /// <summary>
        ///     Logout the action.
        /// </summary>
        /// <returns>The action.</returns>
        private async Task LogoutAction()
        {
            var result = await this.DialogService.DisplayAlertAsync(
                             Constants.LogoutMessageTitle,
                             Constants.LogoutMessage,
                             Constants.LogoutMessageConfirm,
                             Constants.LogoutMessageCancel);

            if (result)
            {
                await this.navigationService.NavigateAsync("LoginPage", animated: false);
            }
        }

        /// <summary>
        /// Updates the user location.
        /// </summary>
        private void UpdateUserLocation()
        {
            this.UpdateUserSettings().Forget();
        }
    }
}