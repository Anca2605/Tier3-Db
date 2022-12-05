using System.Text.Json.Serialization;

namespace Db3.Utility;

public class Network
{
    [JsonPropertyName("type")]
    public string NetworkType { get; set; }
    [JsonPropertyName("content")]
    public string Content { get; set; }
}