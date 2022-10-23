using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ATSApi.Models;

public class Position
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Description { get; set; } = null!;

    public bool IsOpen { get; set; }


}