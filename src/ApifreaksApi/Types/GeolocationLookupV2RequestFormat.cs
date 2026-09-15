using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(GeolocationLookupV2RequestFormat.GeolocationLookupV2RequestFormatSerializer))]
[Serializable]
public readonly record struct GeolocationLookupV2RequestFormat : IStringEnum
{
    public static readonly GeolocationLookupV2RequestFormat Json = new(Values.Json);

    public static readonly GeolocationLookupV2RequestFormat Xml = new(Values.Xml);

    public GeolocationLookupV2RequestFormat(string value)
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
    public static GeolocationLookupV2RequestFormat FromCustom(string value)
    {
        return new GeolocationLookupV2RequestFormat(value);
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

    public static bool operator ==(GeolocationLookupV2RequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GeolocationLookupV2RequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GeolocationLookupV2RequestFormat value) => value.Value;

    public static explicit operator GeolocationLookupV2RequestFormat(string value) => new(value);

    internal class GeolocationLookupV2RequestFormatSerializer
        : JsonConverter<GeolocationLookupV2RequestFormat>
    {
        public override GeolocationLookupV2RequestFormat Read(
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
            return new GeolocationLookupV2RequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GeolocationLookupV2RequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GeolocationLookupV2RequestFormat ReadAsPropertyName(
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
            return new GeolocationLookupV2RequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GeolocationLookupV2RequestFormat value,
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
