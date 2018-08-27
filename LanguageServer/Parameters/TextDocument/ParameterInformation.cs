namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/signatureHelp</c>
    /// </summary>
    /// <remarks>
    /// Represents a parameter of a callable-signature.
    /// A parameter can have a label and a doc-comment.
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class ParameterInformation
    {
        /// <summary>
        /// The label of this parameter.
        /// </summary>
        /// <remarks>
        /// Will be shown in the UI.
        /// </remarks>
        public string label { get; set; }

        /// <summary>
        /// The human-readable doc-comment of this parameter.
        /// </summary>
        /// <remarks>
        /// Will be shown in the UI but can be omitted.
        /// </remarks>
        /// <seealso>Spec 3.3.0</seealso>
        public Documentation documentation { get; set; }
    }
}
