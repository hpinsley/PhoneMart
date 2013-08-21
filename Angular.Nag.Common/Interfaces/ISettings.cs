namespace Angular.Nag.Common.Interfaces {
    public interface ISettings {
        bool InitializeDatabase { get; }
        string ConnectionString { get; }
    }
}