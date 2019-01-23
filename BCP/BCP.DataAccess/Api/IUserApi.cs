//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IUserApi.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IUserApi.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// User API.
    /// </summary>
    public interface IUserApi
    {
        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <returns>The user profile.</returns>
        /// <param name="username">the Username.</param>
        Task<UserSettings> GetUserProfile(string username);

        /// <summary>
        /// Gets the user profile pic.
        /// </summary>
        /// <returns>The user profile pic.</returns>
        /// <param name="username">the Username.</param>
        Task<byte[]> GetUserProfilePic(string username);

        /// <summary>
        /// Gets all user locations.
        /// </summary>
        /// <returns>The all user locations.</returns>
        Task<IEnumerable<string>> GetAllUserLocations();

        /// <summary>
        /// Gets all user roles.
        /// </summary>
        /// <returns>The all user roles.</returns>
        Task<IEnumerable<string>> GetAllUserRoles();
    }
}
