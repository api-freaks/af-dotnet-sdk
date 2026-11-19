using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record HistoricalWeatherRequest
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
    public HistoricalWeatherRequestFormat? Format { get; set; }

    /// <summary>
    /// Specific date for which to fetch weather data in YYYY-MM-DD format. Historical dates must be past dates only. Current or future dates are not allowed for historical data. Data available from 1940 onwards.
    /// </summary>
    [JsonIgnore]
    public required DateOnly Date { get; set; }

    /// <summary>
    /// City name, place name, or full address.
    /// </summary>
    [JsonIgnore]
    public string? Location { get; set; }

    /// <summary>
    /// Latitude of the location.
    /// </summary>
    [JsonIgnore]
    public double? Lat { get; set; }

    /// <summary>
    /// Longitude of the location.
    /// </summary>
    [JsonIgnore]
    public double? Long { get; set; }

    /// <summary>
    /// IP(v4 or v6) address for location inference.
    /// </summary>
    [JsonIgnore]
    public string? Ip { get; set; }

    /// <summary>
    /// Precision of the historical data. **Note:** 'daily' returns daily aggregates, 'hourly' returns hourly data.
    /// </summary>
    [JsonIgnore]
    public HistoricalWeatherRequestPrecision? Precision { get; set; }

    /// <summary>
    /// Timezone for the results.
    /// </summary>
    [JsonIgnore]
    public string? Timezone { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
