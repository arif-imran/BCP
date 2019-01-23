using System.Threading.Tasks;
using BCP.Forms.ViewModels;
using Xunit;
using BCP.Facade.Facades;
using Microsoft.Practices.Unity;
using Moq;
using System.Collections.Generic;
using BCP.Common.Models;
using BCP.Common.Services;
using BCP.DataAccess.Model;

namespace BCP.UnitTest.Tests
{
    public class ContactsPageViewModel_Test : ViewModelTestsBase
    {
        ContactsPageViewModel vm;
        [Fact]
        public async Task ContactPage_ContactsLoaded(){
            //Arrange
            var contactsFacade = Mock.Get(this.container.Resolve<IContactsFacade>());
            contactsFacade.Setup(x => x.GetEmergencyContactsContent("Shanghai")).ReturnsAsync(new EmergencyContactsContent()
            {
                EmergencyContacts = new List<EmergencyContact>(){
                    new EmergencyContact(){
                        Name = "Contact A",
                        Address = "",
                        Telephone = ""
                    },
					 new EmergencyContact(){
						Name = "Contact B",
						Address = "",
						Telephone = ""
					}, new EmergencyContact(){
						Name = "Contact C",
						Address = "",
						Telephone = ""
					}
                },
                NationalEmergencyContacts =  new List<NationalEmergencyNumber>(){
                    new NationalEmergencyNumber(){
                        Number = "123",
                        IsPolice = true
                    },
					new NationalEmergencyNumber(){
						Number = "456",
                        IsFire = true
					},
					new NationalEmergencyNumber(){
						Number = "789",
                        IsAmbulance = true
					},new NationalEmergencyNumber(){
						Number = "000",
                        IsHealthAndSafetyExecutive = true
					}
                }
            });
            //Act
			this.vm = new ContactsPageViewModel(
												  dialogService: this.DialogService.Object,
												  settingsFacade: this.SettingsFacade.Object,
												  navigationService: NavigationService,
												  authenticationFacade: AuthenticationFacade.Object,
                                                  contactsFacade: contactsFacade.Object,
                                                 deviceService: this.container.Resolve<IDeviceService>()
            );
            
            await Task.Delay(1000);
            //Assert
            Assert.Equal(this.vm.EmergencyContacts.Count, 3);
            Assert.Equal(this.vm.EmergencyNumbers.Count, 4);
        }
		[Fact]
		public async Task ContactPage_EmergencyContactSelectedCommand()
		{
			//Arrange
			var contactsFacade = Mock.Get(this.container.Resolve<IContactsFacade>());
			contactsFacade.Setup(x => x.GetEmergencyContactsContent("Shanghai")).ReturnsAsync(new EmergencyContactsContent()
			{
				EmergencyContacts = new List<EmergencyContact>(){
					new EmergencyContact(){
                        Id = 1,
						Name = "Contact A",
						Address = "",
						Telephone = ""
					},
					 new EmergencyContact(){
                        Id = 2,
						Name = "Contact B",
						Address = "",
						Telephone = ""
					}, new EmergencyContact(){
                        Id = 3,
						Name = "Contact C",
						Address = "",
						Telephone = ""
					}
				},
				NationalEmergencyContacts = new List<NationalEmergencyNumber>(){
					new NationalEmergencyNumber(){
						Number = "123",
						IsPolice = true
					},
					new NationalEmergencyNumber(){
						Number = "456",
						IsFire = true
					},
					new NationalEmergencyNumber(){
						Number = "789",
						IsAmbulance = true
					},new NationalEmergencyNumber(){
						Number = "000",
						IsHealthAndSafetyExecutive = true
					}
				}
			});
			//Act
			this.vm = new ContactsPageViewModel(
												  dialogService: this.DialogService.Object,
												  settingsFacade: this.SettingsFacade.Object,
												  navigationService: NavigationService,
												  authenticationFacade: AuthenticationFacade.Object,
												  contactsFacade: contactsFacade.Object,
												 deviceService: this.container.Resolve<IDeviceService>()
			);

			await Task.Delay(1000);
            this.vm.EmergencyContactSelectedCommand.Execute(2);

			//Assert
			Assert.Equal(this.vm.EmergencyContacts.Count, 3);
			Assert.Equal(this.vm.EmergencyNumbers.Count, 4);
            Assert.Equal(this.vm.SelectedEmergencyContactTitle, "Contact B");
		}
    }
}
