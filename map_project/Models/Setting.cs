using MongoDB.Bson.Serialization.Attributes;

namespace map_project.Models
{
    public class Setting
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("ageOfMale")]
        public int AgeOfMale { get; set; }

        [BsonElement("ageOfFemale")]
        public int AgeOfFemale { get; set; }

        [BsonElement("imageSrc")]
        public string ImageSrc { get; set; }
    }
}
