using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tier3_Db.Models.Bill;

public class Bill
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("dob")]
    public string dob { get; set; }
    [JsonPropertyName("phonenumber")]
    public string phonenumber { get; set; }
    [JsonPropertyName("totalAmount")]
    public int totalAmount { get; set; }
    [JsonPropertyName("provider")]
    public string provider { get; set; }
    [JsonPropertyName("date")]
    public DateTime date { get; set; }
}
