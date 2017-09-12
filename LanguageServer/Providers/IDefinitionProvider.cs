using LanguageServer.Json;
using LanguageServer.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageServer.Providers
{
    /// <summary>
    /// The definition provider interface defines the contract between extensions and
    /// the [go to definition](https://code.visualstudio.com/docs/editor/editingevolved#_go-to-definition)
    /// and peek definition features.
    /// </summary>
    interface IDefinitionProvider
    {
        /// <summary>
        /// Provide the definition of the symbol at the given position and document.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <returns>
        /// A definition. The lack of a result can be signaled by returning `null`.
        /// </returns>
        ArrayOrObject<Location> ProvideDefinition(TextDocumentIdentifier document, Position position);

        Task<ArrayOrObject<Location>> ProvideDefinitionAsync(TextDocumentIdentifier document, Position position, CancellationToken token);
    }
}
