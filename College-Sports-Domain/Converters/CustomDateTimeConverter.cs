using System.Text.Json;
using System.Text.Json.Serialization;

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? dateStr = reader.GetString();
        
        if (dateStr is not null && DateTime.TryParseExact(dateStr, "yyyy-MM-ddTHH:mm:ss.fffzzz", null, System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            return date;
        }

        throw new JsonException($"Unable to parse '{dateStr}' to DateTime.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz"));
    }
}