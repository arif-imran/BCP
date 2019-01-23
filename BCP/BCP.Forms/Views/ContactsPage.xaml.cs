//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ContactsPage.xaml.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ContactsPage.xaml.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Views
{
    using System.Linq;
    using BCP.Forms.Controls;
    using BCP.Forms.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// Contacts page.
    /// </summary>
    public partial class ContactsPage : ContentPage
    {
        /// <summary>
        /// Backing Storage for the Spacing property
        /// </summary>
        public static readonly BindableProperty ShowPanelProperty = BindableProperty.Create<ContactsPage, bool>(w => w.ShowPanel, default(bool), propertyChanged: ShowPanel_OnPropertyChanged);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Views.ContactsPage"/> class.
        /// </summary>
        public ContactsPage()
        {
            this.InitializeComponent();

            // ToDo: Put this in ViewModel
            HideButton.Clicked += (sender, e) =>
            {
                this.TogglePanel(false);
            };

            XamlMap.PinTappedCommand = new Command<CustomPin>((pin) =>
            {
                if (pin != null)
                {
                    this.TogglePanel(true);
                    this.ViewModel.EmergencyContactSelectedCommand.Execute(pin.Id);
                }
            });

            XamlMap.PinDeselectedCommand = new Command(() =>
            {
                this.TogglePanel(false);
            });

            this.ViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "EmergencyContacts")
                {
                    XamlMap.UpdatePins(ViewModel.EmergencyContacts);
                }
                else if (e.PropertyName == "EmergencyNumbers")
                {
                    var numbers = ViewModel.EmergencyNumbers;
                    var executiveNumber = numbers.Where(n => n.IsHealthAndSafetyExecutive).FirstOrDefault();
                    if (executiveNumber != null)
                    {
                        ExecutiveNumberLabel.Text = executiveNumber.Number;
                    }

                    var serviceNumbers = numbers.Where(n => !n.IsHealthAndSafetyExecutive).ToList();
                    for (int i = 0; i < serviceNumbers.Count(); i++)
                    {
                        var number = serviceNumbers[i];
                        if (i == 0)
                        {
                            TitleLabel1.Text = number.Name;
                            PhoneLabel1.Text = number.Number;
                        }
                        else if (i == 1)
                        {
                            TitleLabel2.Text = number.Name;
                            PhoneLabel2.Text = number.Number;
                        }
                        else if (i == 2)
                        {
                            TitleLabel3.Text = number.Name;
                            PhoneLabel3.Text = number.Number;
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <value>The view model.</value>
        public ContactsPageViewModel ViewModel
        {
            get { return BindingContext as ContactsPageViewModel; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BCP.Forms.Views.ContactsPage"/> show panel.
        /// </summary>
        /// <value><c>true</c> if show panel; otherwise, <c>false</c>.</value>
        public bool ShowPanel
        {
            get
            {
                return (bool)GetValue(ShowPanelProperty);
            }

            set
            {
                this.SetValue(ShowPanelProperty, value);
            }
        }

        /// <summary>
        /// Shows the menu on property changed.
        /// </summary>
        /// <param name="bindable">Bindable objects .</param>
        /// <param name="oldvalue">If set to <c>true</c> old value.</param>
        /// <param name="newvalue">If set to <c>true</c> new value.</param>
        private static void ShowPanel_OnPropertyChanged(BindableObject bindable, bool oldvalue, bool newvalue)
        {
            var control = bindable as ContactsPage;

            if (control != null && newvalue != oldvalue)
            {
                control.TogglePanel(newvalue);
            }
        }

        /// <summary>
        /// Toggles the panel.
        /// </summary>
        /// <param name="show">If set to <c>true</c> show.</param>
        private void TogglePanel(bool show)
        {
            var screenHeightString = Application.Current.Resources["ScreenHeight"].ToString();
            var twoThirdScreenHeightMinus50String = Application.Current.Resources["TwoThirdScreenHeightMinus50"].ToString();
            var screenHeight = double.Parse(screenHeightString);
            var twoThirdScreenHeightMinus50 = double.Parse(twoThirdScreenHeightMinus50String);
            if (!show)
            {
                // hide menu
                SecondDetailView.TranslateTo(0, screenHeight, 300, Easing.CubicIn);
                this.ShowPanel = false;
            }
            else
            {
                // show menu
                SecondDetailView.TranslateTo(0, twoThirdScreenHeightMinus50, 300, Easing.CubicIn);
            }
        }
    }
}
