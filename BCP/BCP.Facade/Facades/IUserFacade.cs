//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IUserFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IUserFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// User facade.
    /// </summary>
    public interface IUserFacade
    {
        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <returns>The user profile.</returns>
        /// <param name="username">get Username.</param>
        Task<UserSettings> GetUserProfile(string username);

        /// <summary>
        /// Gets the user profile pic.
        /// </summary>
        /// <returns>The user profile pic.</returns>
        /// <param name="username">get profile pic of username.</param>
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
