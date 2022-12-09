using System.Text.Json.Serialization;

namespace Db3.Utility;

public class NetworkPackage
{
    [JsonPropertyName("type")] public NetworkType Type { get; set; }
    [JsonPropertyName("content")] public string Content { get; set; }

    public NetworkPackage(NetworkType type, string content)
    {
        Type = type;
        Content = content;
    }

    public override string ToString()
    {
        return "NetworkPackage{" + "type=" + Type + ", content=" + Content + '}';
    }
}