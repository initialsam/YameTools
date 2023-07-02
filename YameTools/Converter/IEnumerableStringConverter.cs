using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YameTools.Converter
{
    public class IEnumerableStringConverter : JsonConverter<IEnumerable<string>>
    {
        public override IEnumerable<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException($"JsonTokenType was of type {reader.TokenType}, only objects are supported");
            }
            var list = new List<string>();
            var ngWordList = new List<string> { "\\", "-", "N/A" };
            while (reader.Read())//reader就会移动到JSON数据里面的下一个Token那里
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return list;
                }
                string item = SwitchToken(reader);
                if (ngWordList.Contains(item))
                {
                    continue;
                }
                list.Add(item);
            }
            return list;
        }
        string SwitchToken(Utf8JsonReader reader) =>
            reader.TokenType switch
            {
                JsonTokenType.StartObject => "{",
                JsonTokenType.EndObject => "}",
                JsonTokenType.StartArray => "[",
                JsonTokenType.EndArray => "]",
                JsonTokenType.False => $"{reader.GetBoolean()},",
                JsonTokenType.PropertyName => $@"""{reader.GetString()!}""",

                JsonTokenType.True => $"{reader.GetBoolean()},",
                JsonTokenType.Number => $"{reader.GetInt32()},",

                JsonTokenType.String => reader.GetString()!,
                JsonTokenType.Null => "Null",
                _ => "None",
            };
        // Serialization
        public override void Write(Utf8JsonWriter writer, IEnumerable<string> value, JsonSerializerOptions options)
        {
            //writer.WriteStringValue(value.ToString());
            JsonSerializer.Serialize(writer, value, options);
        }

        //private object ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        //{
        //    switch (reader.TokenType)
        //    {
        //        case JsonTokenType.String:
        //            if (reader.TryGetDateTime(out var date))
        //            {
        //                return date;
        //            }
        //            return reader.GetString();
        //        case JsonTokenType.False:
        //            return false;
        //        case JsonTokenType.True:
        //            return true;
        //        case JsonTokenType.Null:
        //            return null;
        //        case JsonTokenType.Number:
        //            if (reader.TryGetInt64(out var result))
        //            {
        //                return result;
        //            }
        //            return reader.GetDecimal();
        //        case JsonTokenType.StartObject:
        //            return Read(ref reader, null!, options);
        //        case JsonTokenType.StartArray:
        //            var list = new List<object?>();
        //            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        //            {
        //                list.Add(ExtractValue(ref reader, options));
        //            }
        //            return list;
        //        default:
        //            throw new JsonException($"'{reader.TokenType}' is not supported");
        //    }
        //}
    }
}
