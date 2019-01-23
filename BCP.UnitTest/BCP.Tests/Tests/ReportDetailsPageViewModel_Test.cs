using BCP.Forms.ViewModels;
using Xunit;
using Prism.Navigation;
using BCP.Common.Models;
using Moq;
using BCP.Facade.Facades;
using Microsoft.Practices.Unity;

namespace BCP.UnitTest.Tests
{
    public class ReportDetailsPageViewModel_Test : ViewModelTestsBase
    {
        ReportDetailsPageViewModel vm;
        [Fact]
        public void ReportDetailPage_OnNavigatedTo()
        {
			//Arrange
			var incidentFacade = Mock.Get(this.container.Resolve<IIncidentFacade>());
            vm = new ReportDetailsPageViewModel(dialogService: this.DialogService.Object,
                                                navigationService: NavigationService,
                                                authenticationFacade: AuthenticationFacade.Object,
                                                incidentFacade:incidentFacade.Object );
            var incidentTypeMock = new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Category",
                ContactUserName = "ContactUserName"
            };
            NavigationParameters navParams = new NavigationParameters();
            navParams.Add("IncidentType",incidentTypeMock);
            //Act
            this.vm.OnNavigatedTo(navParams);
            //Assert
            Assert.Equal(this.vm.IncidentType,incidentTypeMock);
        }
    }
}
