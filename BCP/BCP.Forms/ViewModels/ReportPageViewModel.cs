// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ReportPageViewModel.cs" company="Grosvenor">
// //   ${CopyrightHolder}
// // </copyright>
// // <summary>
// //   HomePageViewModel
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Core.Utils;
    using Prism.Commands;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Report page view model.
    /// </summary>
    public class ReportPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// The incident facade.
        /// </summary>
        private readonly IIncidentFacade incidentFacade;

        /// <summary>
        /// The user settings.
        /// </summary>
        private BCP.Common.Models.UserSettings userSettings;

        /// <summary>
        /// All groups.
        /// </summary>
        private ObservableCollection<IncidentCategoryGroup> allGroups;

        /// <summary>
        /// The filtered items.
        /// </summary>
        private ObservableCollection<IncidentType> filteredItems;

        /// <summary>
        /// The filtered groups.
        /// </summary>
        private ObservableCollection<IncidentCategoryGroup> filteredGroups;

        /// <summary>
        /// The expanded groups.
        /// </summary>
        private ObservableCollection<IncidentCategoryGroup> expandedGroups;

        /// <summary>
        /// The search filter.
        /// </summary>
        private string filterText = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.ReportPageViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="settingsFacade">Settings facade.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="incidentFacade">Incident facade.</param>
        public ReportPageViewModel(
            IPageDialogService dialogService,
            ISettingsFacade settingsFacade,
            INavigationService navigationService,
            IAuthenticationFacade authenticationFacade,
            IIncidentFacade incidentFacade)
            : base(dialogService, authenticationFacade)
        {
            this.navigationService = navigationService;
            this.incidentFacade = incidentFacade;
            this.settingsFacade = settingsFacade;
            this.Title = "Home Page";
            if (this.allGroups == null || this.allGroups.Count == 0)
            {
                this.ExecuteAsyncTask(this.LoadIncidentList);
            }
        }
            
        /// <summary>
        /// Gets the incident selected command.
        /// </summary>
        /// <value>The incident selected command.</value>
        public DelegateCommand<IncidentType> IncidentSelectedCommand => new DelegateCommand<IncidentType>(this.OnIncidentSelectedCommand);

        /// <summary>
        /// Gets or sets the expanded groups.
        /// </summary>
        /// <value>The expanded groups.</value>
        public ObservableCollection<IncidentCategoryGroup> ExpandedGroups
        {
            get { return this.expandedGroups; }
            set { this.SetProperty(ref this.expandedGroups, value); }
        }

        /// <summary>
        /// Gets or sets the search filter.
        /// </summary>
        /// <value>The search filter.</value>
        public string FilterText
        {
            get 
            { 
                return this.filterText; 
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    value = value.Trim().ToLower();

                    var filteredItms = this.allGroups.SelectMany(g => g.Where(i => i.Category.ToLower().Contains(value) || i.Description.ToLower().Contains(value)));
                    var filteredGrps = this.allGroups.Where(g => this.filteredItems.Any(fi => g.Contains(fi) || g.Title.ToLower().Contains(value)));
                    this.filteredItems = new ObservableCollection<IncidentType>(filteredItms);
                    this.filteredGroups = new ObservableCollection<IncidentCategoryGroup>(filteredGrps);
                }
                else if (this.allGroups != null)
                {
                    this.ResetFilteredItems();
                }

                bool propertyChanged = SetProperty(ref this.filterText, value);
                if (propertyChanged)
                {
                    this.UpdateListContent();
                }
            }
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        /// <summary>
        /// Loads the incident list.
        /// </summary>
        /// <returns>The incident list.</returns>
        private async Task LoadIncidentList()
        {
            this.userSettings = await this.settingsFacade.GetSettings();
            if (this.userSettings == null)
            {
                // show no result screen
                return;
            }

            var result = await this.incidentFacade.GetIncidentTypeList(this.userSettings.Location);
            if (result == null || !result.Any())
            {
                // show no result screen
                return;
            }

            var groups = result.GroupBy(x => x.Category);
            this.allGroups = new ObservableCollection<IncidentCategoryGroup>();
            foreach (var grp in groups)
            {
                var incGrp = new IncidentCategoryGroup(grp.Key.ToUpper());
                foreach (var item in grp)
                {
                    incGrp.Add(item);
                }

                this.allGroups.Add(incGrp);
            }

            this.ResetFilteredItems();
            this.UpdateListContent();
        }

        /// <summary>
        /// Resets the filtered items.
        /// </summary>
        private void ResetFilteredItems()
        {
            this.filteredGroups = this.allGroups;
            this.filteredItems = new ObservableCollection<IncidentType>(this.allGroups.SelectMany(g => g));
        }

        /// <summary>
        /// Ons the incident header selected command.
        /// </summary>
        /// <param name="incidentGroup">Incident group.</param>
        private void OnIncidentHeaderSelectedCommand(IncidentCategoryGroup incidentGroup)
        {
            int selectedIndex = this.expandedGroups.IndexOf(incidentGroup);
            this.filteredGroups[selectedIndex].Expanded = !this.filteredGroups[selectedIndex].Expanded;
            this.UpdateListContent();
        }

        /// <summary>
        /// Ons the incident selected command.
        /// </summary>
        /// <param name="incidentType">Incident type.</param>
        private void OnIncidentSelectedCommand(IncidentType incidentType)
        {
            var navParams = new NavigationParameters();
            navParams.Add("IncidentType", incidentType);
            this.navigationService.NavigateAsync("ReportDetailsPage", navParams, false, animated: false).Forget();
        }

        /// <summary>
        /// Updates the content of the list.
        /// </summary>
        private void UpdateListContent()
        {
            this.ExpandedGroups = new ObservableCollection<IncidentCategoryGroup>();
            foreach (IncidentCategoryGroup grp in this.filteredGroups)
            {
                ////Create new group so we do not alter original list
                IncidentCategoryGroup newGroup = new IncidentCategoryGroup(grp.Title, grp.Expanded);
                newGroup.IncidentGroupSelectedCommand = new DelegateCommand<IncidentCategoryGroup>(this.OnIncidentHeaderSelectedCommand);
                if (grp.Expanded)
                {
                    foreach (var listViewItem in grp.Where(i => this.filteredItems != null && this.filteredItems.Contains(i)))
                    {
                        newGroup.Add(listViewItem);
                    }
                }

                this.ExpandedGroups.Add(newGroup);
            }
        }
    }
}
