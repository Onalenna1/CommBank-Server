using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CommBank.Models
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        [Required]
        public TransactionType TransactionType { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public double Amount { get; set; } = 0.00;

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateTime { get; set; } = DateTime.UtcNow;

        [BsonRepresentation(BsonType.ObjectId)]
        public string? GoalId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string[]? TagIds { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
