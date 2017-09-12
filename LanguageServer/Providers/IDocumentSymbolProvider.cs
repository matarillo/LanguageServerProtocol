using LanguageServer.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageServer.Providers
{
    /// <summary>
    /// The document symbol provider interface defines the contract between extensions and
    /// the [go to symbol](https://code.visualstudio.com/docs/editor/editingevolved#_go-to-symbol)-feature.
    /// </summary>
    interface IDocumentSymbolProvider
    {
        /// <summary>
        /// Provide symbol information for the given document.
        /// </summary>
        /// <param name="document">
        /// The document in which the command was invoked.
        /// </param>
        /// <returns>
        /// An array of document highlights. The lack of a result can be
        /// signaled by returning `null` or an empty array.
        /// </returns>
        SymbolInformation[] ProvideDocumentSymbols(TextDocumentIdentifier document);

        Task<SymbolInformation[]> ProvideDocumentSymbolsAsync(TextDocumentIdentifier document, CancellationToken token);
    }
}
