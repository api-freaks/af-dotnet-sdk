using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Per-item error, returned in place of a WHOIS result when an individual domain's extension is unsupported or its lookup otherwise fails.
/// </summary>
[Serializable]
public record BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Always false for a per-item error.
    /// </summary>
    [JsonPropertyName("status")]
    public required bool Status { get; set; }

    /// <summary>
    /// Domain name that this error applies to.
    /// </summary>
    [JsonPropertyName("domain_name")]
    public required string DomainName { get; set; }

    /// <summary>
    /// HTTP-equivalent status code for this item's failure (e.g. 403 for an unsupported extension).
    /// </summary>
    [JsonPropertyName("status_code")]
    public required int StatusCode { get; set; }

    /// <summary>
    /// Short error category or exception type.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// Human-readable reason this domain could not be resolved.
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; set; }

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
