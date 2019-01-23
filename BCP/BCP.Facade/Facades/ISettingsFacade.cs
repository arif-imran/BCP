//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ISettingsFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ISettingsFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Settings facade.
    /// </summary>
    public interface ISettingsFacade
    {
        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        Task<UserSettings> GetSettings();

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        /// <param name="settings">the Settings.</param>
        Task SaveSettings(UserSettings settings);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        Task<UserInfoModel> GetUser();

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="user">the User.</param>
        Task SaveUser(UserInfoModel user);

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <returns>The user name.</returns>
        Task<string> GetUserName();

        /// <summary>
        /// Deletes all.
        /// </summary>
        void DeleteAll();
    }
}