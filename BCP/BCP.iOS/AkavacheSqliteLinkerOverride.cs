//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AkavacheSqliteLinkerOverride.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AkavacheSqliteLinkerOverride.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.IOS
{
    using System;
    using Akavache.Sqlite3;

    /// <summary>
    /// Linker preserve.
    /// </summary>
    [Preserve]

    public static class LinkerPreserve
    {
        /// <summary>
        /// Initializes the <see cref="T:BCP.IOS.LinkerPreserve"/> class.
        /// </summary>
        static LinkerPreserve()
        {
            throw new Exception(typeof(SQLitePersistentBlobCache).FullName);
        }
    }

    /// <summary>
    /// Preserve attribute.
    /// </summary>
    public class PreserveAttribute : Attribute
    {
    }
}
