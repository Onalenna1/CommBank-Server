using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommBank.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)] // Limit the maximum length of the name
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? AccountIds { get; set; } = new List<string>(); // Initialize to avoid null reference

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? GoalIds { get; set; } = new List<string>(); // Initialize to avoid null reference

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? TransactionIds { get; set; } = new List<string>(); // Initialize to avoid null reference

        // Optional constructor for easier initialization
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            AccountIds = new List<string>();
            GoalIds = new List<string>();
            TransactionIds = new List<string>();
        }
    }
}
