namespace ATSApi.Models
{
    public class CandidateDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CandidatesCollectionName { get; set; } = null!;
    }
}
