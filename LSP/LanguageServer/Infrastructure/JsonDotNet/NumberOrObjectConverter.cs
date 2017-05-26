using LanguageServer.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;

namespace LanguageServer.Infrastructure.JsonDotNet
{
    public class NumberOrObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(INumberOrObject).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                var numberOrObject = CreateInstance(objectType);
                numberOrObject.Number = (long)reader.Value;
                return numberOrObject;
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                var numberOrObject = CreateInstance(objectType);
                numberOrObject.Object = serializer.Deserialize(reader, numberOrObject.ObjectType);
                return numberOrObject;
            }
            return null;
        }

        public static INumberOrObject CreateInstance(Type objectType)
        {
            var ctor = objectType.GetTypeInfo().DeclaredConstructors.FirstOrDefault(c => c.GetParameters().Length == 0);
            return ctor.Invoke(new object[0]) as INumberOrObject;
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
                new JValue(numberOrObject.Number).WriteTo(writer);
            }
            else if (numberOrObject.IsObject)
            {
                JObject.FromObject(numberOrObject.Object, serializer).WriteTo(writer);
            }
        }
    }

    /*
    public class ValueOrObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType.IsConstructedGenericType && objectType.GetGenericTypeDefinition() == typeof(EnumOrObject<,>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
            var t1 = objectType.GenericTypeArguments[0];
            var t2 = objectType.GenericTypeArguments[1];

            if (reader.TokenType == JsonToken.Integer)
            {
                return Activator.CreateInstance(objectType, (long)reader.Value);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                var inner = serializer.Deserialize(reader, t2);
                return Activator.CreateInstance(objectType, inner);
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var valueOrObject = value as IValueOrObject;
            if (valueOrObject == null)
            {
                return;
            }
            if (valueOrObject.IsValue)
            {
                new JValue(valueOrObject.Value).WriteTo(writer);
            }
            else if (valueOrObject.IsObject)
            {
                JObject.FromObject(valueOrObject.Object, serializer).WriteTo(writer);
            }
        }
    }
    */
}
