using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(
    typeof(CurrencyLatestRatesRequestUpdates.CurrencyLatestRatesRequestUpdatesSerializer)
)]
[Serializable]
public readonly record struct CurrencyLatestRatesRequestUpdates : IStringEnum
{
    public static readonly CurrencyLatestRatesRequestUpdates OneM = new(Values.OneM);

    public static readonly CurrencyLatestRatesRequestUpdates TenM = new(Values.TenM);

    public static readonly CurrencyLatestRatesRequestUpdates OneH = new(Values.OneH);

    public static readonly CurrencyLatestRatesRequestUpdates OneD = new(Values.OneD);

    public CurrencyLatestRatesRequestUpdates(string value)
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
    public static CurrencyLatestRatesRequestUpdates FromCustom(string value)
    {
        return new CurrencyLatestRatesRequestUpdates(value);
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

    public static bool operator ==(CurrencyLatestRatesRequestUpdates value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CurrencyLatestRatesRequestUpdates value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CurrencyLatestRatesRequestUpdates value) => value.Value;

    public static explicit operator CurrencyLatestRatesRequestUpdates(string value) => new(value);

    internal class CurrencyLatestRatesRequestUpdatesSerializer
        : JsonConverter<CurrencyLatestRatesRequestUpdates>
    {
        public override CurrencyLatestRatesRequestUpdates Read(
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
            return new CurrencyLatestRatesRequestUpdates(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CurrencyLatestRatesRequestUpdates value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CurrencyLatestRatesRequestUpdates ReadAsPropertyName(
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
            return new CurrencyLatestRatesRequestUpdates(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CurrencyLatestRatesRequestUpdates value,
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

        public const string TenM = "10m";

        public const string OneH = "1h";

        public const string OneD = "1d";
    }
}
