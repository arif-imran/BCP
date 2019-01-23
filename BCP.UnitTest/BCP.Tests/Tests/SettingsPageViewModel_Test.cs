﻿using System;
using System.Threading.Tasks;
using BCP.Forms.ViewModels;
using Xunit;
using BCP.Facade.Facades;
using Microsoft.Practices.Unity;
using Prism.Events;
using BCP.Common.Services;
using Prism.Navigation;
using Moq;
using BCP.Common.Events;

namespace BCP.UnitTest.Tests
{
    public class SettingsPageViewModel_Test : ViewModelTestsBase
    {
		
        SettingsPageViewModel vm;
        [Fact]
        public async Task SettingsPage_SettingsSelection()
        {
            //Arrrange
            this.vm = new SettingsPageViewModel(
	            userFacade: this.container.Resolve<IUserFacade>(),
	            dialogService: this.DialogService.Object,
	            settingsFacade: this.SettingsFacade.Object,
	            navigationService: NavigationService,
	            authenticationFacade: AuthenticationFacade.Object,
	            eventAggregator: this.container.Resolve<IEventAggregator>(),
	            dataFetcherService: this.container.Resolve<IDataFetcherService>(),
                connectivityService: this.ConnectivityService.Object
            );
            var navigation = this.NavigationService;
            //Act
            this.vm.SettingSelect.Execute("Test");
            await Task.Delay(1000);
			//Assert
            Assert.Equal(VerifyNavigation("SettingSelectionPage?type=Test"), true);
        }
        [Fact]
        public async Task SettingsPage_VerifyPopulatedSettings(){
			//Arrrange
			var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
			eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
			var datafetcher = Mock.Get(this.container.Resolve<IDataFetcherService>());
			this.vm = new SettingsPageViewModel(
				userFacade: this.container.Resolve<IUserFacade>(),
				dialogService: this.DialogService.Object,
				settingsFacade: this.SettingsFacade.Object,
				navigationService: NavigationService,
				authenticationFacade: AuthenticationFacade.Object,
				eventAggregator: eventagg.Object,
				dataFetcherService: datafetcher.Object,
				connectivityService: this.ConnectivityService.Object
			);
            //Act
            NavigationParameters navParam = new NavigationParameters();
            navParam.Add("isLocOrRoleChanged",true);
            this.vm.OnNavigatedTo(navParam);
            await Task.Delay(1000);
			//Assert
            datafetcher.Verify(x => x.LocationOrRoleChangedHandler(false), Times.Once());
			eventagg.Verify(x => x.GetEvent<LocationOrRoleChangedEvent>(), Times.Once());
            Assert.Equal(this.vm.SelectedRole, "Asset Manager");
            Assert.Equal(this.vm.SelectedLocation, "Shanghai");
		}
		[Fact]
		public async Task SettingsPage_RefreshCommand_WithConnectivity()
		{
            //Arrrange
            var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
            eventagg.Setup(y=> y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent(){});
            var datafetcher = Mock.Get(this.container.Resolve<IDataFetcherService>());

			this.vm = new SettingsPageViewModel(
				userFacade: this.container.Resolve<IUserFacade>(),
				dialogService: this.DialogService.Object,
				settingsFacade: this.SettingsFacade.Object,
				navigationService: NavigationService,
				authenticationFacade: AuthenticationFacade.Object,
                eventAggregator: eventagg.Object,
                dataFetcherService: datafetcher.Object,
				connectivityService: this.ConnectivityService.Object
			);
			//Act
            this.vm.RefreshCommand.Execute();
			await Task.Delay(1000);
            //Assert
            datafetcher.Verify(x => x.LocationOrRoleChangedHandler(true), Times.Once());
            eventagg.Verify(x => x.GetEvent<LocationOrRoleChangedEvent>(), Times.Once());
            this.DialogService.Verify(dia => dia.DisplayAlertAsync("All Content", "Refresh Complete", "Cancel"), Times.Once());
		}
		[Fact]
		public async Task SettingsPage_RefreshCommand_NoConnectivity()
		{
			//Arrrange
			var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
			eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
            var connect = Mock.Get(this.ConnectivityService.Object);
            connect.Setup(x=> x.Instance.IsConnected).Returns(false);
			var connectivityService = Mock.Get(this.container.Resolve<ICacheService>());
			this.vm = new SettingsPageViewModel(
				userFacade: this.container.Resolve<IUserFacade>(),
				dialogService: this.DialogService.Object,
				settingsFacade: this.SettingsFacade.Object,
				navigationService: NavigationService,
				authenticationFacade: AuthenticationFacade.Object,
				eventAggregator: eventagg.Object,
				dataFetcherService: this.container.Resolve<IDataFetcherService>(),
				connectivityService: connect.Object
			);
			//Act
			this.vm.RefreshCommand.Execute();
			await Task.Delay(1000);
			//Assert
			this.DialogService.Verify(dia => dia.DisplayAlertAsync("Error", "Please check your internet connection and try again.", "OK"), Times.Once());
		}
    }
}
