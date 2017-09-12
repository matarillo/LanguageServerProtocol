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
    /// The signature help provider interface defines the contract between extensions and
    /// the [parameter hints](https://code.visualstudio.com/docs/editor/intellisense)-feature.
    /// </summary>
    interface ISignatureHelpProvider
    {
        /// <summary>
        /// Provide help for the signature at the given position and document.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <returns>
        /// Signature help. The lack of a result can be signaled by returning `null`.
        /// </returns>
        SignatureHelp ProvideSignatureHelp(TextDocumentIdentifier document, Position position);

        Task<SignatureHelp> ProvideSignatureHelpAsync(TextDocumentIdentifier document, Position position, CancellationToken token);
    }
}
