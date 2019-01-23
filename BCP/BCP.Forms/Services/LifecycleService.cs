// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LifecycleService.cs" company="Grosvenor">
// //   ${CopyrightHolder}
// // </copyright>
// // <summary>
// //   LifecycleService
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Common.Services;
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Core.Utils;
    using Grosvenor.Forms.MobileIron.EventArgs;
    using Grosvenor.Forms.MobileIron.Services;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    /// <summary>
    /// Lifecycle service.
    /// </summary>
    public class LifecycleService : ILifecycleService
    {
       /// <summary>
        /// The cache service.
        /// </summary>
        private readonly ICacheService cacheService;

        /// <summary>
        /// The mobile iron service.
        /// </summary>
        private readonly IMobileIronService mobileIronService;

        /// <summary>
        /// The user facade.
        /// </summary>
        private readonly IUserFacade userFacade;

        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The dialog service.
        /// </summary>
        private readonly IPageDialogService dialogService;

        /// <summary>
        /// The data fetcher service.
        /// </summary>
        private readonly IDataFetcherService dataFetcherService;

        /// <summary>
        /// The resources facade.
        /// </summary>
        private IResourcesFacade resourcesFacade;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private INavigationService navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Services.LifecycleService"/> class.
        /// </summary>
        /// <param name="cacheService">Cache service.</param>
        /// <param name="mobileIronService">Mobile iron service.</param>
        /// <param name="userFacade">User facade.</param>
        /// <param name="settingsFacade">Settings facade.</param>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="dataFetcherService">Data fetcher service.</param>
        /// <param name="resourcesFacade">Resources facade.</param>
        public LifecycleService(
            ICacheService cacheService,
            IMobileIronService mobileIronService,
            IUserFacade userFacade,
            ISettingsFacade settingsFacade,
            IPageDialogService dialogService,
            IDataFetcherService dataFetcherService,
            IResourcesFacade resourcesFacade)
        {
            this.cacheService = cacheService;
            this.mobileIronService = mobileIronService;
            this.userFacade = userFacade;
            this.settingsFacade = settingsFacade;
            this.dialogService = dialogService;
            this.dataFetcherService = dataFetcherService;
            this.resourcesFacade = resourcesFacade;
        }

        /// <summary>
        /// Starts the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="navigationService">Navigation service.</param>
        public async Task StartAsync(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.mobileIronService.ConfigurationReceived += (object sender, MobileIronEventArgs e) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await OnMobileIronConfigReceived(sender, e);
                });
            };
            if (Device.RuntimePlatform == Device.Android)
            {
                var res = await this.resourcesFacade.GetResources();
                this.mobileIronService.GetMobileIronConfig();
            }
        }

        /// <summary>
        /// Updates the user profile.
        /// </summary>
        /// <returns>The user profile.</returns>
        public async Task UpdateUserProfile()
        {
            var profile = await this.settingsFacade.GetSettings();
            if (profile == null)
            {
                string username = await this.settingsFacade.GetUserName();

                if (!string.IsNullOrEmpty(username))
                {
                    ////Will fetch the user profile role/location from the API
                    profile = await this.userFacade.GetUserProfile(username);
                    if (profile == null)
                    {
                        return;
                    }
                    else
                    {
                        await this.settingsFacade.SaveSettings(profile);
                    }
                }
            }
        }

        /// <summary>
        /// Ons the mobile iron config received.
        /// </summary>
        /// <returns>The mobile iron config received.</returns>
        /// <param name="sender">the Sender.</param>
        /// <param name="args">the Arguments.</param>
        private async Task OnMobileIronConfigReceived(object sender, MobileIronEventArgs args)
        {
            Dictionary<string, string> mobileIronConfig = args.Config;
            if (mobileIronConfig != null)
            {
                if (mobileIronConfig.ContainsKey("user") && !string.IsNullOrEmpty(mobileIronConfig["user"]))
                {
                    var userInfo = new UserInfoModel()
                    {
#if MOBILE_IRON
                        UserName = mobileIronConfig["user"],
                        Password = mobileIronConfig["password"],
                        Email = mobileIronConfig["email"]
#else
                        UserName = "KNarita",
                        Password = "123",
                        Email = "knarita@grosvenor.com"
#endif
                    };
                    string username = await this.settingsFacade.GetUserName();

                    var profile = await this.userFacade.GetUserProfile(userInfo.UserName);
                    if (profile == null)
                    {
                        await this.dialogService.DisplayAlertAsync("Error", "No profile found for username:" + userInfo.UserName + ". Check your connection.", "Ok");
                        this.navigationService.NavigateAsync("app:///MainMasterDetailPage/NavigationPage/HomeTabbedPage", animated: false).Forget();

                        return;
                    }
                    else
                    {
                        await this.settingsFacade.SaveUser(userInfo);
                    }

                    await this.UpdateUserProfile();

                    if (string.IsNullOrEmpty(username))
                    {
                        var navParams = new NavigationParameters();
                        navParams.Add("IsInitialLoad", true);
                        this.navigationService.NavigateAsync("app:///MainMasterDetailPage/NavigationPage/RefreshContentPage", navParams, animated: false).Forget();
                    }
                    else
                    {
                        this.navigationService.NavigateAsync("app:///MainMasterDetailPage/NavigationPage/HomeTabbedPage", animated: false).Forget();
                    }
                }
            }
            else
            {
                // config was not retrieved - maybe MobileIron is not installed
            }
        }
    }
}
