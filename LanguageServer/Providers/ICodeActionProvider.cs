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
    /// The code action interface defines the contract between extensions and
    /// the [light bulb](https://code.visualstudio.com/docs/editor/editingevolved#_code-action) feature.
    /// </summary>
    interface ICodeActionProvider
    {
        /// <summary>
        /// Provide commands for the given document and range.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="range">The range for which the command was invoked.</param>
        /// <param name="context">Context carrying additional information.</param>
        /// <returns>
        /// An array of commands. The lack of a result can be
        /// signaled by returning `null` or an empty array.
        /// </returns>
        Command[] ProvideCodeActions(TextDocumentIdentifier document, Range range, CodeActionContext context);

        Task<Command[]> ProvideCodeActionsAsync(TextDocumentIdentifier document, Range range, CodeActionContext context, CancellationToken token);
    }
}
