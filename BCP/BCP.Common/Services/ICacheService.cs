//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="ICacheService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   ICacheService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common.Services
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Cache service.
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Invalidates all objects.
        /// </summary>
        void InvalidateAllObjects();

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">Key param.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> GetObject<T>(string key);

        /// <summary>
        /// Gets the and fetch object by key.
        /// </summary>
        /// <returns>The and fetch object by key.</returns>
        /// <param name="key">Key param.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        IObservable<T> GetAndFetchObjectByKey<T>(string key, Func<Task<T>> fetchFunc);

        /// <summary>
        /// Inserts the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">Key param.</param>
        /// <param name="value">Value param.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task InsertObject<T>(string key, T value);

        /// <summary>
        /// Removes the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">Key param.</param>
        Task RemoveObject(string key);

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        /// <param name="key">Key param.</param>
        /// <param name="value">Value param.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task SaveSettings<T>(string key, T value);

        /// <summary>
        /// Retrieves the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        /// <param name="key">Key param.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> RetrieveSettings<T>(string key);

        /// <summary>
        /// Gets the or fetch settings.
        /// </summary>
        /// <returns>The or fetch settings.</returns>
        /// <param name="key">Key param.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> GetOrFetchSettings<T>(string key, Func<Task<T>> fetchFunc);

        /// <summary>
        /// Gets the setting object.
        /// </summary>
        /// <returns>The setting object.</returns>
        /// <param name="key">Key param.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> GetSettingObject<T>(string key);

        /// <summary>
        /// Gets the or fetch object by key.
        /// </summary>
        /// <returns>The or fetch object by key.</returns>
        /// <param name="key">Key param.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> GetOrFetchObjectByKey<T>(string key, Func<Task<T>> fetchFunc);

        /// <summary>
        /// Deletes the local cache.
        /// </summary>
        /// <returns>The local cache.</returns>
        /// <param name="deleteEverything">If set to <c>true</c> delete everything.</param>
        Task DeleteLocalCache(bool deleteEverything);
    }
}
