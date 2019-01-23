using System;
using System.Collections.Generic;
using BCP.Common.Models;
using BCP.Facade.Facades;
using BCP.Forms.Services;
using BCP.Forms.ViewModels;
using BCP.UnitTest.Tests;
using Microsoft.Practices.Unity;
using Moq;
using Xunit;

namespace BCP.UnitTest.Tests
{
    public class ResourcesPageViewModel_Tests : ViewModelTestsBase
    {
        ResourcesPageViewModel vm;
        [Fact]
        public void ResourcePage_ItemTapped_Apps_Links(){
            //Arrage
            var applinker = Mock.Get(container.Resolve<IAppLinker>());
            var resourcesFacade = Mock.Get(container.Resolve<IResourcesFacade>());
            vm = new ResourcesPageViewModel(
                applinker.Object,
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                resourcesFacade: this.container.Resolve<IResourcesFacade>()
            );
            var resource = new Resource() { Name = "App 1", URL = "fb://profile", Category = ResourceType.Apps, IOSAppURL = "https://itunes.apple.com/in/app/facebook/id284882215", AndroidFallBackURL = "https://play.google.com/store/apps/details?id=com.facebook.katana" };

            //Act
            this.vm.ItemTappedCommand.Execute(resource);

            //Assert
            applinker.Verify(x => x.OpenLink(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }
        [Fact]
        public void ResourcePage_ItemTapped_Document(){

            //Arrange
            var applinker = Mock.Get(container.Resolve<IAppLinker>());
            var resourcesFacade = Mock.Get(container.Resolve<IResourcesFacade>());
            vm = new ResourcesPageViewModel(
                applinker.Object,
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                resourcesFacade: this.container.Resolve<IResourcesFacade>()
            );
            var resource = new Resource() { Name = "C# Tutorial PDF", URL = "https://www.tutorialspoint.com/csharp/csharp_tutorial.pdf", Category = ResourceType.Documents };

            //Act
            this.vm.ItemTappedCommand.Execute(resource);

            //Assert
            Assert.Equal("PdfViewerPage", NavigationService.LastNavigationUrl);

        }
        [Fact]
        public void ResourcePage_LoadResource()
        {
            //Arrange
            var applinker = Mock.Get(container.Resolve<IAppLinker>());
            var resourcesFacade = Mock.Get(container.Resolve<IResourcesFacade>());
            resourcesFacade.Setup(x => x.GetResources()).ReturnsAsync(new List<Resource>{
                new Resource(){
                    Name= "Google",URL = "https://www.google.com.pk/",Category = ResourceType.Link
                },
                new Resource(){
                    Name = "C# Tutorial PDF",URL = "https://www.tutorialspoint.com/csharp/csharp_tutorial.pdf",Category = ResourceType.Documents
                },
                new Resource(){
                    Name = "App 1",URL = "fb://profile",Category = ResourceType.Apps,IOSFallBackURL="https://itunes.apple.com/in/app/facebook/id284882215",AndroidFallBackURL="https://play.google.com/store/apps/details?id=com.facebook.katana"
                },
                new Resource(){
                    Name= "Google",URL = "https://www.google.com.pk/",Category = ResourceType.Link
                },
                new Resource(){
                    Name = "C# Tutorial PDF",URL = "https://www.tutorialspoint.com/csharp/csharp_tutorial.pdf",Category = ResourceType.Documents
                },
                new Resource(){
                    Name = "App 1",URL = "fb://profile",Category = ResourceType.Apps,IOSFallBackURL="https://itunes.apple.com/in/app/facebook/id284882215",AndroidFallBackURL="https://play.google.com/store/apps/details?id=com.facebook.katana"
                },
                new Resource(){
                    Name = "App 1",URL = "fb://profile",Category = ResourceType.Apps,IOSFallBackURL="https://itunes.apple.com/in/app/facebook/id284882215",AndroidFallBackURL="https://play.google.com/store/apps/details?id=com.facebook.katana"
                }

            });
            //Act
            vm = new ResourcesPageViewModel(
                applinker.Object,
                dialogService: this.DialogService.Object,
                navigationService: NavigationService,
                authenticationFacade: AuthenticationFacade.Object,
                resourcesFacade: this.container.Resolve<IResourcesFacade>()
            );
            //Assert
            resourcesFacade.Verify(x => x.GetResources(), Times.Once());
            Assert.Equal(this.vm.ResourceGroups.Count, 3);
            Assert.Equal(this.vm.ResourceGroups[0].Count, 2);
            Assert.Equal(this.vm.ResourceGroups[1].Count, 3);
            Assert.Equal(this.vm.ResourceGroups[2].Count, 2);
        }

    }
}
