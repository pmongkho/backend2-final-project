using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DotNetServer.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required string DroneActionId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required string UserId { get; set; }

        public double Amount { get; set; }
        public required string Method { get; set; } // e.g., "credit card", "paypal"
        public required string Status { get; set; } // e.g., "pending", "completed"

        // Stripe-specific fields
        public string StripePaymentIntentId { get; set; } = null!; // Store Stripe payment intent ID
        public string StripeChargeId { get; set; } = null!; // Store Stripe charge ID

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }
    }


}
