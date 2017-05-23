using LanguageServer.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace LanguageServer.Infrastructure.JsonDotNet
{
    internal class NumberOrStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(NumberOrString));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                return new NumberOrString((long)reader.Value);
            }
            else if (reader.TokenType == JsonToken.String)
            {
                return new NumberOrString((string)reader.Value);
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var numberOrString = value as NumberOrString;
            if (numberOrString == null)
            {
                return;
            }
            if (numberOrString.IsNumber)
            {
                new JValue(numberOrString.NumberValue).WriteTo(writer);
            }
            else if (numberOrString.IsString)
            {
                new JValue(numberOrString.StringValue).WriteTo(writer);
            }
        }
    }
}
