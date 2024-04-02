namespace map_project.Models
{
    public class MongoDBSettings
    {

        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string MapsCollectionName { get; set; } = null!;
        public string SettingsCollectionName { get; set; } = null!;
        public string EventsCollectionName { get; set; } = null!;
    }
}
