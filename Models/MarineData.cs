using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

public class MarineData
{
    [BsonId] // Required for MongoDB's primary key
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime DateLogged { get; set; } = DateTime.UtcNow;
}
