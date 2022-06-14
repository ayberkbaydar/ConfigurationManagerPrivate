using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConfigurationManager.Core.Models
{
    public class User
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        public Draft Draft { get; set; }
        //public List<File> FileAuthorization { get; set; }
        //public List<Section> SectionAuthorization { get; set; }
        public Instance Instance { get; set; }
        [BsonElement("instanceId")]
        public int? InstanceId { get; set; }
        public Type Type { get; set; }
        [BsonElement("typeId")]
        public int TypeId { get; set; }
    }
}
