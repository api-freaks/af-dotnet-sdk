using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(HistoricalWeatherRequestFormat.HistoricalWeatherRequestFormatSerializer))]
[Serializable]
public readonly record struct HistoricalWeatherRequestFormat : IStringEnum
{
    public static readonly HistoricalWeatherRequestFormat Json = new(Values.Json);

    public HistoricalWeatherRequestFormat(string value)
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
    public static HistoricalWeatherRequestFormat FromCustom(string value)
    {
        return new HistoricalWeatherRequestFormat(value);
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

    public static bool operator ==(HistoricalWeatherRequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(HistoricalWeatherRequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(HistoricalWeatherRequestFormat value) => value.Value;

    public static explicit operator HistoricalWeatherRequestFormat(string value) => new(value);

    internal class HistoricalWeatherRequestFormatSerializer
        : JsonConverter<HistoricalWeatherRequestFormat>
    {
        public override HistoricalWeatherRequestFormat Read(
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
            return new HistoricalWeatherRequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            HistoricalWeatherRequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override HistoricalWeatherRequestFormat ReadAsPropertyName(
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
            return new HistoricalWeatherRequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            HistoricalWeatherRequestFormat value,
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
