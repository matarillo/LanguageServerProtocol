using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// The original spec describes the union type of
    /// <c>boolean</c>, <c>ColorProviderOptions</c>, or the intersection type
    /// <c>(ColorProviderOptions &amp; TextDocumentRegistrationOptions &amp; StaticRegistrationOptions)</c>.
    /// This implementation defines <see cref="ColorProviderOptions"/> class instead of the intersection type.
    /// </remarks>
    /// <seealso>Spec 3.8.0</seealso>
    public class ColorProviderOptionsOrBoolean : Either
    {
        /// <summary>
        /// Defines an implicit conversion of a <see cref="ColorProviderOptions"/> to a <see cref="ColorProviderOptionsOrBoolean"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.8.0</seealso>
        public static implicit operator ColorProviderOptionsOrBoolean(ColorProviderOptions value)
            => new ColorProviderOptionsOrBoolean(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="bool"/> to a <see cref="ColorProviderOptionsOrBoolean"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.8.0</seealso>
        public static implicit operator ColorProviderOptionsOrBoolean(bool value)
            => new ColorProviderOptionsOrBoolean(value);

        /// <summary>
        /// Initializes a new instance of <c>ColorProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.8.0</seealso>
        public ColorProviderOptionsOrBoolean(ColorProviderOptions value)
        {
            Type = typeof(ColorProviderOptions);
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of <c>ColorProviderOptionsOrBoolean</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.8.0</seealso>
        public ColorProviderOptionsOrBoolean(bool value)
        {
            Type = typeof(bool);
            Value = value;
        }

        /// <summary>
        /// Returns true if its underlying value is a <see cref="ColorProviderOptions"/>.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public bool IsColorProviderOptions => Type == typeof(ColorProviderOptions);

        /// <summary>
        /// Returns true if its underlying value is a <see cref="bool"/>.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public bool IsBoolean => Type == typeof(bool);

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="ColorProviderOptions"/>.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public ColorProviderOptions ColorProviderOptions => GetValue<ColorProviderOptions>();

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="bool"/>.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public bool Boolean => GetValue<bool>();
    }
}
