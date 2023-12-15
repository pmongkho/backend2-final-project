using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DotNetServer.Models
{
    public class DroneAction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required string UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required string DroneId { get; set; }

        public required Location StartLocation { get; set; }
        public required Location EndLocation { get; set; }
        public required string Service { get; set; }
        public required int Duration { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime StartTime { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndTime { get; set; }

        public required string Status { get; set; } // e.g., "requested", "ongoing", "completed", "cancelled"
        public double Fare { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
