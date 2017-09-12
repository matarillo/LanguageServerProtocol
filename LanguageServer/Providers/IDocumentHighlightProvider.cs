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
    /// The document highlight provider interface defines the contract between extensions and
    /// the word-highlight-feature.
    /// </summary>
    interface IDocumentHighlightProvider
    {
        /// <summary>
        /// Provide a set of document highlights, like all occurrences of a variable or
        /// all exit-points of a function.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <returns>
        /// An array of document highlights. The lack of a result can be
        /// signaled by returning `null` or an empty array.
        /// </returns>
        DocumentHighlight[] ProvideDocumentHighlights(TextDocumentIdentifier document, Position position);

        Task<DocumentHighlight[]> ProvideDocumentHighlightsAsync(TextDocumentIdentifier document, Position position, CancellationToken token);
    }
}
