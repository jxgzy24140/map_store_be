using MongoDB.Bson.Serialization.Attributes;

namespace map_project.Models
{
    public class Event
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("imageSrc")]
        public string ImageSrc { get; set; }
    }
}
