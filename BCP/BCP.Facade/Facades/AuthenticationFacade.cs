//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AuthenticationFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AuthenticationFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{   
    using System;
    using System.Threading.Tasks;
    using BCP.Common.Models;

    /// <summary>
    /// Authentication facade.
    /// </summary>
    public class AuthenticationFacade : IAuthenticationFacade
    {
        /// <summary>
        /// The settings facade.
        /// </summary>
        private readonly ISettingsFacade settingsFacade;

        /// <summary>Initializes a new instance of the <see cref="AuthenticationFacade"/> class.</summary>
        /// <param name="settingsFacade">The settings facade.</param>
        public AuthenticationFacade(ISettingsFacade settingsFacade)
        {
            this.settingsFacade = settingsFacade;
        }

        /// <summary>The login async.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<bool> LoginAsync(string username, string password)
        {
            ////todo login
            ////todo move to kaychain. 
            await this.settingsFacade.SaveUser(
                new UserInfoModel()
                {
                    UserName = username,
                    Password = password,
                    Email = "test@test.com"
                });

            return true;
        }
    }
}