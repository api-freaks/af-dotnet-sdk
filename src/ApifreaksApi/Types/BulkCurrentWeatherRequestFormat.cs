using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(BulkCurrentWeatherRequestFormat.BulkCurrentWeatherRequestFormatSerializer))]
[Serializable]
public readonly record struct BulkCurrentWeatherRequestFormat : IStringEnum
{
    public static readonly BulkCurrentWeatherRequestFormat Json = new(Values.Json);

    public BulkCurrentWeatherRequestFormat(string value)
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
    public static BulkCurrentWeatherRequestFormat FromCustom(string value)
    {
        return new BulkCurrentWeatherRequestFormat(value);
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

    public static bool operator ==(BulkCurrentWeatherRequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BulkCurrentWeatherRequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BulkCurrentWeatherRequestFormat value) => value.Value;

    public static explicit operator BulkCurrentWeatherRequestFormat(string value) => new(value);

    internal class BulkCurrentWeatherRequestFormatSerializer
        : JsonConverter<BulkCurrentWeatherRequestFormat>
    {
        public override BulkCurrentWeatherRequestFormat Read(
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
            return new BulkCurrentWeatherRequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkCurrentWeatherRequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkCurrentWeatherRequestFormat ReadAsPropertyName(
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
            return new BulkCurrentWeatherRequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkCurrentWeatherRequestFormat value,
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
