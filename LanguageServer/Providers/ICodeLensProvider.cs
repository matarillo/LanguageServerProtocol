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
    /// A code lens provider adds [commands](#Command) to source text. The commands will be shown
    /// as dedicated horizontal lines in between the source text.
    /// </summary>
    interface ICodeLensProvider
    {
        /// <summary>
        /// Code Lens options.
        /// Code lens has a resolve provider as well.
        /// </summary>
        bool ResolveProvider { get; }

        /// <summary>
        /// Compute a list of [lenses](#CodeLens). This call should return as fast as possible and if
        /// computing the commands is expensive implementors should only return code lens objects with the
        /// range set and implement[resolve](#CodeLensProvider.resolveCodeLens).
        /// </summary>
        /// <param name="document">
        /// The document in which the command was invoked.
        /// </param>
        /// <returns>
        /// An array of code lenses. The lack of a result can be
        /// signaled by returning `null` or an empty array.
        /// </returns>
        CodeLens[] ProvideCodeLenses(TextDocumentIdentifier document);

        Task<CodeLens[]> ProvideCodeLensesAsync(TextDocumentIdentifier document, CancellationToken token);

        /// <summary>
        /// This function will be called for each visible code lens, usually when scrolling and after
        /// calls to[compute](#CodeLensProvider.provideCodeLenses)-lenses.
        /// </summary>
        /// <param name="codeLens">code lens that must be resolved.</param>
        /// <returns>The given, resolved code lens.</returns>
        CodeLens ResolveCodeLens(CodeLens codeLens);

        Task<CodeLens> ResolveCodeLensAsync(CodeLens codeLens, CancellationToken token);
    }
}
