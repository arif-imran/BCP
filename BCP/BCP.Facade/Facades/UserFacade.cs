//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="UserFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   UserFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;
    using BCP.DataAccess.Api;

    /// <summary>
    /// User facade.
    /// </summary>
    public class UserFacade : IUserFacade
    {
        /// <summary>
        /// The user API.
        /// </summary>
        private readonly IUserApi userApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Facade.Facades.UserFacade"/> class.
        /// </summary>
        /// <param name="userApi">User API.</param>
        public UserFacade(IUserApi userApi)
        {
            this.userApi = userApi;
        }

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <returns>The user profile.</returns>
        /// <param name="username">the Username.</param>
        public async Task<UserSettings> GetUserProfile(string username)
        {
            return await this.userApi.GetUserProfile(username);
        }

        /// <summary>
        /// Gets the user profile pic.
        /// </summary>
        /// <returns>The user profile pic.</returns>
        /// <param name="username">the Username.</param>
        public async Task<byte[]> GetUserProfilePic(string username)
        {
            return await this.userApi.GetUserProfilePic(username);
        }

        /// <summary>
        /// Gets all user locations.
        /// </summary>
        /// <returns>The all user locations.</returns>
        public async Task<IEnumerable<string>> GetAllUserLocations()
        {
            return await this.userApi.GetAllUserLocations();
        }

        /// <summary>
        /// Gets all user roles.
        /// </summary>
        /// <returns>The all user roles.</returns>
        public async Task<IEnumerable<string>> GetAllUserRoles()
        {
            return await this.userApi.GetAllUserRoles();
        }
    }
}
