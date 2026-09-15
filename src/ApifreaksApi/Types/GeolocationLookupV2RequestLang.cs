using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[JsonConverter(typeof(GeolocationLookupV2RequestLang.GeolocationLookupV2RequestLangSerializer))]
[Serializable]
public readonly record struct GeolocationLookupV2RequestLang : IStringEnum
{
    public static readonly GeolocationLookupV2RequestLang En = new(Values.En);

    public static readonly GeolocationLookupV2RequestLang De = new(Values.De);

    public static readonly GeolocationLookupV2RequestLang Ru = new(Values.Ru);

    public static readonly GeolocationLookupV2RequestLang Ja = new(Values.Ja);

    public static readonly GeolocationLookupV2RequestLang Fr = new(Values.Fr);

    public static readonly GeolocationLookupV2RequestLang Cn = new(Values.Cn);

    public static readonly GeolocationLookupV2RequestLang Es = new(Values.Es);

    public static readonly GeolocationLookupV2RequestLang Cs = new(Values.Cs);

    public static readonly GeolocationLookupV2RequestLang It = new(Values.It);

    public static readonly GeolocationLookupV2RequestLang Ko = new(Values.Ko);

    public static readonly GeolocationLookupV2RequestLang Fa = new(Values.Fa);

    public static readonly GeolocationLookupV2RequestLang Pt = new(Values.Pt);

    public GeolocationLookupV2RequestLang(string value)
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
    public static GeolocationLookupV2RequestLang FromCustom(string value)
    {
        return new GeolocationLookupV2RequestLang(value);
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

    public static bool operator ==(GeolocationLookupV2RequestLang value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GeolocationLookupV2RequestLang value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GeolocationLookupV2RequestLang value) => value.Value;

    public static explicit operator GeolocationLookupV2RequestLang(string value) => new(value);

    internal class GeolocationLookupV2RequestLangSerializer
        : JsonConverter<GeolocationLookupV2RequestLang>
    {
        public override GeolocationLookupV2RequestLang Read(
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
            return new GeolocationLookupV2RequestLang(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GeolocationLookupV2RequestLang value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GeolocationLookupV2RequestLang ReadAsPropertyName(
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
            return new GeolocationLookupV2RequestLang(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GeolocationLookupV2RequestLang value,
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
