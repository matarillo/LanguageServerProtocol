using LanguageServer.Json;
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
    /// The completion item provider interface defines the contract between extensions and
    /// [IntelliSense](https://code.visualstudio.com/docs/editor/intellisense).
    /// </summary>
    /// <remarks>
    /// <para>
    /// When computing *complete* completion items is expensive, providers can optionally implement
    /// the `resolveCompletionItem`-function. In that case it is enough to return completion
    /// items with a[label](#CompletionItem.label) from the
    /// [provideCompletionItems](#CompletionItemProvider.provideCompletionItems)-function. Subsequently,
    /// when a completion item is shown in the UI and gains focus this provider is asked to resolve
    /// the item, like adding [doc-comment](#CompletionItem.documentation) or [details](#CompletionItem.detail).
    /// </para>
    /// <para>
    /// Providers are asked for completions either explicitly by a user gesture or -depending on the configuration-
    /// implicitly when typing words or trigger characters.
    /// </para>
    /// </remarks>
    interface ICompletionItemProvider
    {
        /// <summary>
        /// Completion options.
        /// The server provides support to resolve additional information for a completion item.
        /// </summary>
        bool ResolveProvider { get; }

        /// <summary>
        /// Completion options.
        /// The characters that trigger completion automatically.
        /// </summary>
        string[] TriggerCharacters { get; }

        /// <summary>
        /// Provide completion items for the given position and document.
        /// </summary>
        /// <param name="document">The document in which the command was invoked.</param>
        /// <param name="position">The position at which the command was invoked.</param>
        /// <returns>
        /// An array of completions or a [completion list](#CompletionList).
        /// The lack of a result can be signaled by returning `null` or an empty array.
        /// </returns>
        ArrayOrObject<CompletionItem, CompletionList> ProvideCompletionItems(TextDocumentIdentifier document, Position position);

        Task<ArrayOrObject<CompletionItem, CompletionList>> ProvideCompletionItemsAsync(TextDocumentIdentifier document, Position position, CancellationToken token);

        /// <summary>
        /// Given a completion item fill in more data, like [doc-comment](#CompletionItem.documentation)
        /// or [details] (#CompletionItem.detail).
        /// </summary>
        /// <remarks>
        /// The editor will only resolve a completion item once.
        /// </remarks>
        /// <param name="item">A completion item currently active in the UI.</param>
        /// <returns>
        /// The resolved completion item. It is OK to return the given
        /// `item`. When no result is returned, the given `item` will be used.
        /// </returns>
        CompletionItem ResolveCompletionItem(CompletionItem item);

        Task<CompletionItem> ResolveCompletionItemAsync(CompletionItem item, CancellationToken token);
    }
}
