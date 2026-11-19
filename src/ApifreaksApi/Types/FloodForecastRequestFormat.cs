using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(FloodForecastRequestFormat.FloodForecastRequestFormatSerializer))]
[Serializable]
public readonly record struct FloodForecastRequestFormat : IStringEnum
{
    public static readonly FloodForecastRequestFormat Json = new(Values.Json);

    public FloodForecastRequestFormat(string value)
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
    public static FloodForecastRequestFormat FromCustom(string value)
    {
        return new FloodForecastRequestFormat(value);
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

    public static bool operator ==(FloodForecastRequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FloodForecastRequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FloodForecastRequestFormat value) => value.Value;

    public static explicit operator FloodForecastRequestFormat(string value) => new(value);

    internal class FloodForecastRequestFormatSerializer : JsonConverter<FloodForecastRequestFormat>
    {
        public override FloodForecastRequestFormat Read(
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
            return new FloodForecastRequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FloodForecastRequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FloodForecastRequestFormat ReadAsPropertyName(
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
            return new FloodForecastRequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FloodForecastRequestFormat value,
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
