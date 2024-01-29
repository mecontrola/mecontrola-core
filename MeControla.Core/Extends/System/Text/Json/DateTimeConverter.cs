using System.Globalization;
using System.Text.Json.Serialization;

namespace System.Text.Json
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string dateFormat;

        public DateTimeConverter(string dateFormat)
            => this.dateFormat = dateFormat;

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateTime.ParseExact(value, dateFormat, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(dateFormat));
    }
}
