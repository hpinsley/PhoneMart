using System;
using Angular.Nag.Common.Interfaces;
using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories
{
    /// <summary>
    /// The Code Camper "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Person"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in Code Camper).
    /// </remarks>
    public class CodeCamperUow : ICodeCamperUow, IDisposable
    {
        private readonly ISettings _settings;
        private IRepositoryProvider RepositoryProvider { get; set; }

        public CodeCamperUow(IRepositoryProvider repositoryProvider, ISettings settings) {
            _settings = settings;
            System.Diagnostics.Trace.WriteLine("*** In UOW Constructor ***");

            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;       
        }

        // Code Camper repositories

        //public IRepository<Phone> Phones { get { return GetStandardRepo<Phone>(); } }
        public IPhonesRepository Phones { get { return GetRepo<IPhonesRepository>(); } }
        public IPlansRepository Plans { get { return GetRepo<IPlansRepository>(); } }
        public IAccountsRepository Accounts { get { return GetRepo<IAccountsRepository>(); } }
        public IAppsRepository Apps { get { return GetRepo<IAppsRepository>(); } }
        public IAccessoriesRepository Accessories { get { return GetRepo<IAccessoriesRepository>(); } }

        public IRepository<Manufacturer> Manufacturers {
            get { return GetStandardRepo<Manufacturer>(); }
        }

        public PhoneDb PhoneDb { get { return DbContext; } }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            DbContext.SaveChanges();
        }

        protected void CreateDbContext() {
            string connectionString = _settings.ConnectionString;
            DbContext = new PhoneDb(connectionString);

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }


        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private PhoneDb DbContext { get; set; }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}