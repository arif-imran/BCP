//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="CacheService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   CacheService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using Akavache;
    using BCP.Common;
    using BCP.Common.Models;
    using BCP.Common.Services;
    using BCP.DataAccess.Model;

    /// <summary>
    /// Cache service.
    /// </summary>
    public class CacheService : ICacheService
    {
        /// <summary>
        /// The BLOB cache.
        /// </summary>
        private IBlobCache blobCache = BlobCache.LocalMachine;

        /// <summary>
        /// The BLOB settings.
        /// </summary>
        private IBlobCache blobSettings = BlobCache.UserAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheService"/> class.
        /// </summary>
        public CacheService()
        {
            BlobCache.ApplicationName = "BCP";
        }

        /// <summary>
        /// Gets the object by key.
        /// </summary>
        /// <returns>The object by key.</returns>
        /// <param name="key">the Key.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public IObservable<T> GetAndFetchObjectByKey<T>(string key, Func<Task<T>> fetchFunc)
        {
            return this.blobCache.GetAndFetchLatest<T>(key, fetchFunc, null, null);
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">the Key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> GetObject<T>(string key)
        {
            if (await this.ContainsKey(key))
            {
                var result = await this.blobCache.GetObject<T>(key);
                return result;
            }

            return default(T);
        }

        /// <summary>
        /// Inserts the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">the Key.</param>
        /// <param name="value">the Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task InsertObject<T>(string key, T value)
        {
            ////await BlobCache.LocalMachine.Invalidate(key);
            await this.blobCache.InsertObject(key, value);
        }

        /// <summary>
        /// Removes the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">the Key.</param>
        public async Task RemoveObject(string key)
        {
            await this.blobCache.Invalidate(key);
        }

        /// <summary>
        /// Gets the or fetch settings.
        /// </summary>
        /// <returns>The or fetch settings.</returns>
        /// <param name="key">this Key.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> GetOrFetchSettings<T>(string key, Func<Task<T>> fetchFunc)
        {
            T result = default(T);

            try
            {
                result = await this.blobSettings.GetOrFetchObject(key, fetchFunc);
                if (result == null)
                {
                    await this.blobSettings.InvalidateObject<T>(key);
                }
            }
            catch (KeyNotFoundException ex)
            {
            }

            return result;
        }

        /// <summary>
        /// Retrieves the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        /// <param name="key">the Key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> RetrieveSettings<T>(string key)
        {
            T result = default(T);

            try
            {
                result = await this.blobSettings.GetObject<T>(key);
            }
            catch (KeyNotFoundException ex)
            {
            }

            return result;
        }

        /// <summary>
        /// Saves the object in memory.
        /// </summary>
        /// <returns>The object in memory.</returns>
        /// <param name="key">the Key.</param>
        /// <param name="value">the Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task SaveSettings<T>(string key, T value)
        {
            await this.blobSettings.InsertObject(key, value);
        }

        /// <summary>
        /// Gets the or fetch object by key.
        /// </summary>
        /// <returns>The or fetch object by key.</returns>
        /// <param name="key">the Key.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> GetOrFetchObjectByKey<T>(string key, Func<Task<T>> fetchFunc)
        {
            T result;
            if (await this.ContainsKey(key))
            {
                var time = await this.blobCache.GetCreatedAt(key);

                ////Below Condition will get true, when the Cache Timeout has expired.
                if (DateTimeOffset.Compare(DateTimeOffset.UtcNow, time.Value.Add(SharedConfig.CacheTimeOut)) > 0)
                {
                    var currentCachedItem = await this.blobCache.GetObject<T>(key);
                    await this.blobCache.InvalidateObject<T>(key);

                    result = await this.blobCache.GetOrFetchObject(key, fetchFunc);
                    if (result == null)
                    {
                        await this.blobCache.InvalidateObject<T>(key);
                        if (currentCachedItem != null)
                        {
                            await this.blobCache.InsertObject(key, currentCachedItem);
                            return currentCachedItem;
                        }
                    }

                    return result;
                }
            }

            result = await this.blobCache.GetOrFetchObject<T>(key, fetchFunc);
            if (result == null)
            {
                await this.blobCache.InvalidateObject<T>(key);
            }

            return result;
        }

        /// <summary>
        /// Invalidates all objects.
        /// </summary>
        public void InvalidateAllObjects()
        {
            this.blobCache.InvalidateAllObjects<Object>();
        }

        /// <summary>
        /// Gets the setting object.
        /// </summary>
        /// <returns>The setting object.</returns>
        /// <param name="key">the Key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> GetSettingObject<T>(string key)
        {
            if (await this.ContainsSettingsKey(key))
            {
                var result = await this.blobSettings.GetObject<T>(key);
                return result;
            }

            return default(T);
        }

        /// <summary>
        /// Deletes the local cache.
        /// </summary>
        /// <returns>The local cache.</returns>
        /// <param name="deleteEverything">If set to <c>true</c> delete everything.</param>
        public async Task DeleteLocalCache(bool deleteEverything = false)
        {
            if (deleteEverything)
            {
                await this.blobCache.InvalidateAll();
            }
            else
            {
                await this.blobCache.InvalidateAllObjects<IEnumerable<Contact>>();
                await this.blobCache.InvalidateAllObjects<EmergencyContactsContent>();
                await this.blobCache.InvalidateAllObjects<RespondContent>();
                await this.blobCache.InvalidateAllObjects<IEnumerable<IncidentType>>();
            }

            await this.blobCache.Vacuum();
        }

        /// <summary>
        /// Containses the key.
        /// </summary>
        /// <returns>The key.</returns>
        /// <param name="key">the Key.</param>
        private async Task<bool> ContainsKey(string key)
        {
            var keys = await this.blobCache.GetAllKeys();

            var result = keys.FirstOrDefault(x => x == key);

            return !string.IsNullOrEmpty(result);
        }

        /// <summary>
        /// Containses the settings key.
        /// </summary>
        /// <returns>The settings key.</returns>
        /// <param name="key">the Key.</param>
        private async Task<bool> ContainsSettingsKey(string key)
        {
            var keys = await this.blobSettings.GetAllKeys();

            var result = keys.FirstOrDefault(x => x == key);

            return !string.IsNullOrEmpty(result);
        }
    }
}
