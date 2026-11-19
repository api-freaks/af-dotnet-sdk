using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkCurrentWeatherRequest
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Response format returned by the API. Only JSON is supported.
    /// </summary>
    [JsonIgnore]
    public BulkCurrentWeatherRequestFormat? Format { get; set; }

    /// <summary>
    /// Timezone for the results.
    /// </summary>
    [JsonIgnore]
    public string? Timezone { get; set; }

    /// <summary>
    /// Array of locations to fetch weather data for
    /// </summary>
    [JsonPropertyName("locations")]
    public IEnumerable<BulkCurrentWeatherRequestLocationsItem> Locations { get; set; } =
        new List<BulkCurrentWeatherRequestLocationsItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
