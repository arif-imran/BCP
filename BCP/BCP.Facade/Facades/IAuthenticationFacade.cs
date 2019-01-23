//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IAuthenticationFacade.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IAuthenticationFacade.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Facade.Facades
{
    using System.Threading.Tasks;

    /// <summary>The AuthenticationFacade interface.</summary>
    public interface IAuthenticationFacade
    {
        /// <summary>The login async.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<bool> LoginAsync(string username, string password);
    }
}