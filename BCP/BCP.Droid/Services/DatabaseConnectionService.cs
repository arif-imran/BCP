// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DatabaseConnectionService.cs" company="Grosvenor">
// //   
// // </copyright>
// // <summary>
// //   DatabaseConnectionService
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Droid.Services
{
    using System;
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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return new SQLiteConnection(System.IO.Path.Combine(path, dataBaseName));
        }
    }
}
