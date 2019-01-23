using System.Threading.Tasks;
using BCP.Forms.ViewModels;
using Xunit;
using BCP.Facade.Facades;
using Microsoft.Practices.Unity;
using Moq;
using System.Collections.Generic;
using BCP.Common.Models;

namespace BCP.UnitTest.Tests
{
    public class NavigationBaseViewModel_Test : ViewModelTestsBase
    {
        CallTreePageViewModel vm;
        [Fact]
        public async Task NavigationBase_AnalyticsTriggered(){

            //Arrange
            var callTreeFacade = Mock.Get(this.container.Resolve<ICallTreeFacade>());
            callTreeFacade.Setup(x => x.GetCallTree("Shanghai")).ReturnsAsync(new List<Contact>{
                new Contact(){
                    FirstName ="A Group",
                    LastName="LastName",
                    UserName = "UserName",
                    Avatar = "Avatar",
                    Email = "Email"
                },
                new Contact(){
                    FirstName ="B Group",
                    LastName="LastName 2",
                    UserName = "UserName 2",
                    Avatar = "Avatar 2",
                    Email = "Email 2"
                },
                new Contact(){
                    FirstName ="B Group 2",
                    LastName="LastName 2",
                    UserName = "UserName 2",
                    Avatar = "Avatar 2",
                    Email = "Email 2"
                }

            });
            this.vm = new CallTreePageViewModel(
                callTreeFacade: this.container.Resolve<ICallTreeFacade>(),
                dialogService: this.DialogService.Object,
                settingsFacade: this.SettingsFacade.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object
            );
            this.vm.OnNavigatedTo(null);
            await Task.Delay(1000);
            this.AnalyticsService.Verify(x=> x.TrackPageViewEvent(It.IsAny<string>(),null),Times.Once());
        }
    }
}
