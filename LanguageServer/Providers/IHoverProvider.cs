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
    /// The hover provider interface defines the contract between extensions and
    /// the [hover](https://code.visualstudio.com/docs/editor/intellisense)-feature.
    /// </summary>
    interface IHoverProvider
    {
        /// <summary>
        /// Provide a hover for the given position and document. Multiple hovers at the same
        /// position will be merged by the editor. A hover can have a range which defaults
        /// to the word range at the position when omitted.
        /// </summary>
        /// <param name="document">
        /// The document in which the command was invoked.
        /// </param>
        /// <param name="position">
        /// The position at which the command was invoked.
        /// </param>
        /// <returns>
        /// A hover. The lack of a result can be signaled by returning `null`.
        /// </returns>
        Hover ProvideHover(TextDocumentIdentifier document, Position position);

        Task<Hover> ProvideHoverAsync(TextDocumentIdentifier document, Position position, CancellationToken token);
    }
}
