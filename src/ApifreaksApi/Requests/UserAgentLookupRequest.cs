using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record UserAgentLookupRequest
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
    public UserAgentLookupRequestFormat? Format { get; set; }

    /// <summary>
    /// The User-Agent string to parse, sent as the User-Agent HTTP header.
    /// </summary>
    [JsonIgnore]
    public required string UserAgent { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
