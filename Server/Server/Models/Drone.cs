using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotNetServer.Models
{
    public class Drone
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public required DroneVehicle DroneVehicle { get; set; }
        public required string Name { get; set; } //quirky name

        public bool IsActive { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        public required Location Location { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }
    }

    public class DroneVehicle
    {
        public required string Make { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public required string Color { get; set; }
        public required string LicensePlate { get; set; }
    }
}
