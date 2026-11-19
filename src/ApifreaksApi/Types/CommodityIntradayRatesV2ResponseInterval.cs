using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(CommodityIntradayRatesV2ResponseInterval.CommodityIntradayRatesV2ResponseIntervalSerializer)
)]
[Serializable]
public readonly record struct CommodityIntradayRatesV2ResponseInterval : IStringEnum
{
    public static readonly CommodityIntradayRatesV2ResponseInterval OneM = new(Values.OneM);

    public static readonly CommodityIntradayRatesV2ResponseInterval FiveM = new(Values.FiveM);

    public static readonly CommodityIntradayRatesV2ResponseInterval TenM = new(Values.TenM);

    public static readonly CommodityIntradayRatesV2ResponseInterval FifteenM = new(Values.FifteenM);

    public static readonly CommodityIntradayRatesV2ResponseInterval ThirtyM = new(Values.ThirtyM);

    public static readonly CommodityIntradayRatesV2ResponseInterval FortyFiveM = new(
        Values.FortyFiveM
    );

    public static readonly CommodityIntradayRatesV2ResponseInterval OneH = new(Values.OneH);

    public static readonly CommodityIntradayRatesV2ResponseInterval TwoH = new(Values.TwoH);

    public static readonly CommodityIntradayRatesV2ResponseInterval FourH = new(Values.FourH);

    public static readonly CommodityIntradayRatesV2ResponseInterval EightH = new(Values.EightH);

    public static readonly CommodityIntradayRatesV2ResponseInterval TwelveH = new(Values.TwelveH);

    public static readonly CommodityIntradayRatesV2ResponseInterval OneD = new(Values.OneD);

    public CommodityIntradayRatesV2ResponseInterval(string value)
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
    public static CommodityIntradayRatesV2ResponseInterval FromCustom(string value)
    {
        return new CommodityIntradayRatesV2ResponseInterval(value);
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
        CommodityIntradayRatesV2ResponseInterval value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CommodityIntradayRatesV2ResponseInterval value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CommodityIntradayRatesV2ResponseInterval value) =>
        value.Value;

    public static explicit operator CommodityIntradayRatesV2ResponseInterval(string value) =>
        new(value);

    internal class CommodityIntradayRatesV2ResponseIntervalSerializer
        : JsonConverter<CommodityIntradayRatesV2ResponseInterval>
    {
        public override CommodityIntradayRatesV2ResponseInterval Read(
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
            return new CommodityIntradayRatesV2ResponseInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommodityIntradayRatesV2ResponseInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommodityIntradayRatesV2ResponseInterval ReadAsPropertyName(
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
            return new CommodityIntradayRatesV2ResponseInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommodityIntradayRatesV2ResponseInterval value,
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
        public const string OneM = "1m";

        public const string FiveM = "5m";

        public const string TenM = "10m";

        public const string FifteenM = "15m";

        public const string ThirtyM = "30m";

        public const string FortyFiveM = "45m";

        public const string OneH = "1h";

        public const string TwoH = "2h";

        public const string FourH = "4h";

        public const string EightH = "8h";

        public const string TwelveH = "12h";

        public const string OneD = "1d";
    }
}
