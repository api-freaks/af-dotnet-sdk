using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Domain-based Message Authentication, Reporting and Conformance configuration.
/// </summary>
[Serializable]
public record DomainReputationResponseEmailDeliverabilityAuthenticationDmarc : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether a DMARC record was found.
    /// </summary>
    [JsonPropertyName("present")]
    public required bool Present { get; set; }

    /// <summary>
    /// DMARC enforcement policy applied to failing messages (e.g. none, quarantine, reject).
    /// </summary>
    [JsonPropertyName("policy")]
    public required string Policy { get; set; }

    /// <summary>
    /// Indicates whether DMARC aggregate / forensic reporting addresses are configured.
    /// </summary>
    [JsonPropertyName("reporting_configured")]
    public required bool ReportingConfigured { get; set; }

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
