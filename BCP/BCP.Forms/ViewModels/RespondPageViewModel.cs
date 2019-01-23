//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="RespondPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   RespondPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Facade.Facades;
    using BCP.Forms.Services;
    using Grosvenor.Forms.Core.Utils;
    using Prism.Commands;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    /// <summary>
    /// Respond page view model.
    /// </summary>
    public class RespondPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The app linker.
        /// </summary>
        private readonly IAppLinker appLinker;

        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// The respond facade.
        /// </summary>
        private readonly IRespondFacade respondFacade;

        /// <summary>
        /// The useful tools.
        /// </summary>
        private List<Resource> usefulTools;

        /// <summary>
        /// The user settings.
        /// </summary>
        private BCP.Common.Models.UserSettings userSettings;

        /// <summary>
        /// The steps.
        /// </summary>
        private List<string> steps;

        /// <summary>
        /// The additional information.
        /// </summary>
        private string additionalInformation;

        /// <summary>
        /// The respond header.
        /// </summary>
        private string respondHeader;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.RespondPageViewModel"/> class.
        /// </summary>
        /// <param name="appLinker">App linker.</param>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="settingsFacade">Settings facade.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="respondFacade">Respond facade.</param>
        public RespondPageViewModel(
            IAppLinker appLinker,
            IPageDialogService dialogService,
            ISettingsFacade settingsFacade,
            INavigationService navigationService,
            IAuthenticationFacade authenticationFacade,
            IRespondFacade respondFacade)
            : base(dialogService, authenticationFacade)
        {
            this.navigationService = navigationService;
            this.settingsFacade = settingsFacade;
            this.respondFacade = respondFacade;
            this.appLinker = appLinker;
            this.ExecuteAsyncTask(this.LoadInstructions);
        }

        /// <summary>
        /// Gets or sets the steps.
        /// </summary>
        /// <value>The steps.</value>
        public List<string> Steps
        {
            get { return this.steps; }
            set { this.SetProperty(ref this.steps, value); }
        }

        /// <summary>
        /// Gets or sets the useful tool.
        /// </summary>
        /// <value>The useful tool.</value>
        public List<Resource> UsefulTool
        {
            get { return this.usefulTools; }
            set { this.SetProperty(ref this.usefulTools, value); }
        }

        /// <summary>
        /// Gets or sets the respond header.
        /// </summary>
        /// <value>The respond header.</value>
        public string RespondHeader
        {
            get { return this.respondHeader; }
            set { this.SetProperty(ref this.respondHeader, value); }
        }

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>The additional information.</value>
        public string AdditionalInformation
        {
            get { return this.additionalInformation; }
            set { this.SetProperty(ref this.additionalInformation, value); }
        }

        /// <summary>
        /// Gets the item tapped command.
        /// </summary>
        /// <value>The item tapped command.</value>
        public DelegateCommand<Resource> ItemTappedCommand => new DelegateCommand<Resource>(this.OnResourceSelected);

        /// <summary>
        /// Gets the select web view.
        /// </summary>
        /// <value>The select web view.</value>
        public DelegateCommand<string> SelectWebView => new DelegateCommand<string>(this.OnWebViewSelectedCommand);

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            this.ExecuteAsyncTask(this.LoadInstructions);
        }

        /// <summary>
        /// Ons the resource selected.
        /// </summary>
        /// <param name="resource">the Resource.</param>
        private void OnResourceSelected(Resource resource)
        {
            if (resource.Category == ResourceType.Documents)
            {
                this.ShowPdfDocumentInViewer(resource);
            }
            else
            {
                string fallBackURL = string.Empty;
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        fallBackURL = resource.IOSFallBackURL;
                        break;
                    case Device.Android:
                        fallBackURL = resource.AndroidFallBackURL;
                        break;
                    default:
                        break;
                }

                this.appLinker.OpenLink(resource.URL, fallBackURL);
            }
        }

        /// <summary>
        /// Shows the pdf document in viewer.
        /// </summary>
        /// <param name="resource">the Resource.</param>
        private void ShowPdfDocumentInViewer(Resource resource)
        {
            var navParams = new NavigationParameters();
            navParams.Add("Url", resource.URL);
            navParams.Add("Title", resource.Name);
            this.navigationService.NavigateAsync("PdfViewerPage", navParams, animated: false).Forget();
        }

        /// <summary>
        /// Ons the web view selected command.
        /// </summary>
        /// <param name="type">the Type.</param>
        private void OnWebViewSelectedCommand(string type)
        {
            this.navigationService.NavigateAsync("DetailWebViewPage", null, false, true).Forget();
        }

        /// <summary>
        /// Loads the instructions.
        /// </summary>
        /// <returns>The instructions.</returns>
        private async Task LoadInstructions()
        {
            this.userSettings = await this.settingsFacade.GetSettings();
            if (this.userSettings == null)
            {
                return;
            }

            var result = await this.respondFacade.GetRespondContent(this.userSettings.Role, this.userSettings.Location);
            if (result == null)
            {
                // show no result screen
                return;
            }

            this.RespondHeader = result.RespondHeader;
            if (result.UsefulTools != null)
            {
                this.UsefulTool = result.UsefulTools.ToList();
            }

            if (result.Flowchart != null)
            {
                this.Steps = result.Flowchart.ToList();
            }

            this.AdditionalInformation = result.AdditionalInformation;
        }
    }
}
