using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// The original spec describes the union type of <c>boolean</c> or the intersection type
    /// <c>(TextDocumentRegistrationOptions &amp; StaticRegistrationOptions)</c>.
    /// This implementation defines <see cref="ProviderOptions"/> class instead of the intersection type.
    /// </remarks>
    /// <seealso>Spec 3.6.0</seealso>
    public class ProviderOptionsOrBoolean : Either
    {
        /// <summary>
        /// Defines an implicit conversion of a <see cref="ProviderOptions"/> to a <see cref="ProviderOptionsOrBoolean"/>
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.6.0</seealso>
        public static implicit operator ProviderOptionsOrBoolean(ProviderOptions value)
            => new ProviderOptionsOrBoolean(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="bool"/> to a <see cref="ProviderOptionsOrBoolean"/>
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.6.0</seealso>
        public static implicit operator ProviderOptionsOrBoolean(bool value)
            => new ProviderOptionsOrBoolean(value);

        /// <summary>
        /// Initializes a new instance of <c>ProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.6.0</seealso>
        public ProviderOptionsOrBoolean(ProviderOptions value)
        {
            Type = typeof(ProviderOptions);
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of <c>ProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.6.0</seealso>
        public ProviderOptionsOrBoolean(bool value)
        {
            Type = typeof(bool);
            Value = value;
        }

        /// <summary>
        /// Returns true if its underlying value is a <see cref="ProviderOptions"/>.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public bool IsProviderOptions => Type == typeof(ProviderOptions);

        /// <summary>
        /// Returns true if its underlying value is a <see cref="bool"/>.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public bool IsBoolean => Type == typeof(bool);

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="ProviderOptions"/>.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public ProviderOptions ProviderOptions => GetValue<ProviderOptions>();

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="bool"/>.
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public bool Boolean => GetValue<bool>();
    }
}
