using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(CommodityIntradayRatesV2RequestInterval.CommodityIntradayRatesV2RequestIntervalSerializer)
)]
[Serializable]
public readonly record struct CommodityIntradayRatesV2RequestInterval : IStringEnum
{
    public static readonly CommodityIntradayRatesV2RequestInterval OneM = new(Values.OneM);

    public static readonly CommodityIntradayRatesV2RequestInterval FiveM = new(Values.FiveM);

    public static readonly CommodityIntradayRatesV2RequestInterval TenM = new(Values.TenM);

    public static readonly CommodityIntradayRatesV2RequestInterval FifteenM = new(Values.FifteenM);

    public static readonly CommodityIntradayRatesV2RequestInterval ThirtyM = new(Values.ThirtyM);

    public static readonly CommodityIntradayRatesV2RequestInterval FortyFiveM = new(
        Values.FortyFiveM
    );

    public static readonly CommodityIntradayRatesV2RequestInterval OneH = new(Values.OneH);

    public static readonly CommodityIntradayRatesV2RequestInterval TwoH = new(Values.TwoH);

    public static readonly CommodityIntradayRatesV2RequestInterval FourH = new(Values.FourH);

    public static readonly CommodityIntradayRatesV2RequestInterval EightH = new(Values.EightH);

    public static readonly CommodityIntradayRatesV2RequestInterval TwelveH = new(Values.TwelveH);

    public static readonly CommodityIntradayRatesV2RequestInterval OneD = new(Values.OneD);

    public CommodityIntradayRatesV2RequestInterval(string value)
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
    public static CommodityIntradayRatesV2RequestInterval FromCustom(string value)
    {
        return new CommodityIntradayRatesV2RequestInterval(value);
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

    public static bool operator ==(CommodityIntradayRatesV2RequestInterval value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CommodityIntradayRatesV2RequestInterval value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CommodityIntradayRatesV2RequestInterval value) =>
        value.Value;

    public static explicit operator CommodityIntradayRatesV2RequestInterval(string value) =>
        new(value);

    internal class CommodityIntradayRatesV2RequestIntervalSerializer
        : JsonConverter<CommodityIntradayRatesV2RequestInterval>
    {
        public override CommodityIntradayRatesV2RequestInterval Read(
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
            return new CommodityIntradayRatesV2RequestInterval(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CommodityIntradayRatesV2RequestInterval value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CommodityIntradayRatesV2RequestInterval ReadAsPropertyName(
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
            return new CommodityIntradayRatesV2RequestInterval(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CommodityIntradayRatesV2RequestInterval value,
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
