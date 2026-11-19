using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CurrentWeatherRequest
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
    public CurrentWeatherRequestFormat? Format { get; set; }

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
