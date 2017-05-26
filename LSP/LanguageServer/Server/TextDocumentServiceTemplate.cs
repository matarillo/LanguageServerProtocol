using LanguageServer.Client;
using LanguageServer.Parameters.TextDocument;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Server
{
    public class TextDocumentServiceTemplate : JsonRpcService
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
        public void DidOpenTextDocument(NotificationMessage<DidOpenTextDocumentParams> notification)
        {
            try
            {
                this.DidOpenTextDocument(notification.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        protected virtual void DidOpenTextDocument(DidOpenTextDocumentParams @params)
        {
        }

        // Registration Options: TextDocumentChangeRegistrationOptions
        [JsonRpcMethod("textDocument/didChange")]
        public void DidChangeTextDocument(NotificationMessage<DidChangeTextDocumentParams> notification)
        {
            try
            {
                this.DidChangeTextDocument(notification.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        protected virtual void DidChangeTextDocument(DidChangeTextDocumentParams @params)
        {
        }

        // textDocument/willSave
        // textDocument/willSaveWaitUntil
        // textDocument/didSave
        // textDocument/didClose
        // textDocument/completion
        // completionItem/resolve
        // textDocument/hover
        // textDocument/signatureHelp
        // textDocument/references
        // textDocument/documentHighlight
        // textDocument/documentSymbol
        // textDocument/formatting
        // textDocument/rangeFormatting
        // textDocument/onTypeFormatting
        // textDocument/definition
        // textDocument/codeAction
        // textDocument/codeLens
        // codeLens/resolve
        // textDocument/documentLink
        // documentLink/resolve
        // textDocument/rename
    }
}
