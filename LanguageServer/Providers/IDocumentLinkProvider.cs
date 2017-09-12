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
    /// The document link provider defines the contract between extensions and feature of showing
    /// links in the editor.
    /// </summary>
    interface IDocumentLinkProvider
    {
        /// <summary>
        /// Document link options.
        /// Document links have a resolve provider as well.
        /// </summary>
        bool ResolveProvider { get; }

        /// <summary>
        /// Provide links for the given document. Note that the editor ships with a default provider that detects
        /// `http(s)` and `file` links.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <returns>
        /// An array of [document links](#DocumentLink). The lack of a result
        /// can be signaled by returning `null` or an empty array.
        /// </returns>
        DocumentLink[] ProvideDocumentLinks(TextDocumentIdentifier document);

        Task<DocumentLink[]> ProvideDocumentLinksAsync(TextDocumentIdentifier document, CancellationToken token);

        /// <summary>
        /// Given a link fill in its [target](#DocumentLink.target). This method is called when an incomplete
        /// link is selected in the UI. Providers can implement this method and return incomple links
        /// (without target) from the[`provideDocumentLinks`](#DocumentLinkProvider.provideDocumentLinks) method which
        /// often helps to improve performance.
        /// </summary>
        /// <param name="link">The link that is to be resolved.</param>
        /// <returns>
        /// The resolved link item. It is OK to return the given
        /// `item`. When no result is returned, the given `item` will be used.
        /// </returns>
        DocumentLink ResolveDocumentLink(DocumentLink link);

        Task<DocumentLink> ResolveDocumentLinkAsync(DocumentLink link, CancellationToken token);
    }
}
