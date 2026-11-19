using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(MarineWeatherRequestFormat.MarineWeatherRequestFormatSerializer))]
[Serializable]
public readonly record struct MarineWeatherRequestFormat : IStringEnum
{
    public static readonly MarineWeatherRequestFormat Json = new(Values.Json);

    public MarineWeatherRequestFormat(string value)
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
    public static MarineWeatherRequestFormat FromCustom(string value)
    {
        return new MarineWeatherRequestFormat(value);
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

    public static bool operator ==(MarineWeatherRequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MarineWeatherRequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MarineWeatherRequestFormat value) => value.Value;

    public static explicit operator MarineWeatherRequestFormat(string value) => new(value);

    internal class MarineWeatherRequestFormatSerializer : JsonConverter<MarineWeatherRequestFormat>
    {
        public override MarineWeatherRequestFormat Read(
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
            return new MarineWeatherRequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MarineWeatherRequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MarineWeatherRequestFormat ReadAsPropertyName(
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
            return new MarineWeatherRequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MarineWeatherRequestFormat value,
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
