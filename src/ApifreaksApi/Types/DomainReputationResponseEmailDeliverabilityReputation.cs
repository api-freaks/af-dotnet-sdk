using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Reputation and trust signals related to the domain's email sending history.
/// </summary>
[Serializable]
public record DomainReputationResponseEmailDeliverabilityReputation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether the domain appears on known spam blacklists.
    /// </summary>
    [JsonPropertyName("spam_blacklisted")]
    public required bool SpamBlacklisted { get; set; }

    /// <summary>
    /// Indicates whether the domain was registered recently.
    /// </summary>
    [JsonPropertyName("newly_registered")]
    public required bool NewlyRegistered { get; set; }

    /// <summary>
    /// Age of the domain in days since registration.
    /// </summary>
    [JsonPropertyName("domain_age_days")]
    public int? DomainAgeDays { get; set; }

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
