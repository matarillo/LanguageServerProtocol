using LanguageServer.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LanguageServer.Providers
{
    /// <summary>
    /// The rename provider interface defines the contract between extensions and
    /// the [rename](https://code.visualstudio.com/docs/editor/editingevolved#_rename-symbol)-feature.
    /// </summary>
    interface IRenameProvider
    {
        /// <summary>
        /// Provide an edit that describes changes that have to be made to one
        /// or many resources to rename a symbol to a different name.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="newName">The new name of the symbol. If the given name is not valid, the provider must return a [ResponseError](#ResponseError) with an appropriate message set.</param>
        /// <returns>
        /// A workspace edit. The lack of a result can be signaled by returning `null`.
        /// </returns>
        Result<WorkspaceEdit, ResponseError> ProvideRenameEdits(TextDocumentIdentifier document, Position position, string newName);

        Task<Result<WorkspaceEdit, ResponseError>> ProvideRenameEditsAsync(TextDocumentIdentifier document, Position position, string newName, CancellationToken token);
    }
}
