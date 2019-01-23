//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="UserImageControl.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   UserImageControl.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Controls
{
    using System.IO;
    using System.Threading.Tasks;
    using BCP.Facade.Facades;
    using Grosvenor.Forms.Core.Utils;
    using ImageCircle.Forms.Plugin.Abstractions;
    using Xamarin.Forms;

    /// <summary>
    /// User image control.
    /// </summary>
    public class UserImageControl : CircleImage
    {
        /// <summary>
        /// The user name property.
        /// </summary>
        public static readonly BindableProperty UserNameProperty = BindableProperty.Create(nameof(UserName), 
                                                                                           typeof(string), 
                                                                                           typeof(UserImageControl), "", BindingMode.TwoWay, null, propertyChanged: async (bindable, oldValue, newValue) =>
        {
            await ((UserImageControl)bindable).UserNameChanged((string)oldValue, (string)newValue);
        });

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { this.SetValue(UserNameProperty, value); }
        }

        /// <summary>
        /// Users the name changed.
        /// </summary>
        /// <returns>The name changed.</returns>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        private async Task UserNameChanged(string oldValue, string newValue)
        {
            if (!string.IsNullOrEmpty(newValue))
            {
                var userFacade = SharedContainer.ResolveType<IUserFacade>();
                var picture = await userFacade.GetUserProfilePic(this.UserName);
                if (picture != null)
                {
                    this.Source = ImageSource.FromStream(() => new MemoryStream(picture));
                }
                else
                {
                    this.Source = ImageSource.FromFile("placeholder.png");
                    System.Diagnostics.Debug.WriteLine("Profile Picture is not available for this user " + this.UserName);
                }
            }
        }
    }
}
