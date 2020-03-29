namespace HackCOVID19.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ProductsCollectionName { get; set; }
        public string SuppliersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string ProductsCollectionName { get; set; }
        string SuppliersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}