using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(DomainWhoisLookupV2ResponseDomainRegistered.DomainWhoisLookupV2ResponseDomainRegisteredSerializer)
)]
[Serializable]
public readonly record struct DomainWhoisLookupV2ResponseDomainRegistered : IStringEnum
{
    public static readonly DomainWhoisLookupV2ResponseDomainRegistered Yes = new(Values.Yes);

    public static readonly DomainWhoisLookupV2ResponseDomainRegistered No = new(Values.No);

    public static readonly DomainWhoisLookupV2ResponseDomainRegistered Restricted = new(
        Values.Restricted
    );

    public DomainWhoisLookupV2ResponseDomainRegistered(string value)
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
    public static DomainWhoisLookupV2ResponseDomainRegistered FromCustom(string value)
    {
        return new DomainWhoisLookupV2ResponseDomainRegistered(value);
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

    public static bool operator ==(
        DomainWhoisLookupV2ResponseDomainRegistered value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DomainWhoisLookupV2ResponseDomainRegistered value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DomainWhoisLookupV2ResponseDomainRegistered value) =>
        value.Value;

    public static explicit operator DomainWhoisLookupV2ResponseDomainRegistered(string value) =>
        new(value);

    internal class DomainWhoisLookupV2ResponseDomainRegisteredSerializer
        : JsonConverter<DomainWhoisLookupV2ResponseDomainRegistered>
    {
        public override DomainWhoisLookupV2ResponseDomainRegistered Read(
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
            return new DomainWhoisLookupV2ResponseDomainRegistered(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainWhoisLookupV2ResponseDomainRegistered value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainWhoisLookupV2ResponseDomainRegistered ReadAsPropertyName(
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
            return new DomainWhoisLookupV2ResponseDomainRegistered(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainWhoisLookupV2ResponseDomainRegistered value,
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
        public const string Yes = "yes";

        public const string No = "no";

        public const string Restricted = "restricted";
    }
}
