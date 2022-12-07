using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tier3_Db.Models.Bill;

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
    [JsonPropertyName("dob")]
    public string dob { get; set; }
    [JsonPropertyName("phonenumber")]
    public string phonenumber { get; set; }
    [JsonPropertyName("bills")]
    public List<Bill> bills { get; set; }

    public async Task<List<Bill>> ViewBills(int parse)
    {
        throw new NotImplementedException();
    }
}
