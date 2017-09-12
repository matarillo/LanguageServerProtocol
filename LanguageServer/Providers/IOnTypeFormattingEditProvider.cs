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
    interface IOnTypeFormattingEditProvider
    {
        /// <summary>
        /// Provide formatting edits after a character has been typed.
        /// </summary>
        /// <remarks>
        /// The given position and character should hint to the provider
        /// what range the position to expand to, like find the matching `{`
        /// when `}` has been entered.
        /// </remarks>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="ch">The character that has been typed.</param>
        /// <param name="options">Options controlling formatting.</param>
        /// <returns>
        /// A set of text edits. The lack of a result can be
        /// signaled by returning `null` or an empty array.
        /// </returns>
        TextEdit[] ProvideOnTypeFormattingEdits(TextDocumentIdentifier document, Position position, string ch, FormattingOptions options);

        Task<TextEdit[]> ProvideOnTypeFormattingEditsAsync(TextDocumentIdentifier document, Position position, string ch, FormattingOptions options, CancellationToken token);
    }
}
