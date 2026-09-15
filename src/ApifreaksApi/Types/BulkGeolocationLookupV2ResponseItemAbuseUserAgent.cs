using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Parsed User-Agent details from the request.
/// </summary>
[Serializable]
public record BulkGeolocationLookupV2ResponseItemAbuseUserAgent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Raw User-Agent string used for parsing.
    /// </summary>
    [JsonPropertyName("user_agent_string")]
    public string? UserAgentString { get; set; }

    /// <summary>
    /// Detected user agent product name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// User agent category (e.g., Browser, Mobile App, Bot).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Full product version string.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// Major version extracted from version.
    /// </summary>
    [JsonPropertyName("version_major")]
    public string? VersionMajor { get; set; }

    /// <summary>
    /// Device details.
    /// </summary>
    [JsonPropertyName("device")]
    public BulkGeolocationLookupV2ResponseItemAbuseUserAgentDevice? Device { get; set; }

    /// <summary>
    /// Rendering engine details.
    /// </summary>
    [JsonPropertyName("engine")]
    public BulkGeolocationLookupV2ResponseItemAbuseUserAgentEngine? Engine { get; set; }

    /// <summary>
    /// Operating system details.
    /// </summary>
    [JsonPropertyName("operating_system")]
    public BulkGeolocationLookupV2ResponseItemAbuseUserAgentOperatingSystem? OperatingSystem { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
