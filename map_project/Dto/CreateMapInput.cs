using map_project.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace map_project.Dto
{
    public class CreateMapInput
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public int NumsOfMember { get; set; }
        public string ObjectTitle { get; set; }
        public string CreatorName { get; set; }
        public string CreationTime { get; set; }
        public List<Record> Records { get; set; }
    }
}
