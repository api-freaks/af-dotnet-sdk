using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Mail server infrastructure backing the domain.
/// </summary>
[Serializable]
public record DomainReputationResponseEmailDeliverabilityInfrastructure : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of MX records found for the domain.
    /// </summary>
    [JsonPropertyName("mx_count")]
    public required int MxCount { get; set; }

    /// <summary>
    /// List of mail exchange server hostnames for the domain.
    /// </summary>
    [JsonPropertyName("mx_records")]
    public IEnumerable<string> MxRecords { get; set; } = new List<string>();

    /// <summary>
    /// Email hosting provider inferred from the MX records.
    /// </summary>
    [JsonPropertyName("mx_provider")]
    public required string MxProvider { get; set; }

    /// <summary>
    /// Indicates whether the domain explicitly declines email via a null MX record.
    /// </summary>
    [JsonPropertyName("null_mx")]
    public required bool NullMx { get; set; }

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
