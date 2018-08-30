namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/signatureHelp</c>
    /// </summary>
    /// <remarks>
    /// Represents the signature of something callable.
    /// A signature can have a label, like a function-name, a doc-comment, and a set of parameters.
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class SignatureInformation
    {
        /// <summary>
        /// The label of this signature.
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

        /// <summary>
        /// The parameters of this signature.
        /// </summary>
        public ParameterInformation[] parameters { get; set; }
    }
}
