using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? dateStr = reader.GetString();

        if (dateStr is not null)
        {
            if (dateStr.Contains(".") &&DateTimeOffset.TryParseExact(dateStr, "yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeOffset date))
            {
                return date.UtcDateTime;
            }
            else if (DateTimeOffset.TryParseExact(dateStr, "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeOffset date2))
            {
                return date2.UtcDateTime;
            }
        }

        throw new JsonException($"Unable to parse '{dateStr}' to DateTime.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz"));
    }
}