using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Email authentication mechanisms configured for the domain.
/// </summary>
[Serializable]
public record DomainReputationResponseEmailDeliverabilityAuthentication : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Sender Policy Framework configuration.
    /// </summary>
    [JsonPropertyName("spf")]
    public required DomainReputationResponseEmailDeliverabilityAuthenticationSpf Spf { get; set; }

    /// <summary>
    /// DomainKeys Identified Mail configuration.
    /// </summary>
    [JsonPropertyName("dkim")]
    public required DomainReputationResponseEmailDeliverabilityAuthenticationDkim Dkim { get; set; }

    /// <summary>
    /// Domain-based Message Authentication, Reporting and Conformance configuration.
    /// </summary>
    [JsonPropertyName("dmarc")]
    public required DomainReputationResponseEmailDeliverabilityAuthenticationDmarc Dmarc { get; set; }

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
