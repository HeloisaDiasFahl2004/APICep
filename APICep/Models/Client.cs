using APICep.Controllers;
using MongoDB.Bson.Serialization.Attributes;

namespace APICep.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Cep { get; set; }
    }
}
