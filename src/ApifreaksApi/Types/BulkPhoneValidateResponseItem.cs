using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkPhoneValidateResponseItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The original request data provided by the client.
    /// </summary>
    [JsonPropertyName("raw_input")]
    public BulkPhoneValidateResponseItemRawInput? RawInput { get; set; }

    /// <summary>
    /// Whether the number passes length and format checks.
    /// </summary>
    [JsonPropertyName("possible")]
    public bool? Possible { get; set; }

    /// <summary>
    /// Whether the number is valid according to the numbering plan.
    /// </summary>
    [JsonPropertyName("valid")]
    public bool? Valid { get; set; }

    /// <summary>
    /// International dialing prefix for the number's country.
    /// </summary>
    [JsonPropertyName("country_prefix")]
    public int? CountryPrefix { get; set; }

    /// <summary>
    /// National significant number without the country code.
    /// </summary>
    [JsonPropertyName("national_number")]
    public long? NationalNumber { get; set; }

    /// <summary>
    /// ISO-2 country code inferred from the number.
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Carrier name associated with the number.
    /// </summary>
    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    /// <summary>
    /// Geographic description (city/region) for the number.
    /// </summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>
    /// Array of possible IANA time zones associated with the number.
    /// </summary>
    [JsonPropertyName("time_zones")]
    public IEnumerable<string>? TimeZones { get; set; }

    /// <summary>
    /// Classification of the phone line.
    /// </summary>
    [JsonPropertyName("line_type")]
    public BulkPhoneValidateResponseItemLineType? LineType { get; set; }

    /// <summary>
    /// The number represented in four standardized formats. Only returned for valid numbers.
    /// </summary>
    [JsonPropertyName("formats")]
    public BulkPhoneValidateResponseItemFormats? Formats { get; set; }

    /// <summary>
    /// Length of the geographic area code. Only for geographically-assigned numbers.
    /// </summary>
    [JsonPropertyName("area_code_length")]
    public int? AreaCodeLength { get; set; }

    /// <summary>
    /// Length of the National Destination Code.
    /// </summary>
    [JsonPropertyName("ndc_length")]
    public int? NdcLength { get; set; }

    /// <summary>
    /// Whether the number can be dialled internationally.
    /// </summary>
    [JsonPropertyName("can_be_internationally_dialled")]
    public bool? CanBeInternationallyDialled { get; set; }

    /// <summary>
    /// Short error category. Present only when this item failed validation (e.g. malformed number, conflicting region parameters).
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// Human-readable reason for failure. Present only when this item failed validation.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

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
