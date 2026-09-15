using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(AstronomyLookupV2RequestLang.AstronomyLookupV2RequestLangSerializer))]
[Serializable]
public readonly record struct AstronomyLookupV2RequestLang : IStringEnum
{
    public static readonly AstronomyLookupV2RequestLang En = new(Values.En);

    public static readonly AstronomyLookupV2RequestLang De = new(Values.De);

    public static readonly AstronomyLookupV2RequestLang Ru = new(Values.Ru);

    public static readonly AstronomyLookupV2RequestLang Ja = new(Values.Ja);

    public static readonly AstronomyLookupV2RequestLang Fr = new(Values.Fr);

    public static readonly AstronomyLookupV2RequestLang Cn = new(Values.Cn);

    public static readonly AstronomyLookupV2RequestLang Es = new(Values.Es);

    public static readonly AstronomyLookupV2RequestLang Cs = new(Values.Cs);

    public static readonly AstronomyLookupV2RequestLang It = new(Values.It);

    public static readonly AstronomyLookupV2RequestLang Ko = new(Values.Ko);

    public static readonly AstronomyLookupV2RequestLang Fa = new(Values.Fa);

    public static readonly AstronomyLookupV2RequestLang Pt = new(Values.Pt);

    public AstronomyLookupV2RequestLang(string value)
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
    public static AstronomyLookupV2RequestLang FromCustom(string value)
    {
        return new AstronomyLookupV2RequestLang(value);
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

    public static bool operator ==(AstronomyLookupV2RequestLang value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AstronomyLookupV2RequestLang value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AstronomyLookupV2RequestLang value) => value.Value;

    public static explicit operator AstronomyLookupV2RequestLang(string value) => new(value);

    internal class AstronomyLookupV2RequestLangSerializer
        : JsonConverter<AstronomyLookupV2RequestLang>
    {
        public override AstronomyLookupV2RequestLang Read(
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
            return new AstronomyLookupV2RequestLang(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AstronomyLookupV2RequestLang value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AstronomyLookupV2RequestLang ReadAsPropertyName(
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
            return new AstronomyLookupV2RequestLang(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AstronomyLookupV2RequestLang value,
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
        public const string En = "en";

        public const string De = "de";

        public const string Ru = "ru";

        public const string Ja = "ja";

        public const string Fr = "fr";

        public const string Cn = "cn";

        public const string Es = "es";

        public const string Cs = "cs";

        public const string It = "it";

        public const string Ko = "ko";

        public const string Fa = "fa";

        public const string Pt = "pt";
    }
}
