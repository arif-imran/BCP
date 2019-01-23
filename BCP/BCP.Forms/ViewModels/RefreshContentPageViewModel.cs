//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="RefreshContentPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   RefreshContentPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Threading.Tasks;
    using BCP.Common.Events;
    using BCP.Common.Services;
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Core.Utils;
    using Plugin.Connectivity;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Refresh content page view model.
    /// </summary>
    public class RefreshContentPageViewModel : NavigationBaseViewModel
    {
		/// <summary>
		/// The data fetcher service.
		/// </summary>
        private readonly IConnectivityService connectivityService;

        /// <summary>
        /// The data fetcher service.
        /// </summary>
        private readonly IDataFetcherService dataFetcherService;

        /// <summary>
        /// The event aggregator.
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// The message.
        /// </summary>
        private string message;


        public RefreshContentPageViewModel(IPageDialogService dialogService, IDataFetcherService dataFetcherService,
                                           INavigationService navigationService,
                                           IAuthenticationFacade authenticationFacade,IConnectivityService connectivityService,
                                           IEventAggregator eventAggregator) : base(dialogService, authenticationFacade)

        {
            this.Title = "RefreshContentPage";
            this.dataFetcherService = dataFetcherService;
            this.eventAggregator = eventAggregator;
            this.navigationService = navigationService;
            this.connectivityService = connectivityService;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.SetProperty(ref this.message, value);
            }
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            bool isInitialLoad = (bool)parameters["IsInitialLoad"];

            if (isInitialLoad)
            {
                this.Message = "Initial Data Load...";
            }
            else
            {
                this.Message = "Refreshing All Data...";
            }

            this.ExecuteAsyncTask(async () => await this.OnRefreshCommand(isInitialLoad));
        }

        /// <summary>
        /// Ons the refresh command.
        /// </summary>
        /// <returns>The refresh command.</returns>
        /// <param name="isInitialLoad">If set to <c>true</c> is initial load.</param>
        private async Task OnRefreshCommand(bool isInitialLoad)
        {
            if (connectivityService.Instance.IsConnected)
            {
                await this.ExecuteAsyncTask(() => this.dataFetcherService.LocationOrRoleChangedHandler(true));

                this.eventAggregator.GetEvent<LocationOrRoleChangedEvent>().Publish();

                if (!isInitialLoad)
                {
                    await this.DialogService.DisplayAlertAsync("All Content", "Refresh Complete", "OK");
                }
            }
            else
            {
                await this.DialogService.DisplayAlertAsync("Error downloading content", "Please check your internet connection and try again.", "OK");
            }

            this.navigationService.NavigateAsync("app:///MainMasterDetailPage/NavigationPage/HomeTabbedPage", animated: false).Forget();
        }
    }
}
