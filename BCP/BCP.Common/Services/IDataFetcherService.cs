//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="IDataFetcherService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   IDataFetcherService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// Data fetcher service.
    /// </summary>
    public interface IDataFetcherService
    {
        /// <summary>
        /// Locations the or role changed handler.
        /// </summary>
        /// <returns>The or role changed handler.</returns>
        /// <param name="deleteEverything">If set to <c>true</c> delete everything.</param>
        Task LocationOrRoleChangedHandler(bool deleteEverything);

        /// <summary>
        /// Fetchs all data.
        /// </summary>
        /// <returns>The all data.</returns>
        Task FetchAllData();
    }
}
