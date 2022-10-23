using MongoDB.Bson.Serialization.Attributes;

namespace APICep.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation((MongoDB.Bson.BsonType.ObjectId))]
        public string Id { get; set; }
        public string Cep { get; set; }
    }
}