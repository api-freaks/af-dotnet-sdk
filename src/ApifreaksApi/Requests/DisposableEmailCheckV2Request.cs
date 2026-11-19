using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DisposableEmailCheckV2Request
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Format of the response.
    /// </summary>
    [JsonIgnore]
    public DisposableEmailCheckV2RequestFormat? Format { get; set; }

    /// <summary>
    /// The email address to check.
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <summary>
    /// Optional IP address to look up for location and security data, such as the IP the signup came from.
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
