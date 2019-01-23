//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="SettingSelectionPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   SettingSelectionPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using BCP.Common;
    using BCP.Common.Models;
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Core.Utils;
    using Plugin.Connectivity;
    using Prism.Commands;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Setting selection page view model.
    /// </summary>
    public class SettingSelectionPageViewModel : NavigationBaseViewModel
    {
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
        /// The user settings.
        /// </summary>
        private UserSettings userSettings;

        /// <summary>
        /// The type of the current.
        /// </summary>
        private string currentType;

        /// <summary>
        /// The selected location.
        /// </summary>
        private string selectedLocation;

        /// <summary>
        /// The is location or role changed.
        /// </summary>
        private bool isLocationOrRoleChanged;

        /// <summary>
        /// The selected role.
        /// </summary>
        private string selectedRole;

        /// <summary>
        /// The roles.
        /// </summary>
        private ObservableCollection<string> roles;

        /// <summary>
        /// The locations.
        /// </summary>
        private ObservableCollection<string> locations;

        /// <summary>
        /// The settingse item.
        /// </summary>
        private ObservableCollection<SettingSelectingItem> settingseItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.SettingSelectionPageViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="userFacade">User facade.</param>
        /// <param name="settingsFacade">Settings facade.</param>
        public SettingSelectionPageViewModel(
            IPageDialogService dialogService,
            INavigationService navigationService,
            IAuthenticationFacade authenticationFacade,
            IUserFacade userFacade,
            ISettingsFacade settingsFacade)
            : base(dialogService, authenticationFacade)
        {
            this.navigationService = navigationService;
            this.userFacade = userFacade;
            this.settingsFacade = settingsFacade;
        }

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>The locations.</value>
        public ObservableCollection<string> Locations
        {
            get { return this.locations; }
            set { this.SetProperty(ref this.locations, value); }
        }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public ObservableCollection<string> Roles
        {
            get { return this.roles; }
            set { this.SetProperty(ref this.roles, value); }
        }

        /// <summary>
        /// Gets or sets the setting item.
        /// </summary>
        /// <value>The setting item.</value>
        public ObservableCollection<SettingSelectingItem> SettingItem
        {
            get { return this.settingseItem; }
            set { this.SetProperty(ref this.settingseItem, value); }
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
        /// Gets the item tapped command.
        /// </summary>
        /// <value>The item tapped command.</value>
        public DelegateCommand<SettingSelectingItem> ItemTappedCommand => new DelegateCommand<SettingSelectingItem>(this.SettingsSelection);

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            this.currentType = Convert.ToString(parameters["type"]);
            this.ExecuteAsyncTask(async () => { await this.GetSettingsLists(); }).Forget();
        }

        /// <summary>
        /// Settingses the selection.
        /// </summary>
        /// <param name="settingSlectingItem">Setting slecting item.</param>
        private async void SettingsSelection(SettingSelectingItem settingSlectingItem)
        {
            this.isLocationOrRoleChanged = false;

            if (CrossConnectivity.Current.IsConnected)
            {
                switch (this.currentType)
                {
                    case "Location":
                        if (this.userSettings.Location != settingSlectingItem.Name)
                        {
                            this.userSettings.Location = settingSlectingItem.Name;
                            await this.settingsFacade.SaveSettings(this.userSettings);
                            this.isLocationOrRoleChanged = true;
                        }

                        break;
                    case "Role":
                        if (this.userSettings.Role != settingSlectingItem.Name)
                        {
                            this.userSettings.Role = settingSlectingItem.Name;
                            await this.settingsFacade.SaveSettings(this.userSettings);
                            this.isLocationOrRoleChanged = true;
                        }

                        break;
                    default:
                        break;
                }
            }
            else
            {
                await DialogService.DisplayAlertAsync("Error", "Please check your internet connection and try again.", "OK");
            }

            var navIsChanged = new NavigationParameters
            {
                { "isLocOrRoleChanged", this.isLocationOrRoleChanged }
            };
            await this.navigationService.GoBackAsync(navIsChanged);
        }

        /// <summary>
        /// Gets the settings lists.
        /// </summary>
        /// <returns>The settings lists.</returns>
        private async Task GetSettingsLists()
        {
            this.SettingItem = new ObservableCollection<SettingSelectingItem>();
            this.userSettings = await this.settingsFacade.GetSettings();
            if (this.userSettings == null)
            {
                // show no result screen
                return;
            }

            this.SelectedLocation = this.userSettings.Location;
            this.SelectedRole = this.userSettings.Role;
            switch (this.currentType)
            {
                case "Location":
                    this.Title = "Select Location";
                    var allLocation = await this.userFacade.GetAllUserLocations();
                    if (allLocation == null || !allLocation.Any())
                    {
                        // show no result screen
                        return;
                    }

                    allLocation = allLocation.OrderBy(l => l);
                    ////SettingItem.Add(new SettingSelectingItem() { Name = Constants.SelectLocation, IsSelected = false });

                    foreach (var loc in allLocation)
                    {
                        this.SettingItem.Add(new SettingSelectingItem() { Name = loc, IsSelected = loc == this.SelectedLocation });
                    }

                    break;
                case "Role":
                    this.Title = "Select Role";
                    var allRoles = await this.userFacade.GetAllUserRoles();
                    if (allRoles == null || !allRoles.Any())
                    {
                        // show no result screen
                        return;
                    }

                    allRoles = allRoles.OrderBy(r => r);

                    this.SettingItem.Add(new SettingSelectingItem() { Name = Constants.DefaultRole, IsSelected = false });

                    foreach (var loc in allRoles)
                    {
                        this.SettingItem.Add(new SettingSelectingItem() { Name = loc, IsSelected = loc == this.SelectedRole });
                    }

                    if (!this.SettingItem.Any(x => x.IsSelected == true))
                    {
                        this.SettingItem[0].IsSelected = true;
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
