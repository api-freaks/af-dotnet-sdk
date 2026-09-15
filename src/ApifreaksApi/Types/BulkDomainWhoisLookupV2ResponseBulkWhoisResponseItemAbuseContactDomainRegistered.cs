using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered.BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegisteredSerializer)
)]
[Serializable]
public readonly record struct BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered
    : IStringEnum
{
    public static readonly BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered Yes =
        new(Values.Yes);

    public static readonly BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered No =
        new(Values.No);

    public static readonly BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered Restricted =
        new(Values.Restricted);

    public BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered(
        string value
    )
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
    public static BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered FromCustom(
        string value
    )
    {
        return new BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered(
            value
        );
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
        BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered value
    ) => value.Value;

    public static explicit operator BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered(
        string value
    ) => new(value);

    internal class BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegisteredSerializer
        : JsonConverter<BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered>
    {
        public override BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered Read(
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
            return new BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered ReadAsPropertyName(
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
            return new BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactDomainRegistered value,
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
