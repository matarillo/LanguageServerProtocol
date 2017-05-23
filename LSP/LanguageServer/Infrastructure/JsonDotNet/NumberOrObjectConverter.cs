using LanguageServer.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace LanguageServer.Infrastructure.JsonDotNet
{
    public class NumberOrObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType.IsConstructedGenericType && objectType.GetGenericTypeDefinition() == typeof(NumberOrObject<>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                return Activator.CreateInstance(objectType, (long)reader.Value);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                var inner = serializer.Deserialize(reader, objectType.GenericTypeArguments[0]);
                return Activator.CreateInstance(objectType, inner);
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var numberOrObject = value as INumberOrObject;
            if (numberOrObject == null)
            {
                return;
            }
            if (numberOrObject.IsNumber)
            {
                new JValue(numberOrObject.NumberValue).WriteTo(writer);
            }
            else if (numberOrObject.IsObject)
            {
                JObject.FromObject(numberOrObject.ObjectValue, serializer).WriteTo(writer);
            }
        }
    }
}
