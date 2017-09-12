using LanguageServer.Parameters;
using LanguageServer.Parameters.TextDocument;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageServer.Providers
{
    /// <summary>
    /// The document formatting provider interface defines the contract between extensions and
    /// the formatting-feature.
    /// </summary>
    interface IDocumentFormattingEditProvider
    {
        /// <summary>
        /// Provide formatting edits for a whole document.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="options">Options controlling formatting.</param>
        /// <returns>
        /// A set of text edits. The lack of a result can be
        /// signaled by returning `null` or an empty array.
        /// </returns>
        TextEdit[] ProvideDocumentFormattingEdits(TextDocumentIdentifier document, FormattingOptions options);

        Task<TextEdit[]> ProvideDocumentFormattingEditsAsync(TextDocumentIdentifier document, FormattingOptions options, CancellationToken token);
    }
}
