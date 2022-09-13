using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace EncodeSA.Models.Entities;

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private JsonConverter<DateOnly> _jsonConverterImplementation;
    private const string Format = "yyyy-MM-dd";

    public DateOnly ReadJson(JsonReader reader,
        Type objectType,
        DateOnly existingValue,
        bool hasExistingValue,
        JsonSerializer serializer) =>
        DateOnly.ParseExact((string)reader.Value, Format, CultureInfo.InvariantCulture);

    public  void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer) => 
        writer.WriteValue(value.ToString(Format, CultureInfo.InvariantCulture));


    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return _jsonConverterImplementation.Read(ref reader, typeToConvert, options);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        _jsonConverterImplementation.Write(writer, value, options);
    }
}