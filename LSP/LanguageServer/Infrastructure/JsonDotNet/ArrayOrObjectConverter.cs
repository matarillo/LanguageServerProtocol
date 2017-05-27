using LanguageServer.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace LanguageServer.Infrastructure.JsonDotNet
{
    public class ArrayOrObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IArrayOrObject).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var arrayOrObject = CreateInstance(objectType);
                arrayOrObject.Array = (object[])serializer.Deserialize(reader, arrayOrObject.ArrayElementType.MakeArrayType());
                return arrayOrObject;
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                var arrayOrObject = CreateInstance(objectType);
                arrayOrObject.Object = serializer.Deserialize(reader, arrayOrObject.ObjectType);
                return arrayOrObject;
            }
            return null;
        }

        public static IArrayOrObject CreateInstance(Type objectType)
        {
            var ctor = objectType.GetTypeInfo().DeclaredConstructors.FirstOrDefault(c => c.GetParameters().Length == 0);
            return ctor.Invoke(new object[0]) as IArrayOrObject;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var arrayOrObject = value as IArrayOrObject;
            if (arrayOrObject == null)
            {
                return;
            }
            if (arrayOrObject.IsArray)
            {
                JArray.FromObject(arrayOrObject.Array, serializer).WriteTo(writer);
            }
            else if (arrayOrObject.IsObject)
            {
                JObject.FromObject(arrayOrObject.Object, serializer).WriteTo(writer);
            }
        }
    }
}
