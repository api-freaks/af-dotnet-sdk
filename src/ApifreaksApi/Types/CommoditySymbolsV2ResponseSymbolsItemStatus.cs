using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(CommoditySymbolsV2ResponseSymbolsItemStatus.CommoditySymbolsV2ResponseSymbolsItemStatusSerializer)
)]
[Serializable]
public readonly record struct CommoditySymbolsV2ResponseSymbolsItemStatus : IStringEnum
{
    public static readonly CommoditySymbolsV2ResponseSymbolsItemStatus Active = new(Values.Active);

    public static readonly CommoditySymbolsV2ResponseSymbolsItemStatus Inactive = new(
        Values.Inactive
    );

    public CommoditySymbolsV2ResponseSymbolsItemStatus(string value)
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
    public static CommoditySymbolsV2ResponseSymbolsItemStatus FromCustom(string value)
    {
        return new CommoditySymbolsV2ResponseSymbolsItemStatus(value);
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
        CommoditySymbolsV2ResponseSymbolsItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CommoditySymbolsV2ResponseSymbolsItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CommoditySymbolsV2ResponseSymbolsItemStatus value) =>
        value.Value;

    public static explicit operator CommoditySymbolsV2ResponseSymbolsItemStatus(string value) =>
        new(value);

    internal class CommoditySymbolsV2ResponseSymbolsItemStatusSerializer
        : JsonConverter<CommoditySymbolsV2ResponseSymbolsItemStatus>
    {
        public override CommoditySymbolsV2ResponseSymbolsItemStatus Read(
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
            return new CommoditySymbolsV2ResponseSymbolsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommoditySymbolsV2ResponseSymbolsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommoditySymbolsV2ResponseSymbolsItemStatus ReadAsPropertyName(
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
            return new CommoditySymbolsV2ResponseSymbolsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommoditySymbolsV2ResponseSymbolsItemStatus value,
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
        public const string Active = "active";

        public const string Inactive = "inactive";
    }
}
