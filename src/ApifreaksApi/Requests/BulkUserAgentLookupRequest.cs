using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkUserAgentLookupRequest
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Format of the response
    /// </summary>
    [JsonIgnore]
    public BulkUserAgentLookupRequestFormat? Format { get; set; }

    /// <summary>
    /// Array of User-Agent strings to parse. Maximum 100 strings per request — exceeding that returns a 413.
    /// </summary>
    [JsonPropertyName("uaStrings")]
    public IEnumerable<string> UaStrings { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
