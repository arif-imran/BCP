//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CallTreePageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CallTreePageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Facade.Facades;
    using BCP.Forms.Models;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Call tree page view model.
    /// </summary>
    public class CallTreePageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// The call tree facade.
        /// </summary>
        private readonly ICallTreeFacade callTreeFacade;

        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The call tree.
        /// </summary>
        private ObservableCollection<Grouping<string, Contact>> callTree;

        /// <summary>
        /// The user settings.
        /// </summary>
        private BCP.Common.Models.UserSettings userSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.CallTreePageViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="settingsFacade">Settings facade.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="callTreeFacade">Call tree facade.</param>
        public CallTreePageViewModel(IPageDialogService dialogService, ISettingsFacade settingsFacade, IAuthenticationFacade authenticationFacade, INavigationService navigationService, ICallTreeFacade callTreeFacade) : base(dialogService, authenticationFacade)
        {
            this.navigationService = navigationService;
            this.callTreeFacade = callTreeFacade;
            this.settingsFacade = settingsFacade;
            this.Title = "Call Tree";
        }

        /// <summary>
        /// Gets or sets the call tree.
        /// </summary>
        /// <value>The call tree.</value>
        public ObservableCollection<Grouping<string, Contact>> CallTree
        {
            get { return this.callTree; }
            set { this.SetProperty(ref this.callTree, value); }
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            this.ExecuteAsyncTask(this.LoadCallTree);
        }

        /// <summary>
        /// Loads the call tree.
        /// </summary>
        /// <returns>The call tree.</returns>
        private async Task LoadCallTree()
        {
            this.userSettings = await this.settingsFacade.GetSettings();
            if (this.userSettings == null)
            {
                //// show no result screen
                return;
            }

            var contacts = await this.callTreeFacade.GetCallTree(this.userSettings.Location);
            if (contacts == null || !contacts.Any())
            {
                //// show no result screen
                return;
            }

            var groupedContacts = contacts.OrderBy(c => c.FirstName).GroupBy(c => c.NameSort).Select(g => new Grouping<string, Contact>(g.Key, g));
            this.CallTree = new ObservableCollection<Grouping<string, Contact>>(groupedContacts);
        }
    }
}
