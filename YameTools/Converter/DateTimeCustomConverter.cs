using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YameTools.Converter
{
    public class DateTimeCustomConverter : JsonConverter<DateTime>
    {
        private readonly string _serializationFormat;
        public DateTimeCustomConverter() : this(null) { }

        public DateTimeCustomConverter(string serializationFormat)
        {
            this._serializationFormat = serializationFormat ?? "yyyy/MM/dd HH:mm:ss";
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //reader會剛好到string 所以reader.GetString 就會是時間字串
            //while (reader.Read()) 就會繼續往下讀json
            return DateTime.Parse(reader.GetString() ?? String.Empty);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_serializationFormat));
        }
    }
}
