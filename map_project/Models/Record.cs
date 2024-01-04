using MongoDB.Bson.Serialization.Attributes;

namespace map_project.Models
{
    public class UserEvent
    {
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
    }
    public class Record
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("dob")]
        public DateTime Dob { get; set; }

        [BsonElement("gender")]
        public int Gender { get; set; }

        [BsonElement("settings")]
        public List<Setting> Settings { get; set; }

        [BsonElement("events")]
        public List<UserEvent> Events { get; set; }
    }
}
