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
    interface IDocumentRangeFormattingEditProvider
    {
        /// <summary>
        /// Provide formatting edits for a range in a document.
        /// </summary>
        /// <remarks>
        /// The given range is a hint and providers can decide to format a smaller
        /// or larger range. Often this is done by adjusting the start and end
        /// of the range to full syntax nodes.
        /// </remarks>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="range">The range which should be formatted.</param>
        /// <param name="options">Options controlling formatting.</param>
        /// <returns>
        /// A set of text edits. The lack of a result can be
        /// signaled by returning `null` or an empty array.
        /// </returns>
        TextEdit[] ProvideDocumentRangeFormattingEdits(TextDocumentIdentifier document, Range range, FormattingOptions options);

        Task<TextEdit[]> ProvideDocumentRangeFormattingEditsAsync(TextDocumentIdentifier document, Range range, FormattingOptions options, CancellationToken token);
    }
}
