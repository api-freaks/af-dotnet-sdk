using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType.DomainDnsLookupResponseDnsRecordsItemSingleNameDnsTypeSerializer)
)]
[Serializable]
public readonly record struct DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType : IStringEnum
{
    public static readonly DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType Ns = new(
        Values.Ns
    );

    public static readonly DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType Ptr = new(
        Values.Ptr
    );

    public DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType(string value)
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
    public static DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType FromCustom(string value)
    {
        return new DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType(value);
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
        DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType value
    ) => value.Value;

    public static explicit operator DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType(
        string value
    ) => new(value);

    internal class DomainDnsLookupResponseDnsRecordsItemSingleNameDnsTypeSerializer
        : JsonConverter<DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType>
    {
        public override DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType Read(
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
            return new DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType ReadAsPropertyName(
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
            return new DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainDnsLookupResponseDnsRecordsItemSingleNameDnsType value,
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
