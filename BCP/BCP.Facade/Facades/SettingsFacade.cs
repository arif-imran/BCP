//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="SettingsFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   SettingsFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------
namespace BCP.Facade.Facades
{
    using System.Threading.Tasks;
    using BCP.Common;
    using BCP.Common.Models;
    using BCP.Common.Services;
    using BCP.DataAccess.Model;
    using Grosvenor.Forms.DataAccess.Services;

    /// <summary>
    ///     Settings facade.
    /// </summary>
    public class SettingsFacade : ISettingsFacade
    {
        /// <summary>
        /// The user key.
        /// </summary>
        private const string UserKey = "user";

        /// <summary>
        /// The user settings key.
        /// </summary>
        private const string UserSettingsKey = "settings";

        /// <summary>
        /// The data access service.
        /// </summary>
        private readonly IDataAccessService dataAccessService;

        /// <summary>
        /// The cache service.
        /// </summary>
        private readonly ICacheService cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Facade.Facades.SettingsFacade"/> class.
        /// </summary>
        /// <param name="dataAccessService">Data access service.</param>
        /// <param name="cacheService">Cache service.</param>
        public SettingsFacade(IDataAccessService dataAccessService, ICacheService cacheService)
        {
            this.dataAccessService = dataAccessService;
            this.cacheService = cacheService;
        }

        /// <summary>
        /// Deletes all.
        /// </summary>
        public void DeleteAll()
        {
            var result = this.dataAccessService.DeleteAll<Settings>();
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        public async Task<UserSettings> GetSettings()
        {
            var result = await this.cacheService.GetSettingObject<UserSettings>(UserSettingsKey);

            if (result != null)
            {
                if (string.IsNullOrWhiteSpace(result.Role))
                {
                    result.Role = Constants.DefaultRole;
                }

                if (string.IsNullOrWhiteSpace(result.Location))
                {
                    result.Location = Constants.SelectLocation;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <returns>The user name.</returns>
        public async Task<string> GetUserName()
        {
            var user = await this.cacheService.GetSettingObject<UserInfoModel>(UserKey);
            if (user != null)
            {
                return user.UserName;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        /// <param name="settings">the Settings.</param>
        public async Task SaveSettings(UserSettings settings)
        {
            if (settings != null)
            {
                if (string.IsNullOrWhiteSpace(settings.Role))
                {
                    settings.Role = Constants.DefaultRole;
                }

                if (string.IsNullOrWhiteSpace(settings.Location))
                {
                    settings.Location = null;
                }
            }

            await this.cacheService.SaveSettings(UserSettingsKey, settings);
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        public async Task<UserInfoModel> GetUser()
        {
            return await this.cacheService.GetSettingObject<UserInfoModel>(UserKey);
        }

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="user">the User.</param>
        public async Task SaveUser(UserInfoModel user)
        {
            await this.cacheService.SaveSettings(UserKey, user);
        }
    }
}