using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CommBank.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Account number is required.")]
        public long? Number { get; set; }

        [Required(ErrorMessage = "Account name is required.")]
        [MaxLength(100)] // Maximum length set as an example
        public string? Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance must be non-negative.")]
        public double Balance { get; set; } = 0;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public AccountType AccountType { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? TransactionIds { get; set; } = new List<string>(); // Initialize to avoid null reference

        // Optional constructor for easier initialization
        public Account(long? number, string name, AccountType accountType)
        {
            Number = number;
            Name = name;
            AccountType = accountType;
            TransactionIds = new List<string>();
        }
    }

    public enum AccountType
    {
        Savings,
        Checking,
        Business,
        // Add other account types as needed
    }
}
