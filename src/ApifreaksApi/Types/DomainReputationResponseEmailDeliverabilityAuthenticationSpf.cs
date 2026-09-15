using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Sender Policy Framework configuration.
/// </summary>
[Serializable]
public record DomainReputationResponseEmailDeliverabilityAuthenticationSpf : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether an SPF record was found.
    /// </summary>
    [JsonPropertyName("present")]
    public required bool Present { get; set; }

    /// <summary>
    /// SPF enforcement policy qualifier found in the record (e.g. ~all, -all).
    /// </summary>
    [JsonPropertyName("policy")]
    public required string Policy { get; set; }

    /// <summary>
    /// Raw SPF DNS TXT record string.
    /// </summary>
    [JsonPropertyName("record")]
    public required string Record { get; set; }

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
