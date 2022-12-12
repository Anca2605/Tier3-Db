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
    [JsonPropertyName("subscription")]
    public bool[] subscription { get; set; }
    
    public async Task<List<Bill>> viewbills(int parse)
    {
        throw new NotImplementedException();
    }

    public Client(int id, string username, string name, string password, string email, string dob, string phonenumber)
    {
        Id = id;
        Username = username;
        Name = name;
        Password = password;
        Email = email;
        this.dob = dob;
        this.phonenumber = phonenumber;

    }

    public Client()
    {
    }
    
    //implement the subscription part
}
