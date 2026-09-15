using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(AstronomyLookupV2RequestFormat.AstronomyLookupV2RequestFormatSerializer))]
[Serializable]
public readonly record struct AstronomyLookupV2RequestFormat : IStringEnum
{
    public static readonly AstronomyLookupV2RequestFormat Json = new(Values.Json);

    public static readonly AstronomyLookupV2RequestFormat Xml = new(Values.Xml);

    public AstronomyLookupV2RequestFormat(string value)
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
    public static AstronomyLookupV2RequestFormat FromCustom(string value)
    {
        return new AstronomyLookupV2RequestFormat(value);
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

    public static bool operator ==(AstronomyLookupV2RequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstronomyLookupV2RequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstronomyLookupV2RequestFormat value) => value.Value;

    public static explicit operator AstronomyLookupV2RequestFormat(string value) => new(value);

    internal class AstronomyLookupV2RequestFormatSerializer
        : JsonConverter<AstronomyLookupV2RequestFormat>
    {
        public override AstronomyLookupV2RequestFormat Read(
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
            return new AstronomyLookupV2RequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstronomyLookupV2RequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstronomyLookupV2RequestFormat ReadAsPropertyName(
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
            return new AstronomyLookupV2RequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstronomyLookupV2RequestFormat value,
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

        public const string Xml = "xml";
    }
}
