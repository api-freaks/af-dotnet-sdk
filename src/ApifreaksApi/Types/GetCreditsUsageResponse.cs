using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Credit balances for the organization's subscription, subscription surcharge, and one-off purchases.
/// </summary>
[Serializable]
public record GetCreditsUsageResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The API key the credit balances belong to.
    /// </summary>
    [JsonPropertyName("apiKey")]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Status of the user account.
    /// </summary>
    [JsonPropertyName("userStatus")]
    public required GetCreditsUsageResponseUserStatus UserStatus { get; set; }

    /// <summary>
    /// Whether a subscription plan is currently active. Null if the account has no subscription.
    /// </summary>
    [JsonPropertyName("subActive")]
    public bool? SubActive { get; set; }

    /// <summary>
    /// Status of the subscription credits. Null if the account has no subscription.
    /// </summary>
    [JsonPropertyName("subStatus")]
    public GetCreditsUsageResponseSubStatus? SubStatus { get; set; }

    /// <summary>
    /// Total credits allowed under the subscription plan. Null if the account has no subscription.
    /// </summary>
    [JsonPropertyName("subAllowedCredits")]
    public int? SubAllowedCredits { get; set; }

    /// <summary>
    /// Credits consumed under the subscription plan. Null if the account has no subscription.
    /// </summary>
    [JsonPropertyName("subUsedCredits")]
    public int? SubUsedCredits { get; set; }

    /// <summary>
    /// Status of the subscription surcharge (overage) credits. Null if the account has no subscription.
    /// </summary>
    [JsonPropertyName("subSurchargeStatus")]
    public GetCreditsUsageResponseSubSurchargeStatus? SubSurchargeStatus { get; set; }

    /// <summary>
    /// Total surcharge credits allowed. Null if the account has no subscription.
    /// </summary>
    [JsonPropertyName("subSurchargeAllowedCredits")]
    public int? SubSurchargeAllowedCredits { get; set; }

    /// <summary>
    /// Surcharge credits consumed. Null if the account has no subscription.
    /// </summary>
    [JsonPropertyName("subSurchargeUsedCredits")]
    public int? SubSurchargeUsedCredits { get; set; }

    /// <summary>
    /// Whether surcharge (overage) usage is allowed on the subscription. Null if the account has no subscription.
    /// </summary>
    [JsonPropertyName("subSurchargeAllowed")]
    public bool? SubSurchargeAllowed { get; set; }

    /// <summary>
    /// Whether the account has active one-off (pay-as-you-go) credits.
    /// </summary>
    [JsonPropertyName("oneOffCreditsActive")]
    public required bool OneOffCreditsActive { get; set; }

    /// <summary>
    /// Total one-off credits purchased.
    /// </summary>
    [JsonPropertyName("oneOffAllowedCredits")]
    public required int OneOffAllowedCredits { get; set; }

    /// <summary>
    /// One-off credits consumed.
    /// </summary>
    [JsonPropertyName("oneOffUsedCredits")]
    public required int OneOffUsedCredits { get; set; }

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
