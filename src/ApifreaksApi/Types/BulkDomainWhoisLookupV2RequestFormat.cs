using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkDomainWhoisLookupV2RequestFormat.BulkDomainWhoisLookupV2RequestFormatSerializer)
)]
[Serializable]
public readonly record struct BulkDomainWhoisLookupV2RequestFormat : IStringEnum
{
    public static readonly BulkDomainWhoisLookupV2RequestFormat Json = new(Values.Json);

    public static readonly BulkDomainWhoisLookupV2RequestFormat Xml = new(Values.Xml);

    public BulkDomainWhoisLookupV2RequestFormat(string value)
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
    public static BulkDomainWhoisLookupV2RequestFormat FromCustom(string value)
    {
        return new BulkDomainWhoisLookupV2RequestFormat(value);
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

    public static bool operator ==(BulkDomainWhoisLookupV2RequestFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BulkDomainWhoisLookupV2RequestFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BulkDomainWhoisLookupV2RequestFormat value) =>
        value.Value;

    public static explicit operator BulkDomainWhoisLookupV2RequestFormat(string value) =>
        new(value);

    internal class BulkDomainWhoisLookupV2RequestFormatSerializer
        : JsonConverter<BulkDomainWhoisLookupV2RequestFormat>
    {
        public override BulkDomainWhoisLookupV2RequestFormat Read(
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
            return new BulkDomainWhoisLookupV2RequestFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkDomainWhoisLookupV2RequestFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkDomainWhoisLookupV2RequestFormat ReadAsPropertyName(
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
            return new BulkDomainWhoisLookupV2RequestFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkDomainWhoisLookupV2RequestFormat value,
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
