using Angular.Nag.Models;

namespace Angular.Nag.Data.Repositories
{
    /// <summary>
    /// Interface for the Code Camper "Unit of Work"
    /// </summary>
    public interface ICodeCamperUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IAccountsRepository Accounts { get; }
        IAppsRepository Apps { get; }
        IRepository<Manufacturer> Manufacturers { get; }
        IPhonesRepository Phones { get; }
        IPlansRepository Plans { get; }
        PhoneDb PhoneDb { get; }
    }
}