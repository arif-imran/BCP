// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ILifecycleService.cs" company="Grosvenor">
// //   ${CopyrightHolder}
// // </copyright>
// // <summary>
// //   ILifecycleService
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Services
{
    using System.Threading.Tasks;
    using Prism.Navigation;

    /// <summary>
    /// Lifecycle service.
    /// </summary>
    public interface ILifecycleService
    {
        /// <summary>
        /// Starts the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="navigationService">Navigation service.</param>
        Task StartAsync(INavigationService navigationService);

        /// <summary>
        /// Updates the user profile.
        /// </summary>
        /// <returns>The user profile.</returns>
        Task UpdateUserProfile();
        ////Task LocationOrRoleChangedHandler(bool deleteEverything);
    }
}
