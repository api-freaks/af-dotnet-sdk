using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Backlink profile of the domain.
/// </summary>
[Serializable]
public record DomainReputationResponseBacklinks : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// true if backlink data exists for the domain. When false, the other fields are null.
    /// </summary>
    [JsonPropertyName("found")]
    public required bool Found { get; set; }

    /// <summary>
    /// Domain the backlink data was matched to (for example `google.com`). null when no data was found.
    /// </summary>
    [JsonPropertyName("matched_domain")]
    public string? MatchedDomain { get; set; }

    /// <summary>
    /// Total number of backlinks pointing to the domain (for example 174614443). null when no data was found.
    /// </summary>
    [JsonPropertyName("backlink_count")]
    public int? BacklinkCount { get; set; }

    /// <summary>
    /// Number of distinct domains linking to the domain (for example 4336653). null when no data was found.
    /// </summary>
    [JsonPropertyName("referring_domains")]
    public int? ReferringDomains { get; set; }

    /// <summary>
    /// Average number of backlinks per referring domain (backlink_count / referring_domains, for example 40.26). null when no data was found.
    /// </summary>
    [JsonPropertyName("referrer_link_density")]
    public double? ReferrerLinkDensity { get; set; }

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
