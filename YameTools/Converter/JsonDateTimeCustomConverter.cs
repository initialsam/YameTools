using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace YameTools.Converter
{
    [AttributeUsage(AttributeTargets.Property)]
    public class JsonDateTimeCustomConverter : JsonConverterAttribute
    {
        private readonly string _serializationFormat;

        public JsonDateTimeCustomConverter() : this(null) { }

        public JsonDateTimeCustomConverter(string serializationFormat)
        {
            _serializationFormat = serializationFormat ?? "yyyy/MM/dd HH:mm:ss";
        }

        public override JsonConverter CreateConverter(Type typeToConvert)
        {
            if (typeToConvert != typeof(DateTime) && typeToConvert != typeof(DateTime?))
                throw new Exception("Can only use this attribute on DateTime properties");

            return new DateTimeCustomConverter(_serializationFormat);
        }
    }
}
