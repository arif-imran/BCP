//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="SharedConfig.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   SharedConfig.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Common
{
    using System;

    /// <summary>
    /// Shared config.
    /// </summary>
    public static class SharedConfig
    {
        /// <summary>
        /// Gets the API End point.
        /// </summary>
        /// <value>The API End point.</value>
        public static string APIEndPoint
        {
            get
            {
#if DEVELOPMENT
                return "http://gasiabcpapitest.grosvenor.com/";
#elif STAGING
                return "http://gasiabcpapiuat.grosvenor.com/";
#elif PRODUCTION
                return "http://productionurl/";
#else
                return "http://defaulturl/";
#endif
            }
        }

        /// <summary>
        /// Gets the service account username.
        /// </summary>
        /// <value>The service account username.</value>
        public static string ServiceAccountUsername
        {
            get
            {
                return "GAsiaBCP.Service";
            }
        }

        /// <summary>
        /// Gets the service account password.
        /// </summary>
        /// <value>The service account password.</value>
        public static string ServiceAccountPassword
        {
            get
            {
                return "KHbpgtt8Uz0h";
            }
        }

        /// <summary>
        /// Gets the cache time out.
        /// </summary>
        /// <value>The cache time out.</value>
        public static TimeSpan CacheTimeOut
        {
            get
            {
                return TimeSpan.FromDays(5);
            }
        }

        /// <summary>
        /// Gets the application insights identifier.
        /// </summary>
        /// <value>The application insights identifier.</value>
        public static string ApplicationInsightsId
        {
            get
            {
                // TODO this is dev only. 
                return "2941bae7-b55c-4998-acb6-c3e28e57470a";
            }
        }

        /// <summary>
        /// Gets the fake delay.
        /// </summary>
        /// <value>The fake delay.</value>
        public static int FakeDelay
        {
            get
            {
                return 1000;
            }
        }
    }
}
