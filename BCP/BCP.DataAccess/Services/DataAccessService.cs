//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="DataAccessService.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   DataAccessService.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.DataAccess.Services
{
    using BCP.DataAccess.Model;
    using Grosvenor.Forms.DataAccess.Services;

    /// <summary>
    /// Data access service.
    /// </summary>
    public class DataAccessService : BaseDataAccessService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.DataAccess.Services.DataAccessService"/> class.
        /// </summary>
        /// <param name="databaseConnection">Database connection.</param>
        public DataAccessService(
            IDatabaseConnectionService databaseConnection)
            : base(databaseConnection)
        {
        }

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            this.Database.CreateTable<Settings>();
        }
    }
}