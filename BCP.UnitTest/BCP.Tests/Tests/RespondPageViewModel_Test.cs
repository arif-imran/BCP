using System;
using Xunit;
using BCP.Forms.ViewModels;
using BCP.Forms.Services;
using Microsoft.Practices.Unity;
using Moq;
using BCP.Facade.Facades;
using System.Threading.Tasks;
using System.Collections.Generic;
using BCP.Common.Models;
namespace BCP.UnitTest.Tests
{
    public class RespondPageViewModel_Test : ViewModelTestsBase
    {
        RespondPageViewModel vm;
        [Fact]
        public async Task RespondPage_Instructions_Loaded(){
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
            //Act
			this.vm = new RespondPageViewModel(appLinker: this.container.Resolve<IAppLinker>(),
												  dialogService: this.DialogService.Object,
												  settingsFacade: this.SettingsFacade.Object,
												  navigationService: NavigationService,
												  authenticationFacade: AuthenticationFacade.Object,
												  respondFacade: respondFacade.Object);
            await Task.Delay(1000);
            //Assert
            Assert.NotNull(this.vm.RespondHeader);
            Assert.NotNull(this.vm.UsefulTool);
            Assert.NotNull(this.vm.Steps);
            Assert.NotNull(this.vm.AdditionalInformation);
        }
		[Fact]
        public async Task RespondPage_SelectWebView_Navigation()
        {
			//Arrange 
			this.vm = new RespondPageViewModel(appLinker: this.container.Resolve<IAppLinker>(),
												  dialogService: this.DialogService.Object,
												  settingsFacade: this.SettingsFacade.Object,
												  navigationService: NavigationService,
												  authenticationFacade: AuthenticationFacade.Object,
												  respondFacade: this.container.Resolve<IRespondFacade>());
            
            var navigation = this.NavigationService;

			//Act
			this.vm.SelectWebView.Execute("");
			await Task.Delay(1000);
			var navUrl = navigation.LastNavigationUrl;
            var expectedNavUrl = "DetailWebViewPage";
			//Assert
			Assert.NotNull(navigation);
			Assert.Equal(expectedNavUrl, navUrl);
        }
        [Fact]
        public async Task RespondPage_ItemTapped_Documents(){
			//Arrange 
			this.vm = new RespondPageViewModel(appLinker: this.container.Resolve<IAppLinker>(),
												  dialogService: this.DialogService.Object,
												  settingsFacade: this.SettingsFacade.Object,
												  navigationService: NavigationService,
												  authenticationFacade: AuthenticationFacade.Object,
												  respondFacade: this.container.Resolve<IRespondFacade>());
			var navigation = this.NavigationService;
			//Act
            this.vm.ItemTappedCommand.Execute(new Resource(){
                Category = ResourceType.Documents,
                Name = "Name",
                URL = "URL"             
            });
			await Task.Delay(1000);

			//Assert
			var navUrl = navigation.LastNavigationUrl;
			var expectedNavUrl = "PdfViewerPage";
			Assert.NotNull(navigation);
			Assert.Equal(expectedNavUrl, navUrl);
        }
		[Fact]
		public async Task RespondPage_ItemTapped_Apps()
		{
            //Arrange 
            var appLinker = Mock.Get(this.container.Resolve<IAppLinker>());

            this.vm = new RespondPageViewModel(appLinker: appLinker.Object,
												  dialogService: this.DialogService.Object,
												  settingsFacade: this.SettingsFacade.Object,
												  navigationService: NavigationService,
												  authenticationFacade: AuthenticationFacade.Object,
												  respondFacade: this.container.Resolve<IRespondFacade>());
			//Act
			this.vm.ItemTappedCommand.Execute(new Resource()
			{
                Category = ResourceType.Apps,
				Name = "Name",
				URL = "URL"
			});
			await Task.Delay(1000);

            //Assert
            appLinker.Verify(app => app.OpenLink("URL",""), Times.Once());
		}
    }
}
