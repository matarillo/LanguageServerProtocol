using System;

namespace LanguageServer.Json
{
    /// <summary>
    /// Mimic discriminated union types
    /// </summary>
    /// <remarks>
    /// <see cref="Serializer"/> must support these derived types below:
    /// <list type="bullet">
    /// <item><description><see cref="NumberOrString"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.LocationSingleOrArray"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.General.ChangeNotifications"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.General.ColorProviderCapabilities"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.General.FoldingRangeProviderCapabilities"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.General.ProviderCapabilities"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.General.TextDocumentSync"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.TextDocument.CodeActionResult"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.TextDocument.Documentation"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.TextDocument.CompletionResult"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.TextDocument.DocumentSymbolResult"/></description></item>
    /// <item><description><see cref="LanguageServer.Parameters.TextDocument.HoverContents"/></description></item>
    /// </list>
    /// </remarks>
    public abstract class Either
    {
        public object Value { get; protected set; }

        public Type Type { get; protected set; }

        public T GetValue<T>() => (this.Type == typeof(T)) ? (T)Value : throw new InvalidOperationException();
    }
}
