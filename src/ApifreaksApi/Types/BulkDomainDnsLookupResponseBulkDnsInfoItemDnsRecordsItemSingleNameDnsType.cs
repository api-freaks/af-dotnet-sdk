using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType.BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsTypeSerializer)
)]
[Serializable]
public readonly record struct BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType
    : IStringEnum
{
    public static readonly BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType Ns =
        new(Values.Ns);

    public static readonly BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType Ptr =
        new(Values.Ptr);

    public BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType(string value)
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
    public static BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType FromCustom(
        string value
    )
    {
        return new BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType(value);
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
        BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType value
    ) => value.Value;

    public static explicit operator BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType(
        string value
    ) => new(value);

    internal class BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsTypeSerializer
        : JsonConverter<BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType>
    {
        public override BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType Read(
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
            return new BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType ReadAsPropertyName(
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
            return new BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType value,
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
        public const string Ns = "NS";

        public const string Ptr = "PTR";
    }
}
