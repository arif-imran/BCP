namespace BCP.Forms
{
    using Grosvenor.Forms.DataAccess.Services;

    using Microsoft.Practices.Unity;
    using BCP.DataAccess.Services;
    using BCP.Facade.Facades;
    using BCP.Forms.Services;
    using BCP.Forms.Views;

    using Prism.Unity;
    using BCP.DataAccess.Api;
    using Xamarin.Forms;
    using BCP.Common.Services;
    using Grosvenor.Forms.Core.Utils;
    using BCP.DataAccess;
    using Grosvenor.Forms.Core.Services;

    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        static public int ScreenWidth;


        protected override void OnInitialized()
        {
            this.InitializeComponent();

            Grosvenor.Forms.Ui.Controls.Effects.Init();

            SetResources();

            this.NavigationService.NavigateAsync("ExtendedLoadingPage", animated: false);

            SharedContainer.Initialise(this.Container);

            var lifecycleService = UnityContainerExtensions.Resolve<ILifecycleService>(this.Container);
            lifecycleService.StartAsync(this.NavigationService);
        }

        protected override void RegisterTypes()
        {

            //this.Container.RegisterType<IAnalyticsService, AnalyticsService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IDataAccessService, DataAccessService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ILifecycleService, LifecycleService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ISettingsFacade, SettingsFacade>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IIncidentFacade, IncidentFacade>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IUserFacade, UserFacade>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ICallTreeFacade, CallTreeFacade>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IContactsFacade, ContactsFacade>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IIncidentApi, IncidentApi>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IUserApi, UserApi>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IDocumentApi, DocumentApi>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IDocumentFacade, DocumentFacade>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ICallTreeApi, CallTreeApi>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IContactsApi, ContactsApi>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IAuthenticationFacade, AuthenticationFacade>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IRespondFacade, RespondFacade>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IRespondApi, RespondApi>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IResourcesFacade, ResourcesFacade>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IResourceApi, ResourceApi>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ICacheService, CacheService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IConnectivityService, ConnectivityService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IDeviceService, DeviceService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IDataFetcherService, DataFetcherService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterTypeForNavigation<MainMasterDetailPage>();
            this.Container.RegisterTypeForNavigation<ExtendedLoadingPage>();
            this.Container.RegisterTypeForNavigation<LoginPage>();
            this.Container.RegisterTypeForNavigation<ReportPage>();
            this.Container.RegisterTypeForNavigation<HomeTabbedPage>();
            this.Container.RegisterTypeForNavigation<RespondPage>();
            this.Container.RegisterTypeForNavigation<MainPage>();
            this.Container.RegisterTypeForNavigation<NavigationPage>();
            this.Container.RegisterTypeForNavigation<ReportDetailsPage>();
            this.Container.RegisterTypeForNavigation<PdfViewerPage>();
            this.Container.RegisterTypeForNavigation<ContactsPage>();
            this.Container.RegisterTypeForNavigation<ResourcesPage>();
            this.Container.RegisterTypeForNavigation<RefreshContentPage>();
            this.Container.RegisterTypeForNavigation<CallTreePage>();
            this.Container.RegisterTypeForNavigation<SettingsPage>();
            this.Container.RegisterTypeForNavigation<SettingSelectionPage>();
            this.Container.RegisterTypeForNavigation<GifImageViewer>();
            this.Container.RegisterTypeForNavigation<DetailWebViewPage>();
        }


		private void SetResources()
		{
			var commonUtility = Xamarin.Forms.DependencyService.Get<ICommonUtility>();

			var width = commonUtility.ScreenWidth();
			var height = commonUtility.ScreenHeight();

			var resources = Current.Resources;

			resources.Add("ScreenHeight", height);
            resources.Add("OneThirdScreenHeight", height / 3);
			resources.Add("OneThirdScreenHeightAdd50", height / 3 +50);
			resources.Add("TwoThirdScreenHeightMinus50", height * 0.6 -50);

			resources.Add("OneForthScreenHeight", height / 4);
			resources.Add("TwoThirdScreenHeight", height * 0.6);
			resources.Add("OneFifthScreenHeight", (height * 0.6) / 2.3);
			resources.Add("OneEightScreenHeight", (height * 0.6) / 3);
			resources.Add("HalfScreenHeight", height / 2);

			resources.Add("ScreenWidth", width);
			resources.Add("ScreenWidthNegative", width * -1);
            resources.Add("OneForthScreenWidth",width /4);
            resources.Add("ThreeForthScreenWidth",(width /4) *3);

            var statusBarHeight = commonUtility.StatusBarHeight;
            var headerHeight = commonUtility.PageHeaderHeight;
            resources["StatusBarHeight"] = statusBarHeight;
            resources.Add("MenuHeaderHeight", headerHeight + statusBarHeight);
            resources.Add("PageHeaderHeight", headerHeight);
            resources.Add("PageContentHeight", height - headerHeight - statusBarHeight);

            //var defPadding = (Xamarin.Forms.Thickness)Current.Resources["DefaultThicknessMax"];
            //resources.Add("HalfScreenPaddingInclusive", ((width - defPadding.HorizontalThickness) / 2));
        }
    }
}