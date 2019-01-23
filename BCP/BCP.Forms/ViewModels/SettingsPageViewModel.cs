//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="SettingsPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   SettingsPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Threading.Tasks;
    using BCP.Common.Events;
    using BCP.Common.Models;
    using BCP.Common.Services;
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Core.Utils;
    using Plugin.Connectivity;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Settings page view model.
    /// </summary>
    public class SettingsPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly IConnectivityService connectivityService;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// The user facade.
        /// </summary>
        private readonly IUserFacade userFacade;

        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The data fetcher service.
        /// </summary>
        private readonly IDataFetcherService dataFetcherService;

        /// <summary>
        /// The event aggregator.
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The user settings.
        /// </summary>
        private UserSettings userSettings;

        /// <summary>
        /// The selected location.
        /// </summary>
        private string selectedLocation;

        /// <summary>
        /// The selected role.
        /// </summary>
        private string selectedRole;

        public SettingsPageViewModel(IPageDialogService dialogService,
                                     INavigationService navigationService,
                                     ISettingsFacade settingsFacade,
                                     IAuthenticationFacade authenticationFacade,
                                     IUserFacade userFacade,
                                     IDataFetcherService dataFetcherService,
                                     IEventAggregator eventAggregator,
                                     IConnectivityService connectivityService)

            : base(dialogService, authenticationFacade)
        {
            this.navigationService = navigationService;
            this.settingsFacade = settingsFacade;
            this.userFacade = userFacade;
            this.Title = "Settings";
            this.dataFetcherService = dataFetcherService;
            this.connectivityService = connectivityService;
        }


        /// <summary>
        /// Gets or sets the selected location.
        /// </summary>
        /// <value>The selected location.</value>
        public string SelectedLocation
        {
            get
            {
                return this.selectedLocation;
            }

            set
            {
                bool isChanged = this.SetProperty(ref this.selectedLocation, value);
            }
        }

        /// <summary>
        /// Gets the refresh command.
        /// </summary>
        /// <value>The refresh command.</value>
        public DelegateCommand RefreshCommand => new DelegateCommand(this.OnRefreshCommand);

        /// <summary>
        /// Gets the setting select.
        /// </summary>
        /// <value>The setting select.</value>
        public DelegateCommand<string> SettingSelect => new DelegateCommand<string>(this.OnSettingSelectedCommand);

        /// <summary>
        /// Gets or sets the selected role.
        /// </summary>
        /// <value>The selected role.</value>
        public string SelectedRole
        {
            get
            {
                return this.selectedRole;
            }

            set
            {
                bool isChanged = this.SetProperty(ref this.selectedRole, value);
            }
        }

        /// <summary>
        /// Ons the setting selected command.
        /// </summary>
        /// <param name="type">the Type.</param>
        public void OnSettingSelectedCommand(string type)
        {
            var navParams = new NavigationParameters();
            this.navigationService.NavigateAsync("SettingSelectionPage?type=" + type, navParams, false, animated: false).Forget();
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            this.ExecuteAsyncTask(async () =>
            {
                await this.PopulateSettings();

                if (parameters != null && parameters.ContainsKey("isLocOrRoleChanged"))
                {
                    var hasSettingsChanged = parameters.GetValue<bool>("isLocOrRoleChanged");

                    if (hasSettingsChanged)
                    {
                        this.eventAggregator.GetEvent<LocationOrRoleChangedEvent>().Publish();
                        await this.dataFetcherService.LocationOrRoleChangedHandler(false);
                    }
                }
            }).Forget();
        }

        /// <summary>
        /// Populates the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        private async Task PopulateSettings()
        {
            this.userSettings = await this.settingsFacade.GetSettings();
            if (this.userSettings == null)
            {
                // show no result screen
                return;
            }

            this.SelectedLocation = this.userSettings.Location;
            this.SelectedRole = this.userSettings.Role;
        }

        /// <summary>
        /// Ons the refresh command.
        /// </summary>
        private async void OnRefreshCommand()
        {
            if (this.connectivityService.Instance.IsConnected)
            {
                await this.ExecuteAsyncTask(() => this.dataFetcherService.LocationOrRoleChangedHandler(true));

                this.eventAggregator.GetEvent<LocationOrRoleChangedEvent>().Publish();

                await this.DialogService.DisplayAlertAsync("All Content", "Refresh Complete", "Cancel");
            }
            else
            {
                await this.DialogService.DisplayAlertAsync("Error", "Please check your internet connection and try again.", "OK");
            }
        }
    }
}