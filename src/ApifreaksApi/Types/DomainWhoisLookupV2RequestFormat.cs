using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(DomainWhoisLookupV2RequestFormat.DomainWhoisLookupV2RequestFormatSerializer))]
[Serializable]
public readonly record struct DomainWhoisLookupV2RequestFormat : IStringEnum
{
    public static readonly DomainWhoisLookupV2RequestFormat Json = new(Values.Json);

    public static readonly DomainWhoisLookupV2RequestFormat Xml = new(Values.Xml);

    public DomainWhoisLookupV2RequestFormat(string value)
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
    public static DomainWhoisLookupV2RequestFormat FromCustom(string value)
    {
        return new DomainWhoisLookupV2RequestFormat(value);
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

    public static bool operator ==(DomainWhoisLookupV2RequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DomainWhoisLookupV2RequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DomainWhoisLookupV2RequestFormat value) => value.Value;

    public static explicit operator DomainWhoisLookupV2RequestFormat(string value) => new(value);

    internal class DomainWhoisLookupV2RequestFormatSerializer
        : JsonConverter<DomainWhoisLookupV2RequestFormat>
    {
        public override DomainWhoisLookupV2RequestFormat Read(
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
            return new DomainWhoisLookupV2RequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainWhoisLookupV2RequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainWhoisLookupV2RequestFormat ReadAsPropertyName(
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
            return new DomainWhoisLookupV2RequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainWhoisLookupV2RequestFormat value,
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
