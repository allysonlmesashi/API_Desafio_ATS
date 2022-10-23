namespace ATSApi.Models
{
    public class PositionDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PositionsCollectionName { get; set; } = null!;
    }
}
