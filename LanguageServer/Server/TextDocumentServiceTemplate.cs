using LanguageServer.Client;
using LanguageServer.Json;
using LanguageServer.Parameters;
using LanguageServer.Parameters.TextDocument;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Server
{
    // TODO: refactor
    public class TextDocumentServiceTemplate : Service
    {
        private Proxy _proxy;

        public override Connection Connection
        {
            get => base.Connection;
            set
            {
                base.Connection = value;
                _proxy = new Proxy(value);
            }
        }

        public Proxy Proxy { get => _proxy; }

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/didOpen")]
        protected virtual void DidOpenTextDocument(DidOpenTextDocumentParams @params)
        {
        }

        // Registration Options: TextDocumentChangeRegistrationOptions
        [JsonRpcMethod("textDocument/didChange")]
        protected virtual void DidChangeTextDocument(DidChangeTextDocumentParams @params)
        {
        }

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/willSave")]
        protected virtual void WillSaveTextDocument(WillSaveTextDocumentParams @params)
        {
        }

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/willSaveWaitUntil")]
        protected virtual Result<TextEdit[], ResponseError> WillSaveWaitUntilTextDocument(WillSaveTextDocumentParams @params)
        {
            throw new NotImplementedException();
        }

        // Registration Options: TextDocumentSaveRegistrationOptions
        [JsonRpcMethod("textDocument/didSave")]
        protected virtual void DidSaveTextDocument(DidSaveTextDocumentParams @params)
        {
        }

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/didClose")]
        protected virtual void DidCloseTextDocument(DidCloseTextDocumentParams @params)
        {
        }

        /// <summary>
        /// The Completion request is sent from the client to the server to compute completion items at a given cursor position. 
        /// </summary>
        /// <remarks>
        /// <para>
        /// Completion items are presented in the <a href="https://code.visualstudio.com/docs/editor/editingevolved#_intellisense">IntelliSense</a> user interface.
        /// If computing full completion items is expensive, servers can additionally provide a handler for the completion item resolve request (<c>completionItem/resolve</c>).
        /// </para>
        /// <para>
        /// This request is sent when a completion item is selected in the user interface.
        /// </para>
        /// <para>
        /// A typical use case is for example: the <c>textDocument/completion</c> request doesn’t fill
        /// in the documentation property for returned completion items since it is expensive to compute.
        /// When the item is selected in the user interface then a <c>completionItem/resolve</c> request
        /// is sent with the selected completion item as a param.
        /// </para>
        /// <para>
        /// Registration Options: <c>CompletionRegistrationOptions</c>
        /// </para>
        /// </remarks>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.3.0</seealso>
        [JsonRpcMethod("textDocument/completion")]
        protected virtual Result<CompletionResult, ResponseError> Completion(CompletionParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("completionItem/resolve")]
        protected virtual Result<CompletionItem, ResponseError> ResolveCompletionItem(CompletionItem @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/hover")]
        protected virtual Result<Hover, ResponseError> Hover(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: SignatureHelpRegistrationOptions
        [JsonRpcMethod("textDocument/signatureHelp")]
        protected virtual Result<SignatureHelp, ResponseError> SignatureHelp(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/references")]
        protected virtual Result<Location[], ResponseError> FindReferences(ReferenceParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/documentHighlight")]
        protected virtual Result<DocumentHighlight[], ResponseError> DocumentHighlight(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/documentSymbol")]
        protected virtual Result<SymbolInformation[], ResponseError> DocumentSymbols(DocumentSymbolParams @params)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The document color request is sent from the client to the server
        /// to list all color references found in a given text document.
        /// Along with the range, a color value in RGB is returned.
        /// </summary>
        /// <remarks>
        /// Clients can use the result to decorate color references in an editor. For example:
        /// <list type="bullet">
        /// <item><description>Color boxes showing the actual color next to the reference</description></item>
        /// <item><description>Show a color picker when a color reference is edited</description></item>
        /// </list>
        /// </remarks>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/documentColor")]
        protected virtual Result<ColorInformation[], ResponseError> DocumentColor(DocumentColorParams @params)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The color presentation request is sent from the client to the server
        /// to obtain a list of presentations for a color value at a given location.
        /// </summary>
        /// <remarks>
        /// Clients can use the result to
        /// <list type="bullet">
        /// <item><description>modify a color reference.</description></item>
        /// <item><description>show in a color picker and let users pick one of the presentations</description></item>
        /// </list>
        /// </remarks>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/colorPresentation")]
        protected virtual Result<ColorPresentation[], ResponseError> ColorPresentation(ColorPresentationParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/formatting")]
        protected virtual Result<TextEdit[], ResponseError> DocumentFormatting(DocumentFormattingParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/rangeFormatting")]
        protected virtual Result<TextEdit[], ResponseError> DocumentRangeFormatting(DocumentRangeFormattingParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: DocumentOnTypeFormattingRegistrationOptions
        [JsonRpcMethod("textDocument/onTypeFormatting")]
        protected virtual Result<TextEdit[], ResponseError> DocumentOnTypeFormatting(DocumentOnTypeFormattingParams @params)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The goto definition request is sent from the client to the server
        /// to resolve the definition location of a symbol at a given text document position.
        /// </summary>
        /// <remarks>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </remarks>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        [JsonRpcMethod("textDocument/definition")]
        protected virtual Result<LocationSingleOrArray, ResponseError> GotoDefinition(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The goto type definition request is sent from the client to the server
        /// to resolve the type definition location of a symbol at a given text document position.
        /// </summary>
        /// <remarks>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </remarks>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/typeDefinition")]
        protected virtual Result<LocationSingleOrArray, ResponseError> GotoTypeDefinition(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The goto implementation request is sent from the client to the server
        /// to resolve the implementation location of a symbol at a given text document position.
        /// </summary>
        /// <remarks>
        /// Registration Options: <c>TextDocumentRegistrationOptions</c>
        /// </remarks>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <seealso cref="LanguageServer.Parameters.General.TextDocumentClientCapabilities"/>
        /// <seealso>Spec 3.6.0</seealso>
        [JsonRpcMethod("textDocument/implementation")]
        protected virtual Result<LocationSingleOrArray, ResponseError> GotoImplementation(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/codeAction")]
        protected virtual Result<Command[], ResponseError> CodeAction(CodeActionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: CodeLensRegistrationOptions
        [JsonRpcMethod("textDocument/codeLens")]
        protected virtual Result<CodeLens[], ResponseError> CodeLens(CodeLensParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("codeLens/resolve")]
        protected virtual Result<CodeLens, ResponseError> ResolveCodeLens(CodeLens @params)
        {
            throw new NotImplementedException();
        }

        // dynam0icRegistration?: boolean;
        // Registration Options: DocumentLinkRegistrationOptions
        [JsonRpcMethod("textDocument/documentLink")]
        protected virtual Result<DocumentLink[], ResponseError> DocumentLink(DocumentLinkParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("documentLink/resolve")]
        protected virtual Result<DocumentLink, ResponseError> ResolveDocumentLink(DocumentLink @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/rename")]
        protected virtual Result<WorkspaceEdit, ResponseError> Rename(RenameParams @params)
        {
            throw new NotImplementedException();
        }
    }
}
