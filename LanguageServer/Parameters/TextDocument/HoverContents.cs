using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// The hover's content
    /// </summary>
    public class HoverContents : Either
    {
        public static implicit operator HoverContents(string value)
            => new HoverContents(value);

        public static implicit operator HoverContents(MarkedString value)
            => new HoverContents(value);

        public static implicit operator HoverContents(string[] value)
            => new HoverContents(value);

        public static implicit operator HoverContents(MarkedString[] value)
            => new HoverContents(value);

        public HoverContents(string value)
        {
            Type = typeof(string);
            Value = value;
        }

        public HoverContents(MarkedString value)
        {
            Type = typeof(MarkedString);
            Value = value;
        }

        public HoverContents(string[] value)
        {
            Type = typeof(string[]);
            Value = value;
        }

        public HoverContents(MarkedString[] value)
        {
            Type = typeof(MarkedString[]);
            Value = value;
        }

        public bool IsString => Type == typeof(string);

        public bool IsMarkedString => Type == typeof(MarkedString);

        public bool IsStringArray => Type == typeof(string[]);

        public bool IsMarkedStringArray => Type == typeof(MarkedString[]);

        public string String => GetValue<string>();

        public MarkedString MarkedString => GetValue<MarkedString>();

        public string[] StringArray => GetValue<string[]>();

        public MarkedString[] MarkedStringArray => GetValue<MarkedString[]>();
    }
}
