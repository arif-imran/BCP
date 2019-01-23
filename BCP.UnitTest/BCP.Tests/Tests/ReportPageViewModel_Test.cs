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
    public class ReportPageViewModel_Test : ViewModelTestsBase
    {
        ReportPageViewModel vm;
        [Fact]
        public async Task ReportPage_LoadIncidents()
        {
            //Arrange
            var incidentFacade = Mock.Get(this.container.Resolve<IIncidentFacade>());
            incidentFacade.Setup(x => x.GetIncidentTypeList("Shanghai")).ReturnsAsync(new List<IncidentType>{
            new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Category A",
                ContactUserName = "ContactUserName",
                Description = "Discounts"

            },new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Category A",
                ContactUserName = "ContactUserName",
                Description = "Cars"
            },new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Category B",
                ContactUserName = "ContactUserName",
                Description = "Cars"
            },new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Category B",
                ContactUserName = "ContactUserName",
                Description = "Cars"

            },new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Discounts",
                ContactUserName = "ContactUserName",
                Description ="Cars"
                }
            });
            //Act
            this.vm = new ReportPageViewModel(
                                                  dialogService: this.DialogService.Object,
                                                  settingsFacade: this.SettingsFacade.Object,
                                                  navigationService: NavigationService,
                                                  authenticationFacade: AuthenticationFacade.Object,
                                                  incidentFacade: incidentFacade.Object);
            await Task.Delay(1000);
            //Assert
            incidentFacade.Verify(x => x.GetIncidentTypeList("Shanghai"), Times.Once());
            Assert.Equal(this.vm.ExpandedGroups.Count, 3);


            this.vm.ExpandedGroups[0].IncidentGroupSelectedCommand.Execute(this.vm.ExpandedGroups[0]);
            Assert.Equal(this.vm.ExpandedGroups.Count, 3);
            Assert.Equal(this.vm.ExpandedGroups[0].Count, 2);


            this.vm.IncidentSelectedCommand.Execute(new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Discounts",
                ContactUserName = "ContactUserName",
                Description = "Cars"
            });
            Assert.Equal(VerifyNavigation("ReportDetailsPage"), true);
        }
        [Fact]
        public async Task ReportPage_LoadIncidents_Filtered()
        {
            //Arrange
            var incidentFacade = Mock.Get(this.container.Resolve<IIncidentFacade>());
            incidentFacade.Setup(x => x.GetIncidentTypeList("Shanghai")).ReturnsAsync(new List<IncidentType>{
            new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Category A",
                ContactUserName = "ContactUserName",
                Description = "Discounts"

            },new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Category A",
                ContactUserName = "ContactUserName",
                Description = "Cars"
            },new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Category B",
                ContactUserName = "ContactUserName",
                Description = "Cars"
            },new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Category B",
                ContactUserName = "ContactUserName",
                Description = "Cars"

            },new IncidentType()
            {
                BackupContactUserName = "BackupContactUserName",
                Category = "Discounts",
                ContactUserName = "ContactUserName",
                Description ="Cars"
                }
            });
            //Act
            vm = this.vm = new ReportPageViewModel(
                                                  dialogService: this.DialogService.Object,
                                                  settingsFacade: this.SettingsFacade.Object,
                                                  navigationService: NavigationService,
                                                  authenticationFacade: AuthenticationFacade.Object,
                                                  incidentFacade: incidentFacade.Object);
            await Task.Delay(1000);
            this.vm.FilterText = "Cars";

            //Assert
            incidentFacade.Verify(x => x.GetIncidentTypeList("Shanghai"), Times.Once());
            Assert.Equal(this.vm.ExpandedGroups.Count, 3);


            this.vm.FilterText = "Discounts";
            await Task.Delay(1000);
            //Assert
            Assert.Equal(this.vm.ExpandedGroups.Count, 2);
        }
    }
}
