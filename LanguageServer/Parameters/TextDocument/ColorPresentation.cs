namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/colorPresentation</c>
    /// </summary>
    /// <seealso>Spec 3.6.0</seealso>
    public class ColorPresentation
    {
        /// <summary>
        /// The label of this color presentation. It will be shown on the color picker header.
        /// </summary>
        /// <remarks>
        /// By default this is also the text that is inserted when selecting this color presentation.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public string label { get; set; }

        /// <summary>
        /// An <see cref="TextEdit">edit</see> which is applied to a document when selecting this presentation for the color.
        /// </summary>
        /// <remarks>
        /// When <c>falsy</c> the <see cref="label"/> is used.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public TextEdit textEdit { get; set; }

        /// <summary>
        /// An optional array of additional <see cref="TextEdit">text edits</see>
        /// that are applied when selecting this color presentation.
        /// </summary>
        /// <remarks>
        /// Edits must not overlap with the main <see cref="textEdit">edit</see> nor with themselves.
        /// </remarks>
        /// <seealso>Spec 3.6.0</seealso>
        public TextEdit[] additionalTextEdits { get; set; }
    }
}
