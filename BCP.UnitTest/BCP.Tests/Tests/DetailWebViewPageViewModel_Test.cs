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
    public class DetailWebViewPageViewModel_Test : ViewModelTestsBase
    {
        DetailWebViewPageViewModel vm;
        [Fact]
        public async Task DetailWebViewPage_InfoLoaded(){
			//Arrange
			var respondFacade = Mock.Get(this.container.Resolve<IRespondFacade>());
			respondFacade.Setup(res => res.GetRespondContent("Asset Manager", "Shanghai")).ReturnsAsync(new RespondContent()
			{
				RespondHeader = "Lorem Ipsum",
				Flowchart = new List<string> { "Step1", "Step 2" },
				UsefulTools = new List<Resource> {
					new Resource(){
						Name = "Name",
						URL = "URL",
                        IOSAppURL = "iOSAppURL",
						AndroidAppBundle = "AndroidAppBundle",
						AndroidFallBackURL = "AndroidFallBackURL",
						Category = ResourceType.Apps,
                        IOSFallBackURL = "iOSFallBackURL"
					}
				},
				AdditionalInformation = "Lorem Ipsum"
			});
			this.vm = new DetailWebViewPageViewModel(
												  dialogService: this.DialogService.Object,
												  settingsFacade: this.SettingsFacade.Object,
												  authenticationFacade: AuthenticationFacade.Object,
												  respondFacade: respondFacade.Object);
            //Act
            this.vm.OnNavigatedTo(null);
			await Task.Delay(1000);
			//Assert
			Assert.NotNull(this.vm.Html);
            Assert.Equal(this.vm.Html,"Lorem Ipsum");
        }
    }
}
