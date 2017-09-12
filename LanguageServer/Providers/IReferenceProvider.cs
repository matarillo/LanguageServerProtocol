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
    /// The reference provider interface defines the contract between extensions and
    /// the[find references](https://code.visualstudio.com/docs/editor/editingevolved#_peek)-feature.
    /// </summary>
    interface IReferenceProvider
    {
        /// <summary>
        /// Provide a set of project-wide references for the given position and document.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <param name="context"></param>
        /// <returns>
        /// An array of locations. The lack of a result can be
        /// signaled by returning `null` or an empty array.
        /// </returns>
        Location[] ProvideReferences(TextDocumentIdentifier document, Position position, ReferenceContext context);

        Task<Location[]> ProvideReferencesAsync(TextDocumentIdentifier document, Position position, ReferenceContext context, CancellationToken token);
    }
}
