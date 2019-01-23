﻿using Moq;
using Microsoft.Practices.Unity;
using Grosvenor.Forms.Core.Services;
using BCP.UnitTest.Helper;
using BCP.UnitTest.Mocks;
using BCP.Common.Services;
using Prism.Services;
using Prism.Navigation;
using BCP.Facade.Facades;
using Prism.Events;

namespace BCP.UnitTest.Tests
{
    public class ViewModelTestsBase : ContainerHelper
    {
		protected MockDispatcher mockDispatcher;

		public ViewModelTestsBase()
		{
			mockDispatcher = new MockDispatcher();
		}
        private Mock<IConnectivityService> connectivityService;
		protected Mock<IConnectivityService> ConnectivityService
		{
			get
			{
                if (this.connectivityService == null)
                {
                    this.connectivityService = Mock.Get(this.container.Resolve<IConnectivityService>());
                    this.connectivityService.Setup(x => x.Instance).Returns(new ConnectivityServiceMock());
                }
				return this.connectivityService;
			}
		}
		private Mock<ICacheService> cacheService;
		protected Mock<ICacheService> CacheService
		{
			get
			{
				if (this.cacheService == null)
					this.cacheService = Mock.Get(this.container.Resolve<ICacheService>());

				return this.cacheService;
			}
		}

        private Mock<ISettingsFacade> settingsFacade;
		protected Mock<ISettingsFacade> SettingsFacade
		{
			get
			{
                if (this.settingsFacade == null)
                {
                    this.settingsFacade = Mock.Get(this.container.Resolve<ISettingsFacade>());
                    this.settingsFacade.Setup(foo => foo.GetSettings()).ReturnsAsync(new Common.Models.UserSettings(){
                        FirstName = "Stewart",
                        LastName = "Cope",
                        Location = "Shanghai",
                        Role = "Asset Manager"
                    });
                }
				return this.settingsFacade;
			}
		}

		private Mock<IAuthenticationFacade> authenticationFacade;
		protected Mock<IAuthenticationFacade> AuthenticationFacade
		{
			get
			{
				if (this.authenticationFacade == null)
					this.authenticationFacade = Mock.Get(this.container.Resolve<IAuthenticationFacade>());

				return this.authenticationFacade;
			}
		}

		private Mock<IPageDialogService> dialogService;
		protected Mock<IPageDialogService> DialogService
		{
			get
			{
				if (this.dialogService == null)
                    this.dialogService = Mock.Get(this.container.Resolve<IPageDialogService>());

				return this.dialogService;
			}
		}

        private Mock<IAnalyticsService> analyticsService;
        protected Mock<IAnalyticsService> AnalyticsService
        {
            get
            {
                if (this.analyticsService == null)
                    this.analyticsService = Mock.Get(this.container.Resolve<IAnalyticsService>());

                return this.analyticsService;
            }
        }

		private NavigationServiceMock navigationService;
		protected NavigationServiceMock NavigationService
		{
			get
			{
				if (this.navigationService == null)
					this.navigationService = this.container.Resolve<INavigationService>() as NavigationServiceMock;

				return this.navigationService;
			}
		}

        private Mock<IDataFetcherService> datafetchService;
        protected Mock<IDataFetcherService> DataFetchService
        {
            get
            {
                if (this.datafetchService == null)
                    this.datafetchService = Mock.Get(this.container.Resolve<IDataFetcherService>());

                return this.datafetchService;
            }
        }

        private Mock<IEventAggregator> eventAggregator;
        protected Mock<IEventAggregator> EventAggregator
        {
            get
            {
                if (this.eventAggregator == null)
                    this.eventAggregator = Mock.Get(this.container.Resolve<IEventAggregator>());

                return this.eventAggregator;
            }
        }

        public bool VerifyNavigation(string URL){
			var navigation = this.NavigationService;
			var navUrl = navigation.LastNavigationUrl;
            if(navigation != null)
            {
                return navUrl == URL;
            }
            return false;
        }
    }
}
