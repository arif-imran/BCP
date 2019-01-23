using System;
using BCP.Common.Services;
using BCP.Facade.Facades;
using BCP.Forms.ViewModels;
using BCP.Forms.Services;
using Moq;
using Prism.Events;
using Xunit;
using Microsoft.Practices.Unity;
using BCP.Common.Events;

namespace BCP.UnitTest.Tests
{
    public class MainMasterDetailPageViewModel_Test : ViewModelTestsBase
    {
        MainMasterDetailPageViewModel vm;
        [Fact]
        public void MasterDetailPage_ReportCommand()
        {
            //Arrange
            var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
            eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
            vm = new MainMasterDetailPageViewModel(
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                dataFetcherService: this.DataFetchService.Object,
                settingsFacade: this.SettingsFacade.Object,
                eventAggregator: eventagg.Object
            );

            //Act
            this.vm.ReportCommand.Execute(It.IsAny<string>());

            //Assert
            Assert.Equal("NavigationPage/HomeTabbedPage/ReportPage", NavigationService.LastNavigationUrl);
        }

        [Fact]
        public void MasterDetailPage_RespondCommand()
        {
            //Arrange
            var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
            eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
            vm = new MainMasterDetailPageViewModel(
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                dataFetcherService: this.DataFetchService.Object,
                settingsFacade: this.SettingsFacade.Object,
                eventAggregator: eventagg.Object
            );

            //Act
            this.vm.RespondCommand.Execute(It.IsAny<string>());

            //Assert
            Assert.Equal("NavigationPage/HomeTabbedPage/RespondPage", NavigationService.LastNavigationUrl);
        }

        [Fact]
        public void MasterDetailPage_CallTreeCommand()
        {
            //Arrange
            var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
            eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
            vm = new MainMasterDetailPageViewModel(
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                dataFetcherService: this.DataFetchService.Object,
                settingsFacade: this.SettingsFacade.Object,
                eventAggregator: eventagg.Object
            );

            //Act
            this.vm.CallTreeCommand.Execute(It.IsAny<string>());

            //Assert
            Assert.Equal("NavigationPage/CallTreePage", NavigationService.LastNavigationUrl);
        }

        [Fact]
        public void MasterDetailPage_ContactsCommand()
        {
            //Arrange
            var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
            eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
            vm = new MainMasterDetailPageViewModel(
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                dataFetcherService: this.DataFetchService.Object,
                settingsFacade: this.SettingsFacade.Object,
                eventAggregator: eventagg.Object
            );

            //Act
            this.vm.ContactsCommand.Execute(It.IsAny<string>());

            //Assert
            Assert.Equal("NavigationPage/HomeTabbedPage/ContactsPage", NavigationService.LastNavigationUrl);
        }

        [Fact]
        public void MasterDetailPage_ResourcesCommand()
        {
            //Arrange
            var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
            eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
            vm = new MainMasterDetailPageViewModel(
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                dataFetcherService: this.DataFetchService.Object,
                settingsFacade: this.SettingsFacade.Object,
                eventAggregator: eventagg.Object
            );

            //Act
            this.vm.ResourcesCommand.Execute(It.IsAny<string>());

            //Assert
            Assert.Equal("NavigationPage/ResourcesPage", NavigationService.LastNavigationUrl);
        }

        [Fact]
        public void MasterDetailPage_GetRefreshCommand()
        {
            //Arrange
            var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
            eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
            vm = new MainMasterDetailPageViewModel(
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                dataFetcherService: this.DataFetchService.Object,
                settingsFacade: this.SettingsFacade.Object,
                eventAggregator: eventagg.Object
            );

            //Act
            this.vm.GetRefreshCommand.Execute(It.IsAny<string>());

            //Assert
            Assert.Equal("NavigationPage/RefreshContentPage", NavigationService.LastNavigationUrl);
        }

       

        [Fact]
        public void MasterDetailPage_FullBCPDocumentCommand()
        {
            //Arrange
            var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
            eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
            vm = new MainMasterDetailPageViewModel(
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                dataFetcherService: this.DataFetchService.Object,
                settingsFacade: this.SettingsFacade.Object,
                eventAggregator: eventagg.Object
            );

            //Act
            this.vm.FullBCPDocumentCommand.Execute(It.IsAny<string>());

            //Assert
            Assert.Equal("NavigationPage/PdfViewerPage", NavigationService.LastNavigationUrl);
        }

        [Fact]
        public void MasterDetailPage_SettingsCommand()
        {
            //Arrange
            var eventagg = Mock.Get(this.container.Resolve<IEventAggregator>());
            eventagg.Setup(y => y.GetEvent<LocationOrRoleChangedEvent>()).Returns(new LocationOrRoleChangedEvent() { });
            vm = new MainMasterDetailPageViewModel(
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                dataFetcherService: this.DataFetchService.Object,
                settingsFacade: this.SettingsFacade.Object,
                eventAggregator: eventagg.Object
            );

            //Act
            this.vm.SettingsCommand.Execute(It.IsAny<string>());

            //Assert
            Assert.Equal("NavigationPage/SettingsPage", NavigationService.LastNavigationUrl);
        }
    }
}
