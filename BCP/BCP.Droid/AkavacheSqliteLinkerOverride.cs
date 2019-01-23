//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="AkavacheSqliteLinkerOverride.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   AkavacheSqliteLinkerOverride.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

//// Note: This class file is *required* for iOS to work correctly, and is 
//// also a good idea for Android if you enable "Link All Assemblies".
namespace BCP.Droid
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
        /// Initializes the <see cref="T:BCP.Droid.LinkerPreserve"/> class.
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
