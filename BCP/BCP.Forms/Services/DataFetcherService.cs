//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="DataFetcherService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   DataFetcherService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Services
{
    using System.Threading.Tasks;
    using BCP.Common.Services;
    using BCP.DataAccess.Api;
    using BCP.Facade.Facades;
    using Plugin.Connectivity;
    using Prism.Services;

    /// <summary>
    /// Data fetcher service.
    /// </summary>
    public class DataFetcherService : IDataFetcherService
    {
        /// <summary>
        /// The cache service.
        /// </summary>
        private readonly ICacheService cacheService;

        /// <summary>
        /// The user facade.
        /// </summary>
        private readonly IUserFacade userFacade;

        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>
        /// The resource facade.
        /// </summary>
        private readonly IResourcesFacade resourceFacade;

        /// <summary>
        /// The call tree facade.
        /// </summary>
        private readonly ICallTreeFacade callTreeFacade;

        /// <summary>
        /// The contacts facade.
        /// </summary>
        private readonly IContactsFacade contactsFacade;

        /// <summary>
        /// The respond facade.
        /// </summary>
        private readonly IRespondFacade respondFacade;

        /// <summary>
        /// The incident facade.
        /// </summary>
        private readonly IIncidentFacade incidentFacade;

        /// <summary>
        /// The document facade.
        /// </summary>
        private readonly IDocumentFacade documentFacade;

        /// <summary>
        /// The page dialog service.
        /// </summary>
        private readonly IPageDialogService pageDialogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Services.DataFetcherService"/> class.
        /// </summary>
        /// <param name="cacheService">Cache service.</param>
        /// <param name="userFacade">User facade.</param>
        /// <param name="settingsFacade">Settings facade.</param>
        /// <param name="resourceFacade">Resource facade.</param>
        /// <param name="callTreeFacade">Call tree facade.</param>
        /// <param name="contactsFacade">Contacts facade.</param>
        /// <param name="respondFacade">Respond facade.</param>
        /// <param name="incidentFacade">Incident facade.</param>
        /// <param name="documentFacade">Document facade.</param>
        /// <param name="pageDialogService">Page dialog service.</param>
        public DataFetcherService(
            ICacheService cacheService,
            IUserFacade userFacade,
            ISettingsFacade settingsFacade,
            IResourcesFacade resourceFacade,
            ICallTreeFacade callTreeFacade,
            IContactsFacade contactsFacade,
            IRespondFacade respondFacade,
            IIncidentFacade incidentFacade,
            IDocumentFacade documentFacade,
            IPageDialogService pageDialogService)
        {
            this.cacheService = cacheService;
            this.userFacade = userFacade;
            this.settingsFacade = settingsFacade;
            this.resourceFacade = resourceFacade;
            this.callTreeFacade = callTreeFacade;
            this.contactsFacade = contactsFacade;
            this.respondFacade = respondFacade;
            this.incidentFacade = incidentFacade;
            this.documentFacade = documentFacade;
            this.pageDialogService = pageDialogService;
        }

        /// <summary>
        /// Fetchs all data.
        /// </summary>
        /// <returns>The all data.</returns>
        public async Task FetchAllData()
        {
            await this.resourceFacade.GetResources();
            await this.userFacade.GetAllUserLocations();
            await this.userFacade.GetAllUserRoles();
            await this.documentFacade.GetBCPDocument(ApiRequestHelper.GetFullBCPDocument());
            ////await this.lifecycleService.UpdateUserProfile();
            var userSettings = await this.settingsFacade.GetSettings();
            if (userSettings != null)
            {
                await Task.WhenAll(new Task[]
                {
                        this.callTreeFacade.GetCallTree(userSettings.Location),
                        this.contactsFacade.GetEmergencyContactsContent(userSettings.Location),
                        this.respondFacade.GetRespondContent(userSettings.Role, userSettings.Location),
                        this.incidentFacade.GetIncidentTypeList(userSettings.Location)
                });
            }
        }

        /// <summary>
        /// Locations the or role changed handler.
        /// </summary>
        /// <returns>The or role changed handler.</returns>
        /// <param name="deleteEverything">If set to <c>true</c> delete everything.</param>
        public async Task LocationOrRoleChangedHandler(bool deleteEverything)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                await this.cacheService.DeleteLocalCache(deleteEverything);

                await this.FetchAllData();
            }
            else
            {
                await this.pageDialogService.DisplayAlertAsync("Error", "Please check your internet connection and try again.", "OK");
            }
        }
    }
}
