using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    /*[NotMapped]
    [JsonPropertyName("bills")]
    public List<Bill> bills { get; set; }*/
    [NotMapped]
    [JsonPropertyName("subscription")]
    public bool[] subscription { get; set; }
    
    public bool IsSubToElectricity { get; set; }
    public bool IsSubToWater { get; set; }
    public bool IsSubToHeating { get; set; }
    public bool IsSubToRent { get; set; }
    
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
        subscription = new [] {false,false,false,false };
        IsSubToElectricity = subscription[0];
        IsSubToHeating = subscription[1];
        IsSubToRent = subscription[2];
        IsSubToWater = subscription[3];

    }

    public Client()
    {
    }
    
    //implement the subscription part
}
