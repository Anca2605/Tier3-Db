using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tier3_Db.Models.Bill;

public class Bill
{
    public Bill(int billid, int clientid, double total)
    {
        this.billid = billid;
        this.clientid = clientid;
        this.total = total;
        this.provider = "rent";
    }

    [Key]
    [JsonPropertyName("billid")]
    public int billid { get; set; }
    [Required]
    [JsonPropertyName("clientid")] 
    public int clientid { get; set; }
    [JsonPropertyName("total")]
    public double total { get; set; }
    [JsonPropertyName("provider")]
    public string provider { get; set; }
    [JsonPropertyName("priceperitem")]
    public double priceperitem { get; set; }
    [JsonPropertyName("billingdate")]
    public DateTime billingdate { get; set; }
    [JsonPropertyName("duedate")]
    public DateTime duedate { get; set; }
    [JsonPropertyName("bills")]
    public List<Bill> viewbills{ get; set; }
    [JsonPropertyName("amount")]
    public double amount { get; set; }
    [JsonPropertyName("paidstatus")]
    public bool paidstatus { get; set; }
    
    
}
