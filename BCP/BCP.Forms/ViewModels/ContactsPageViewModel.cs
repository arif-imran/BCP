//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ContactsPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ContactsPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using BCP.DataAccess.Model;
    using BCP.Facade.Facades;
    using BCP.Forms.Helpers;
    using Plugin.Geolocator;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    /// <summary>
    /// Contacts page view model.
    /// </summary>
    public class ContactsPageViewModel : NavigationBaseViewModel
    {

		/// <summary>
		/// The navigation service.
		/// </summary>
        private readonly BCP.Common.Services.IDeviceService deviceService;

        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The contacts facade.
        /// </summary>
        private readonly IContactsFacade contactsFacade;

        /// <summary>
        /// The user settings.
        /// </summary>
        private BCP.Common.Models.UserSettings userSettings;

        /// <summary>
        /// The emergency contacts.
        /// </summary>
        private ObservableCollection<EmergencyContact> emergencyContacts;

        /// <summary>
        /// The emergency numbers.
        /// </summary>
        private ObservableCollection<NationalEmergencyNumber> emergencyNumbers;

        /// <summary>
        /// The selected emergency contact.
        /// </summary>
        private EmergencyContact selectedEmergencyContact;

        /// <summary>
        /// The selected emergency contact title.
        /// </summary>
        private string selectedEmergencyContactTitle;

        /// <summary>
        /// Gets or sets the selected emergency contact title.
        /// </summary>
        /// <value>The selected emergency contact title.</value>
		public string SelectedEmergencyContactTitle
		{
			get { return selectedEmergencyContactTitle; }
			set { SetProperty(ref selectedEmergencyContactTitle, value); }
		}

        public ContactsPageViewModel(IPageDialogService dialogService,ISettingsFacade settingsFacade, IAuthenticationFacade authenticationFacade, INavigationService navigationService, IContactsFacade contactsFacade,BCP.Common.Services.IDeviceService deviceService) 
            : base(dialogService, authenticationFacade)
        {
            this.navigationService = navigationService;
            this.contactsFacade = contactsFacade;
            this.settingsFacade = settingsFacade;
            this.deviceService = deviceService;
			this.Title = "Contacts";
			this.ExecuteAsyncTask(this.LoadEmergencyContacts);
		}

        /// <summary>
        /// Gets the emergency contact selected command.
        /// </summary>
        /// <value>The emergency contact selected command.</value>
        public ICommand EmergencyContactSelectedCommand => new Command<int>(this.OnEmergencyContactSelected);

        /// <summary>
        /// Gets the contact command.
        /// </summary>
        /// <value>The contact command.</value>
        public ICommand ContactCommand => new Command<string>(this.OnContactAction);

        /// <summary>
        /// Gets or sets the emergency contacts.
        /// </summary>
        /// <value>The emergency contacts.</value>
        public ObservableCollection<EmergencyContact> EmergencyContacts
        {
            get { return this.emergencyContacts; }
            set { this.SetProperty(ref this.emergencyContacts, value); }
        }

        /// <summary>
        /// Gets or sets the emergency numbers.
        /// </summary>
        /// <value>The emergency numbers.</value>
        public ObservableCollection<NationalEmergencyNumber> EmergencyNumbers
        {
            get { return this.emergencyNumbers; }
            set { this.SetProperty(ref this.emergencyNumbers, value); }
        }

        /// <summary>
        /// Gets or sets the selected emergency contact.
        /// </summary>
        /// <value>The selected emergency contact.</value>
        public EmergencyContact SelectedEmergencyContact
        {
            get { return this.selectedEmergencyContact; }
            set { this.SetProperty(ref this.selectedEmergencyContact, value); }
        }

        /// <summary>
        /// Loads the emergency contacts.
        /// </summary>
        /// <returns>The emergency contacts.</returns>
        private async Task LoadEmergencyContacts()
        {
            this.userSettings = await this.settingsFacade.GetSettings();
            if (this.userSettings == null)
            {
                // show no result screen
                return;
            }

            var contacts = await this.contactsFacade.GetEmergencyContactsContent(this.userSettings.Location);
            if (contacts == null)
            {
                //// show no result screen
                return;
            }

            await Task.Delay(400);
            this.EmergencyContacts = new ObservableCollection<EmergencyContact>(contacts.EmergencyContacts);
            this.EmergencyNumbers = new ObservableCollection<NationalEmergencyNumber>(contacts.NationalEmergencyContacts);
        }

        /// <summary>
        /// Updates the distance.
        /// </summary>
        /// <returns>The distance.</returns>
        private async Task UpdateDistance()
        {
            var locator = CrossGeolocator.Current;
            var userPosition = await locator.GetPositionAsync();
            double distance = DistanceCalculation.GeoCodeCalc.CalcDistance(
                userPosition.Latitude,
                userPosition.Longitude,
                this.SelectedEmergencyContact.Latitude,
                this.SelectedEmergencyContact.Longitude,
                DistanceCalculation.GeoCodeCalcMeasurement.Kilometers); 
            this.SelectedEmergencyContactTitle = string.Format("{0} ({1:0.#} km)", this.SelectedEmergencyContact.Name, distance);
        }

        /// <summary>
        /// Ons the contact action.
        /// </summary>
        /// <param name="actionType">Action type.</param>
        private void OnContactAction(string actionType)
        {
            switch (actionType)
            {
                case "address":
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        Device.OpenUri(new Uri("geo:" + this.SelectedEmergencyContact.Latitude + "," + this.SelectedEmergencyContact.Longitude + "?q=" + this.SelectedEmergencyContact.Address));
                    }
                    else if (Device.RuntimePlatform == Device.iOS)
                    {
                        Device.OpenUri(new Uri("http://maps.apple.com/?q=" + this.SelectedEmergencyContact.Latitude + "," + this.SelectedEmergencyContact.Longitude + "?q=" + this.SelectedEmergencyContact.Address));
                    }

                    break;
                case "telephone":
                    Device.OpenUri(new Uri("tel:" + this.SelectedEmergencyContact.Telephone));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Ons the emergency contact selected.
        /// </summary>
        /// <param name="contactId">Contact identifier.</param>
        private void OnEmergencyContactSelected(int contactId)
        {
            var selectedItem = this.EmergencyContacts.FirstOrDefault(c => c.Id == contactId);
            this.SelectedEmergencyContact = selectedItem;
            this.SelectedEmergencyContactTitle = this.SelectedEmergencyContact.Name;
            this.ExecuteAsyncTaskWithNoLoading(this.UpdateDistance);
        }
    }
}
