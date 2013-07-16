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
        IPlansRepository Plans { get; }
        //IRepository<Room> Rooms { get; }
    }
}