using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DotNetServer.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public required string Password { get; set; } // Store hashed password
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Username { get; set; }
                // Stripe related properties
        public string? StripeCustomerId { get; set; } // For storing Stripe Customer ID

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }
    }
}
