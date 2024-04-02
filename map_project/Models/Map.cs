namespace map_project.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Map
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("clientName")]
        public string ClientName { get; set; }

        [BsonElement("numsOfMember")]
        public int NumsOfMember { get; set; }

        [BsonElement("objectTitle")]
        public string ObjectTitle { get; set; }

        [BsonElement("creatorName")]
        public string CreatorName { get; set; }

        [BsonElement("creationTime")]
        public DateTime CreationTime { get; set; }

        [BsonElement("records")]
        public List<Record> Records { get; set; }
    }

}
