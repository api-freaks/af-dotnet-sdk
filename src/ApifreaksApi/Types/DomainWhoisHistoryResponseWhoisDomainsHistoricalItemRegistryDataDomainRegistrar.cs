using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainWhoisHistoryResponseWhoisDomainsHistoricalItemRegistryDataDomainRegistrar
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("iana_id")]
    public string? IanaId { get; set; }

    [JsonPropertyName("registrar_name")]
    public string? RegistrarName { get; set; }

    [JsonPropertyName("whois_server")]
    public string? WhoisServer { get; set; }

    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Registrar handle as published in the snapshot, when present (for example `292`, usually the same as `iana_id`).
    /// </summary>
    [JsonPropertyName("handle")]
    public string? Handle { get; set; }

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
