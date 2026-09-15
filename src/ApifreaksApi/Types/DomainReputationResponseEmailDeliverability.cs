using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Assessment of the domain's ability to send and receive email reliably.
/// </summary>
[Serializable]
public record DomainReputationResponseEmailDeliverability : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Overall email deliverability score out of 100.
    /// </summary>
    [JsonPropertyName("score")]
    public required int Score { get; set; }

    /// <summary>
    /// Letter / word grade summarizing the deliverability score.
    /// </summary>
    [JsonPropertyName("grade")]
    public required string Grade { get; set; }

    /// <summary>
    /// Indicates whether the domain is configured to receive email.
    /// </summary>
    [JsonPropertyName("can_receive_email")]
    public required bool CanReceiveEmail { get; set; }

    /// <summary>
    /// Email authentication mechanisms configured for the domain.
    /// </summary>
    [JsonPropertyName("authentication")]
    public required DomainReputationResponseEmailDeliverabilityAuthentication Authentication { get; set; }

    /// <summary>
    /// Mail server infrastructure backing the domain.
    /// </summary>
    [JsonPropertyName("infrastructure")]
    public required DomainReputationResponseEmailDeliverabilityInfrastructure Infrastructure { get; set; }

    /// <summary>
    /// Reputation and trust signals related to the domain's email sending history.
    /// </summary>
    [JsonPropertyName("reputation")]
    public required DomainReputationResponseEmailDeliverabilityReputation Reputation { get; set; }

    /// <summary>
    /// List of detected email deliverability issues or misconfigurations.
    /// </summary>
    [JsonPropertyName("issues")]
    public IEnumerable<DomainReputationResponseEmailDeliverabilityIssuesItem> Issues { get; set; } =
        new List<DomainReputationResponseEmailDeliverabilityIssuesItem>();

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
