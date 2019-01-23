//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ReportDetailsPageViewModel.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ReportDetailsPageViewModel.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.ViewModels
{
    using BCP.Common.Models;
    using BCP.Facade.Facades;
    using Prism.Navigation;
    using Prism.Services;

    /// <summary>
    /// Report details page view model.
    /// </summary>
    public class ReportDetailsPageViewModel : NavigationBaseViewModel
    {
        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        /// The incident facade.
        /// </summary>
        private readonly IIncidentFacade incidentFacade;

        /// <summary>
        /// The type of the incident.
        /// </summary>
        private IncidentType incidentType;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.ViewModels.ReportDetailsPageViewModel"/> class.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="authenticationFacade">Authentication facade.</param>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="incidentFacade">Incident facade.</param>
        public ReportDetailsPageViewModel(IPageDialogService dialogService, IAuthenticationFacade authenticationFacade, INavigationService navigationService, IIncidentFacade incidentFacade)
            : base(dialogService, authenticationFacade)
        {
            this.navigationService = navigationService;
            this.incidentFacade = incidentFacade;
        }

        /// <summary>
        /// Gets or sets the type of the incident.
        /// </summary>
        /// <value>The type of the incident.</value>
        public IncidentType IncidentType
        {
            get { return this.incidentType; }
            set { this.SetProperty(ref this.incidentType, value); }
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">the Parameters.</param>
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters != null && parameters.ContainsKey("IncidentType"))
            {
                this.IncidentType = (IncidentType)parameters["IncidentType"];
            }
        }
    }
}