using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/codeAction</c>
    /// </summary>
    /// <seealso>Spec 3.8.0</seealso>
    public class CodeActionResult : Either
    {
        /// <summary>
        /// Defines an implicit conversion of a <see cref="T:LanguageServer.Parameters.TextDocument.Command[]"/> to a <see cref="CodeActionResult"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.8.0</seealso>
        public static implicit operator CodeActionResult(Command[] value)
            => new CodeActionResult(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="T:LanguageServer.Parameters.TextDocument.CodeAction[]"/> to a <see cref="CodeActionResult"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.8.0</seealso>
        public static implicit operator CodeActionResult(CodeAction[] value)
            => new CodeActionResult(value);

        /// <summary>
        /// Initializes a new instance of <c>CodeActionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.8.0</seealso>
        public CodeActionResult(Command[] value)
        {
            Type = typeof(Command[]);
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of <c>CodeActionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <seealso>Spec 3.8.0</seealso>
        public CodeActionResult(CodeAction[] value)
        {
            Type = typeof(CodeAction[]);
            Value = value;
        }

        /// <summary>
        /// Returns true if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.Command[]"/>.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public bool IsCommandArray => Type == typeof(Command[]);

        /// <summary>
        /// Returns true if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.CodeAction[]"/>.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public bool IsCodeActionArray => Type == typeof(CodeAction[]);

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.Command[]"/>.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public Command[] CommandArray => GetValue<Command[]>();

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.CodeAction[]"/>.
        /// </summary>
        /// <seealso>Spec 3.8.0</seealso>
        public CodeAction[] CodeActionArray => GetValue<CodeAction[]>();
    }
}
