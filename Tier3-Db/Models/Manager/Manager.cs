using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Db3.Models.Manager;

public class Manager
{
    [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("username"), Required]
        public string Username { get; set; }
        [JsonPropertyName("password"), Required]
        public string Password { get; set; }
        
}