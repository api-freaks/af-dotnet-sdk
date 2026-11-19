using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(WeatherTimeSeriesRequestFormat.WeatherTimeSeriesRequestFormatSerializer))]
[Serializable]
public readonly record struct WeatherTimeSeriesRequestFormat : IStringEnum
{
    public static readonly WeatherTimeSeriesRequestFormat Json = new(Values.Json);

    public WeatherTimeSeriesRequestFormat(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static WeatherTimeSeriesRequestFormat FromCustom(string value)
    {
        return new WeatherTimeSeriesRequestFormat(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(WeatherTimeSeriesRequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WeatherTimeSeriesRequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WeatherTimeSeriesRequestFormat value) => value.Value;

    public static explicit operator WeatherTimeSeriesRequestFormat(string value) => new(value);

    internal class WeatherTimeSeriesRequestFormatSerializer
        : JsonConverter<WeatherTimeSeriesRequestFormat>
    {
        public override WeatherTimeSeriesRequestFormat Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new WeatherTimeSeriesRequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WeatherTimeSeriesRequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WeatherTimeSeriesRequestFormat ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new WeatherTimeSeriesRequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WeatherTimeSeriesRequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Json = "json";
    }
}
