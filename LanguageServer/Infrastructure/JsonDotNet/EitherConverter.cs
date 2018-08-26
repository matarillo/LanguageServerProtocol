using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using LanguageServer.Json;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Parameters.TextDocument;

namespace LanguageServer.Infrastructure.JsonDotNet
{
    public class EitherConverter : JsonConverter
    {
        private readonly Dictionary<Type, Func<JToken, object>> table;

        public EitherConverter()
        {
            table = new Dictionary<Type, Func<JToken, object>>();
            table[typeof(NumberOrString)] = token => (object)ToNumberOrString(token);
            table[typeof(LocationSingleOrArray)] = token => (object)ToLocationSingleOrArray(token);
            table[typeof(TextDocumentSync)] = token => (object)ToTextDocumentSync(token);
            table[typeof(CompletionResult)] = token => (object)ToCompletionResult(token);
            table[typeof(HoverContents)] = token => (object)ToHoverContents(token);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Either).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var convert = table[objectType] ??
                          throw new NotImplementedException($"Could not deserialize '{objectType.FullName}'.");
            var token = JToken.Load(reader);
            return convert(token);
        }

        #region Deserialization

        private NumberOrString ToNumberOrString(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null:
                    return null;
                case JTokenType.Integer:
                    return new NumberOrString(token.ToObject<long>());
                case JTokenType.String:
                    return new NumberOrString(token.ToObject<string>());
                default:
                    throw new JsonSerializationException();
            }
        }

        private LocationSingleOrArray ToLocationSingleOrArray(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null:
                    return null;
                case JTokenType.Object:
                    return new LocationSingleOrArray(token.ToObject<Location>());
                case JTokenType.Array:
                    return new LocationSingleOrArray(token.ToObject<Location[]>());
                default:
                    throw new JsonSerializationException();
            }
        }

        private TextDocumentSync ToTextDocumentSync(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null:
                    return null;
                case JTokenType.Integer:
                    return new TextDocumentSync(token.ToObject<TextDocumentSyncKind>());
                case JTokenType.Object:
                    return new TextDocumentSync(token.ToObject<TextDocumentSyncOptions>());
                default:
                    throw new JsonSerializationException();
            }
        }

        private CompletionResult ToCompletionResult(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null:
                    return null;
                case JTokenType.Array:
                    return new CompletionResult(token.ToObject<CompletionItem[]>());
                case JTokenType.Object:
                    return new CompletionResult(token.ToObject<CompletionList>());
                default:
                    throw new JsonSerializationException();
            }
        }

        private HoverContents ToHoverContents(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null:
                    return null;
                case JTokenType.String:
                    return new HoverContents(token.ToObject<string>());
                case JTokenType.Object:
                    return new HoverContents(token.ToObject<MarkedString>());
                case JTokenType.Array:
                    var array = (JArray) token;
                    if (array.Count == 0)
                    {
                        return new HoverContents(new string[0]);
                    }

                    var element = (array[0] as JObject) ?? throw new JsonSerializationException();
                    if (element.Type == JTokenType.String)
                    {
                        return new HoverContents(array.ToObject<string[]>());
                    }
                    else if (element.Type == JTokenType.Object)
                    {
                        return new HoverContents(array.ToObject<MarkedString[]>());
                    }
                    else
                    {
                        throw new JsonSerializationException();
                    }

                default:
                    throw new JsonSerializationException();
            }
        }
        
        #endregion

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var either = (Either)value;
            serializer.Serialize(writer, either?.Value);
        }
    }
}
