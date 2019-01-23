using System.Threading.Tasks;
using BCP.Forms.ViewModels;
using Xunit;
using BCP.Facade.Facades;
using Microsoft.Practices.Unity;
using Moq;
using System.Collections.Generic;
using BCP.Common.Models;
using Prism.Events;
using BCP.Common.Events;
using BCP.Common.Services;
using Prism.Navigation;

namespace BCP.UnitTest.Tests
{
    public class RefreshContentPageViewModel_Test : ViewModelTestsBase
    {
        RefreshContentPageViewModel vm;
        [Fact]
        public async Task RefreshContentPage_IntitalLoadWithInternet(){
			//Arrrange
			var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
			eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
			var datafetcher = Mock.Get(this.container.Resolve<IDataFetcherService>());
			this.vm = new RefreshContentPageViewModel(
                dialogService: this.DialogService.Object,
				navigationService: NavigationService,
				authenticationFacade: AuthenticationFacade.Object,
				eventAggregator: eventagg.Object,
				dataFetcherService: datafetcher.Object,
                connectivityService: this.ConnectivityService.Object
			);
			//Act
			NavigationParameters navParam = new NavigationParameters();
			navParam.Add("IsInitialLoad", true);
			this.vm.OnNavigatedTo(navParam);
			await Task.Delay(1000);
			//Assert
			datafetcher.Verify(x => x.LocationOrRoleChangedHandler(true), Times.Once());
			eventagg.Verify(x => x.GetEvent<LocationOrRoleChangedEvent>(), Times.Once());
            Assert.Equal(this.vm.Message, "Initial Data Load...");
            Assert.Equal(VerifyNavigation("app:///MainMasterDetailPage/NavigationPage/HomeTabbedPage"),true);
        }
        [Fact]
		public async Task RefreshContentPage_IntitalLoadFalseWithInternet()
		{
			//Arrrange
			var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
			eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
			var datafetcher = Mock.Get(this.container.Resolve<IDataFetcherService>());
			this.vm = new RefreshContentPageViewModel(
				dialogService: this.DialogService.Object,
				navigationService: NavigationService,
				authenticationFacade: AuthenticationFacade.Object,
				eventAggregator: eventagg.Object,
				dataFetcherService: datafetcher.Object,
                connectivityService: this.ConnectivityService.Object
			);
			//Act
			NavigationParameters navParam = new NavigationParameters();
            navParam.Add("IsInitialLoad", false);
			this.vm.OnNavigatedTo(navParam);
			await Task.Delay(1000);
			//Assert
			datafetcher.Verify(x => x.LocationOrRoleChangedHandler(true), Times.Once());
			eventagg.Verify(x => x.GetEvent<LocationOrRoleChangedEvent>(), Times.Once());
            Assert.Equal(this.vm.Message, "Refreshing All Data...");
			this.DialogService.Verify(dia => dia.DisplayAlertAsync("All Content", "Refresh Complete", "OK"), Times.Once());
			Assert.Equal(VerifyNavigation("app:///MainMasterDetailPage/NavigationPage/HomeTabbedPage"), true);
		}
		[Fact]
		public async Task RefreshContentPage_IntitalLoadWithNoInternet()
		{
			//Arrrange
			var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
			eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
			var datafetcher = Mock.Get(this.container.Resolve<IDataFetcherService>());
			var connect = Mock.Get(this.ConnectivityService.Object);
			connect.Setup(x => x.Instance.IsConnected).Returns(false);
			this.vm = new RefreshContentPageViewModel(
				dialogService: this.DialogService.Object,
				navigationService: NavigationService,
				authenticationFacade: AuthenticationFacade.Object,
				eventAggregator: eventagg.Object,
				dataFetcherService: datafetcher.Object,
                connectivityService: connect.Object
			);
			//Act
			NavigationParameters navParam = new NavigationParameters();
			navParam.Add("IsInitialLoad", true);
			this.vm.OnNavigatedTo(navParam);
			await Task.Delay(1000);
			//Assert
			Assert.Equal(this.vm.Message, "Initial Data Load...");
			this.DialogService.Verify(dia => dia.DisplayAlertAsync("Error downloading content", "Please check your internet connection and try again.", "OK"), Times.Once());
			Assert.Equal(VerifyNavigation("app:///MainMasterDetailPage/NavigationPage/HomeTabbedPage"), true);
		}
		[Fact]
		public async Task RefreshContentPage_IntitalLoadFalseWithNoInternet()
		{
			//Arrrange
			var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
			eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
			var datafetcher = Mock.Get(this.container.Resolve<IDataFetcherService>());
			var connect = Mock.Get(this.ConnectivityService.Object);
			connect.Setup(x => x.Instance.IsConnected).Returns(false);
			this.vm = new RefreshContentPageViewModel(
				dialogService: this.DialogService.Object,
				navigationService: NavigationService,
				authenticationFacade: AuthenticationFacade.Object,
				eventAggregator: eventagg.Object,
				dataFetcherService: datafetcher.Object,
                connectivityService: connect.Object
			);
			//Act
			NavigationParameters navParam = new NavigationParameters();
			navParam.Add("IsInitialLoad", false);
			this.vm.OnNavigatedTo(navParam);
			await Task.Delay(1000);
			//Assert
		
			Assert.Equal(this.vm.Message, "Refreshing All Data...");
			this.DialogService.Verify(dia => dia.DisplayAlertAsync("Error downloading content", "Please check your internet connection and try again.", "OK"), Times.Once());
			Assert.Equal(VerifyNavigation("app:///MainMasterDetailPage/NavigationPage/HomeTabbedPage"), true);
		}
    }
}
