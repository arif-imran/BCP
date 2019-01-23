//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="DetailWebViewPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   DetailWebViewPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.Facade.Facades;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Detail web view page view model.
    /// </summary>
    public class DetailWebViewPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The html.
        /// </summary>
        private string _html;

        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The respond facade.
        /// </summary>
        private readonly IRespondFacade respondFacade;

        /// <summary>
        /// The user settings.
        /// </summary>
        private UserSettings userSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.DetailWebViewPageViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="settingsFacade">Settings facade.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="respondFacade">Respond facade.</param>
        public DetailWebViewPageViewModel(IPageDialogService dialogService,
                                          ISettingsFacade settingsFacade,
                                          IAuthenticationFacade authenticationFacade,
                                          IRespondFacade respondFacade)
            : base(dialogService, authenticationFacade)
        {
            this.settingsFacade = settingsFacade;
            this.respondFacade = respondFacade;
        }

        /// <summary>
        /// Gets or sets the html.
        /// </summary>
        /// <value>The html.</value>
        public string Html
        {
            get { return this._html; }
            set { this.SetProperty(ref this._html, value); }
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            this.ExecuteAsyncTask(this.LoadAdditionalInfo);
        }

        /// <summary>
        /// Loads the additional info.
        /// </summary>
        /// <returns>The additional info.</returns>
        private async Task LoadAdditionalInfo()
        {
            this.userSettings = await this.settingsFacade.GetSettings();
            var result = await this.respondFacade.GetRespondContent(this.userSettings.Role, this.userSettings.Location);

            if (result != null)
            {
                this.Html = result.AdditionalInformation;
            }
        }
    }
}
