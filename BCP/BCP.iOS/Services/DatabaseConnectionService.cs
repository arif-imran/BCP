// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DatabaseConnectionService.cs" company="Grosvenor">
// //   ${CopyrightHolder}
// // </copyright>
// // <summary>
// //   DatabaseConnectionService
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.IOS.Services
{
    using System;
    using System.IO;
    using Grosvenor.Forms.DataAccess.Services;
    using SQLite;

    /// <summary>
    /// Database connection service.
    /// </summary>
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        /// <summary>
        /// Dbs the connection.
        /// </summary>
        /// <returns>The connection.</returns>
        public SQLiteConnection DbConnection()
        {
            var dataBaseName = "BCP.db3";
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dataBaseName);
            return new SQLiteConnection(path);
        }
    }
}