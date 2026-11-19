using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(CommoditySymbolsResponseSymbolsItemUpdateInterval.CommoditySymbolsResponseSymbolsItemUpdateIntervalSerializer)
)]
[Serializable]
public readonly record struct CommoditySymbolsResponseSymbolsItemUpdateInterval : IStringEnum
{
    public static readonly CommoditySymbolsResponseSymbolsItemUpdateInterval PerSecond = new(
        Values.PerSecond
    );

    public static readonly CommoditySymbolsResponseSymbolsItemUpdateInterval PerMinute = new(
        Values.PerMinute
    );

    public static readonly CommoditySymbolsResponseSymbolsItemUpdateInterval Per10Minutes = new(
        Values.Per10Minutes
    );

    public static readonly CommoditySymbolsResponseSymbolsItemUpdateInterval PerHour = new(
        Values.PerHour
    );

    public static readonly CommoditySymbolsResponseSymbolsItemUpdateInterval PerDay = new(
        Values.PerDay
    );

    public static readonly CommoditySymbolsResponseSymbolsItemUpdateInterval PerWeek = new(
        Values.PerWeek
    );

    public static readonly CommoditySymbolsResponseSymbolsItemUpdateInterval PerMonth = new(
        Values.PerMonth
    );

    public static readonly CommoditySymbolsResponseSymbolsItemUpdateInterval Per6Months = new(
        Values.Per6Months
    );

    public CommoditySymbolsResponseSymbolsItemUpdateInterval(string value)
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
    public static CommoditySymbolsResponseSymbolsItemUpdateInterval FromCustom(string value)
    {
        return new CommoditySymbolsResponseSymbolsItemUpdateInterval(value);
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
        CommoditySymbolsResponseSymbolsItemUpdateInterval value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CommoditySymbolsResponseSymbolsItemUpdateInterval value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CommoditySymbolsResponseSymbolsItemUpdateInterval value
    ) => value.Value;

    public static explicit operator CommoditySymbolsResponseSymbolsItemUpdateInterval(
        string value
    ) => new(value);

    internal class CommoditySymbolsResponseSymbolsItemUpdateIntervalSerializer
        : JsonConverter<CommoditySymbolsResponseSymbolsItemUpdateInterval>
    {
        public override CommoditySymbolsResponseSymbolsItemUpdateInterval Read(
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
            return new CommoditySymbolsResponseSymbolsItemUpdateInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommoditySymbolsResponseSymbolsItemUpdateInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommoditySymbolsResponseSymbolsItemUpdateInterval ReadAsPropertyName(
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
            return new CommoditySymbolsResponseSymbolsItemUpdateInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommoditySymbolsResponseSymbolsItemUpdateInterval value,
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

        public const string Per6Months = "PER_6_MONTHS";
    }
}
