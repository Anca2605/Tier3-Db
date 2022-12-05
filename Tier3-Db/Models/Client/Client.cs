using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Db3.Models.Client;

public class Client
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [Required]
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [Required]
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("email")]
    public string dob { get; set; }
    [JsonPropertyName("email")]
    public string phonenumber { get; set; }
}
