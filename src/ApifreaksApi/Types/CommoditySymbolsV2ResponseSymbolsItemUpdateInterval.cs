using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(CommoditySymbolsV2ResponseSymbolsItemUpdateInterval.CommoditySymbolsV2ResponseSymbolsItemUpdateIntervalSerializer)
)]
[Serializable]
public readonly record struct CommoditySymbolsV2ResponseSymbolsItemUpdateInterval : IStringEnum
{
    public static readonly CommoditySymbolsV2ResponseSymbolsItemUpdateInterval PerSecond = new(
        Values.PerSecond
    );

    public static readonly CommoditySymbolsV2ResponseSymbolsItemUpdateInterval PerMinute = new(
        Values.PerMinute
    );

    public static readonly CommoditySymbolsV2ResponseSymbolsItemUpdateInterval Per10Minutes = new(
        Values.Per10Minutes
    );

    public static readonly CommoditySymbolsV2ResponseSymbolsItemUpdateInterval PerHour = new(
        Values.PerHour
    );

    public static readonly CommoditySymbolsV2ResponseSymbolsItemUpdateInterval PerDay = new(
        Values.PerDay
    );

    public static readonly CommoditySymbolsV2ResponseSymbolsItemUpdateInterval PerWeek = new(
        Values.PerWeek
    );

    public static readonly CommoditySymbolsV2ResponseSymbolsItemUpdateInterval PerMonth = new(
        Values.PerMonth
    );

    public CommoditySymbolsV2ResponseSymbolsItemUpdateInterval(string value)
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
    public static CommoditySymbolsV2ResponseSymbolsItemUpdateInterval FromCustom(string value)
    {
        return new CommoditySymbolsV2ResponseSymbolsItemUpdateInterval(value);
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
        CommoditySymbolsV2ResponseSymbolsItemUpdateInterval value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CommoditySymbolsV2ResponseSymbolsItemUpdateInterval value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CommoditySymbolsV2ResponseSymbolsItemUpdateInterval value
    ) => value.Value;

    public static explicit operator CommoditySymbolsV2ResponseSymbolsItemUpdateInterval(
        string value
    ) => new(value);

    internal class CommoditySymbolsV2ResponseSymbolsItemUpdateIntervalSerializer
        : JsonConverter<CommoditySymbolsV2ResponseSymbolsItemUpdateInterval>
    {
        public override CommoditySymbolsV2ResponseSymbolsItemUpdateInterval Read(
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
            return new CommoditySymbolsV2ResponseSymbolsItemUpdateInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommoditySymbolsV2ResponseSymbolsItemUpdateInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommoditySymbolsV2ResponseSymbolsItemUpdateInterval ReadAsPropertyName(
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
            return new CommoditySymbolsV2ResponseSymbolsItemUpdateInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommoditySymbolsV2ResponseSymbolsItemUpdateInterval value,
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
        public const string PerSecond = "PER_SECOND";

        public const string PerMinute = "PER_MINUTE";

        public const string Per10Minutes = "PER_10_MINUTES";

        public const string PerHour = "PER_HOUR";

        public const string PerDay = "PER_DAY";

        public const string PerWeek = "PER_WEEK";

        public const string PerMonth = "PER_MONTH";
    }
}
