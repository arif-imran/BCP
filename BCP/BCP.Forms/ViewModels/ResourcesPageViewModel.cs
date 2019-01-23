//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ResourcesPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ResourcesPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Facade.Facades;
    using BCP.Forms.Models;
    using BCP.Forms.Services;
    using Grosvenor.Forms.Core.Utils;
    using Prism.Commands;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    /// <summary>
    /// Resources page view model.
    /// </summary>
    public class ResourcesPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The resource groups.
        /// </summary>
        private ObservableCollection<ResourceGroup> resourceGroups;

        /// <summary>
        /// Gets or sets the resource groups.
        /// </summary>
        /// <value>The resource groups.</value>
        public ObservableCollection<ResourceGroup> ResourceGroups
        {
            get { return this.resourceGroups; }
            set { this.SetProperty(ref this.resourceGroups, value); }
        }

        /// <summary>
        /// The resources facade.
        /// </summary>
        private readonly IResourcesFacade resourcesFacade;

        /// <summary>
        /// The app linker.
        /// </summary>
        private readonly IAppLinker appLinker;

        /// <summary>
        /// The app resources.
        /// </summary>
        private List<Resource> appResources;

        /// <summary>
        /// The link resources.
        /// </summary>
        private List<Resource> linkResources;

        /// <summary>
        /// The document resources.
        /// </summary>
        private List<Resource> documentResources;

        /// <summary>
        /// The resourcesitem.
        /// </summary>
        private Resource resourcesitem;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private INavigationService navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.ResourcesPageViewModel"/> class.
        /// </summary>
        /// <param name="appLinker">App linker.</param>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="resourcesFacade">Resources facade.</param>
        public ResourcesPageViewModel(
            IAppLinker appLinker,
            IPageDialogService dialogService,
            INavigationService navigationService,
            IAuthenticationFacade authenticationFacade,
            IResourcesFacade resourcesFacade)
            : base(dialogService, authenticationFacade)
        {
            this.navigationService = navigationService;
            this.resourcesFacade = resourcesFacade;
            this.ExecuteAsyncTask(async () => { await this.LoadResources(); }).Forget();
            this.appLinker = appLinker;
            this.ResourcesItem = new Resource();
        }

        /// <summary>
        /// Gets or sets the resources item.
        /// </summary>
        /// <value>The resources item.</value>
        public Resource ResourcesItem
        {
            get { return this.resourcesitem; }
            set { this.SetProperty(ref this.resourcesitem, value); }
        }

        /// <summary>
        /// Gets or sets the app resources.
        /// </summary>
        /// <value>The app resources.</value>
        public List<Resource> AppResources
        {
            get { return this.appResources; }
            set { this.SetProperty(ref this.appResources, value); }
        }

        /// <summary>
        /// Gets or sets the link resources.
        /// </summary>
        /// <value>The link resources.</value>
        public List<Resource> LinkResources
        {
            get { return this.linkResources; }
            set { this.SetProperty(ref this.linkResources, value); }
        }

        /// <summary>
        /// Gets or sets the document resources.
        /// </summary>
        /// <value>The document resources.</value>
        public List<Resource> DocumentResources
        {
            get { return this.documentResources; }
            set { this.SetProperty(ref this.documentResources, value); }
        }

        /// <summary>
        /// Gets the item tapped command.
        /// </summary>
        /// <value>The item tapped command.</value>
        public DelegateCommand<Resource> ItemTappedCommand => new DelegateCommand<Resource>(this.OnResourceSelected);

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
        /// Loads the resources.
        /// </summary>
        /// <returns>The resources.</returns>
        private async Task LoadResources()
        {
            var result = await this.resourcesFacade.GetResources();

            if (result == null || !result.Any())
            {
                // show no result screen
                return;
            }

            this.LinkResources = result.Where(x => x.Category == ResourceType.Link).ToList();
            this.DocumentResources = result.Where(x => x.Category == ResourceType.Documents).ToList();
            this.AppResources = result.Where(x => x.Category == ResourceType.Apps).ToList();

            ResourceGroup grpLink = new ResourceGroup()
            {
                Category = "Links"
            };

            ResourceGroup grpApp = new ResourceGroup()
            {
                Category = "Apps"
            };

            ResourceGroup grpDocument = new ResourceGroup()
            {
                Category = "Documents"
            };

            foreach (var e in this.LinkResources)
            {
                grpLink.Add(e);
            }

            foreach (var e in this.AppResources)
            {
                grpApp.Add(e);
            }

            foreach (var e in this.DocumentResources)
            {
                grpDocument.Add(e);
            }

            this.ResourceGroups = new ObservableCollection<ResourceGroup>();
            this.ResourceGroups.Add(grpLink);
            this.ResourceGroups.Add(grpApp);
            this.ResourceGroups.Add(grpDocument);
        }
    }
}
