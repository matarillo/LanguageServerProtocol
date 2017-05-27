using LanguageServer.Client;
using LanguageServer.Json;
using LanguageServer.Parameters;
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

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/willSave")]
        public void WillSaveTextDocument(NotificationMessage<WillSaveTextDocumentParams> notification)
        {
            try
            {
                this.WillSaveTextDocument(notification.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        protected virtual void WillSaveTextDocument(WillSaveTextDocumentParams @params)
        {
        }

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/willSaveWaitUntil")]
        public ResponseMessage<TextEdit[], _Void> WillSaveWaitUntilTextDocument(RequestMessage<WillSaveTextDocumentParams> request)
        {
            Result<TextEdit[], Error<_Void>> r;
            try
            {
                r = WillSaveWaitUntilTextDocument(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<_Void>();
            }
            return new ResponseMessage<TextEdit[], _Void>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<TextEdit[], Error<_Void>> WillSaveWaitUntilTextDocument(WillSaveTextDocumentParams @params)
        {
            throw new NotImplementedException();
        }

        // Registration Options: TextDocumentSaveRegistrationOptions
        [JsonRpcMethod("textDocument/didSave")]
        public void DidSaveTextDocument(NotificationMessage<DidSaveTextDocumentParams> notification)
        {
            try
            {
                this.DidSaveTextDocument(notification.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        protected virtual void DidSaveTextDocument(DidSaveTextDocumentParams @params)
        {
        }

        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/didClose")]
        public void DidCloseTextDocument(NotificationMessage<DidCloseTextDocumentParams> notification)
        {
            try
            {
                this.DidCloseTextDocument(notification.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        protected virtual void DidCloseTextDocument(DidCloseTextDocumentParams @params)
        {
        }

        // dynamicRegistration?: boolean;
        // Registration Options: CompletionRegistrationOptions
        [JsonRpcMethod("textDocument/completion")]
        public ResponseMessage<ArrayOrObject<CompletionItem, CompletionList>, _Void> Completion(RequestMessage<TextDocumentPositionParams> request)
        {
            Result<ArrayOrObject<CompletionItem, CompletionList>, Error<_Void>> r;
            try
            {
                r = Completion(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<_Void>();
            }
            return new ResponseMessage<ArrayOrObject<CompletionItem, CompletionList>, _Void>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<ArrayOrObject<CompletionItem, CompletionList>, Error<_Void>> Completion(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("completionItem/resolve")]
        public ResponseMessage<CompletionItem, _Void> ResolveCompletionItem(RequestMessage<CompletionItem> request)
        {
            Result<CompletionItem, Error<_Void>> r;
            try
            {
                r = ResolveCompletionItem(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<_Void>();
            }
            return new ResponseMessage<CompletionItem, _Void>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<CompletionItem, Error<_Void>> ResolveCompletionItem(CompletionItem @params)
        {
            throw new NotImplementedException();
        }

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

        // dynamicRegistration?: boolean;
        // Registration Options: CodeLensRegistrationOptions
        [JsonRpcMethod("textDocument/codeLens")]
        public ResponseMessage<CodeLens[], _Void> CodeLens(RequestMessage<CodeLensParams> request)
        {
            Result<CodeLens[], Error<_Void>> r;
            try
            {
                r = CodeLens(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<_Void>();
            }
            return new ResponseMessage<CodeLens[], _Void>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<CodeLens[], Error<_Void>> CodeLens(CodeLensParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("codeLens/resolve")]
        public ResponseMessage<CodeLens, _Void> ResolveCodeLens(RequestMessage<CodeLens> request)
        {
            Result<CodeLens, Error<_Void>> r;
            try
            {
                r = ResolveCodeLens(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<_Void>();
            }
            return new ResponseMessage<CodeLens, _Void>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<CodeLens, Error<_Void>> ResolveCodeLens(CodeLens @params)
        {
            throw new NotImplementedException();
        }

        // dynam0icRegistration?: boolean;
        // Registration Options: DocumentLinkRegistrationOptions
        [JsonRpcMethod("textDocument/documentLink")]
        public ResponseMessage<DocumentLink[], _Void> DocumentLink(RequestMessage<DocumentLinkParams> request)
        {
            Result<DocumentLink[], Error<_Void>> r;
            try
            {
                r = DocumentLink(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<_Void>();
            }
            return new ResponseMessage<DocumentLink[], _Void>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<DocumentLink[], Error<_Void>> DocumentLink(DocumentLinkParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("documentLink/resolve")]
        public ResponseMessage<DocumentLink, _Void> ResolveDocumentLink(RequestMessage<DocumentLink> request)
        {
            Result<DocumentLink, Error<_Void>> r;
            try
            {
                r = ResolveDocumentLink(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<_Void>();
            }
            return new ResponseMessage<DocumentLink, _Void>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<DocumentLink, Error<_Void>> ResolveDocumentLink(DocumentLink @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/rename")]
        public ResponseMessage<WorkspaceEdit, _Void> Rename(RequestMessage<RenameParams> request)
        {
            Result<WorkspaceEdit, Error<_Void>> r;
            try
            {
                r = Rename(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<_Void>();
            }
            return new ResponseMessage<WorkspaceEdit, _Void>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<WorkspaceEdit, Error<_Void>> Rename(RenameParams @params)
        {
            throw new NotImplementedException();
        }
    }
}
