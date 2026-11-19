using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record FloodForecastRequest
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
    public FloodForecastRequestFormat? Format { get; set; }

    /// <summary>
    /// Starting date for flood forecast data in YYYY-MM-DD format. Forecast dates must be current or future dates only. Past dates are not allowed for forecast data. The difference between endDate and startDate must not exceed 16 days.
    /// </summary>
    [JsonIgnore]
    public required DateOnly StartDate { get; set; }

    /// <summary>
    /// End date for flood forecast data in YYYY-MM-DD format. Forecast dates must be current or future dates only. Past dates are not allowed for forecast data. The difference between endDate and startDate must not exceed 16 days.
    /// </summary>
    [JsonIgnore]
    public required DateOnly EndDate { get; set; }

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
    /// Only daily precision is supported; returns flood forecast data for the selected date range.
    /// </summary>
    [JsonIgnore]
    public FloodForecastRequestPrecision? Precision { get; set; }

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
