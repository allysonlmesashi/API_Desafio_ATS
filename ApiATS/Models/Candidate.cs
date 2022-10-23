using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ATSApi.Models;

public class Candidate
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string FullName { get; set; } = null!;

    public DateTime BirthDayDate { get; set; }

    public string Email { get; set; } = null!;

}