using System;
using System.Threading.Tasks;
using BCP.Forms.ViewModels;
using Xunit;
using Microsoft.Practices.Unity;
using BCP.Facade.Facades;
using Prism.Navigation;
using Moq;
using System.Collections.Generic;
using BCP.Common.Models;

namespace BCP.UnitTest.Tests
{
    public class SettingSelectionPageViewModel_Test : ViewModelTestsBase
    {
        SettingSelectionPageViewModel vm;
        [Fact]
        public async Task SettingsSelection_ItemTapped()
        {
            //Arrange
            //var navService = Mock.Get(this.container.Resolve<INavigationService>());
			vm = new SettingSelectionPageViewModel(dialogService: this.DialogService.Object,
                                                   navigationService:this.NavigationService,
													authenticationFacade: AuthenticationFacade.Object,
												   userFacade: this.container.Resolve<IUserFacade>(),
													settingsFacade: this.SettingsFacade.Object);
			NavigationParameters navParams = new NavigationParameters();
			navParams.Add("type", "Role");
			//Act
			this.vm.OnNavigatedTo(navParams);
            this.vm.ItemTappedCommand.Execute(new Forms.SettingSelectingItem(){
                Name = "Communication Communicator"
            });
			await Task.Delay(1000);
            //Assert
            this.SettingsFacade.Verify(x => x.SaveSettings(It.IsAny<UserSettings>()), Times.Once());
           // navService.Verify(x=>x.GoBackAsync(It.IsAny<NavigationParameters>(), false,true),Times.Once());
        }
        [Fact]
        public async Task SettingsSelection_OnNavigated_Location()
        {
            //Arrange
            var userFacade = Mock.Get(this.container.Resolve<IUserFacade>());
            userFacade.Setup(x=>x.GetAllUserLocations()).ReturnsAsync(new List<string>{"Shanghai","Tokyo"});
            vm = new SettingSelectionPageViewModel(dialogService: this.DialogService.Object,
													navigationService: NavigationService,
													authenticationFacade: AuthenticationFacade.Object,
                                                   userFacade: userFacade.Object,
													settingsFacade: this.SettingsFacade.Object);
            NavigationParameters navParams = new NavigationParameters();
            navParams.Add("type", "Location");
            //Act
            this.vm.OnNavigatedTo(navParams);
			await Task.Delay(1000);
            //Assert
            Assert.Equal(this.vm.SettingItem.Count, 2);
        }
		[Fact]
		public async Task SettingsSelection_OnNavigated_Role()
		{
			//Arrange
			var userFacade = Mock.Get(this.container.Resolve<IUserFacade>());
            userFacade.Setup(x => x.GetAllUserRoles()).ReturnsAsync(new List<string> { "Asset Manager", "Communication Communicator" });
			vm = new SettingSelectionPageViewModel(dialogService: this.DialogService.Object,
													navigationService: NavigationService,
													authenticationFacade: AuthenticationFacade.Object,
												   userFacade: userFacade.Object,
													settingsFacade: this.SettingsFacade.Object);
			NavigationParameters navParams = new NavigationParameters();
			navParams.Add("type", "Role");
			//Act
			this.vm.OnNavigatedTo(navParams);
			await Task.Delay(1000);
			//Assert
			Assert.Equal(this.vm.SettingItem.Count, 3);
		}
    }
}
