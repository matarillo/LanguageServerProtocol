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
        public ResponseMessage<TextEdit[]> WillSaveWaitUntilTextDocument(RequestMessage<WillSaveTextDocumentParams> request)
        {
            Result<TextEdit[], ResponseError> r;
            try
            {
                r = WillSaveWaitUntilTextDocument(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<TextEdit[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<TextEdit[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<TextEdit[], ResponseError> WillSaveWaitUntilTextDocument(WillSaveTextDocumentParams @params)
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
        public ResponseMessage<ArrayOrObject<CompletionItem, CompletionList>> Completion(RequestMessage<TextDocumentPositionParams> request)
        {
            Result<ArrayOrObject<CompletionItem, CompletionList>, ResponseError> r;
            try
            {
                r = Completion(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<ArrayOrObject<CompletionItem, CompletionList>, ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<ArrayOrObject<CompletionItem, CompletionList>>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<ArrayOrObject<CompletionItem, CompletionList>, ResponseError> Completion(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("completionItem/resolve")]
        public ResponseMessage<CompletionItem> ResolveCompletionItem(RequestMessage<CompletionItem> request)
        {
            Result<CompletionItem, ResponseError> r;
            try
            {
                r = ResolveCompletionItem(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<CompletionItem, ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<CompletionItem>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<CompletionItem, ResponseError> ResolveCompletionItem(CompletionItem @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/hover")]
        public ResponseMessage<Hover> Hover(RequestMessage<TextDocumentPositionParams> request)
        {
            Result<Hover, ResponseError> r;
            try
            {
                r = Hover(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<Hover, ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<Hover>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<Hover, ResponseError> Hover(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: SignatureHelpRegistrationOptions
        [JsonRpcMethod("textDocument/signatureHelp")]
        public ResponseMessage<SignatureHelp> SignatureHelp(RequestMessage<TextDocumentPositionParams> request)
        {
            Result<SignatureHelp, ResponseError> r;
            try
            {
                r = SignatureHelp(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<SignatureHelp, ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<SignatureHelp>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<SignatureHelp, ResponseError> SignatureHelp(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/references")]
        public ResponseMessage<Location[]> FindReferences(RequestMessage<ReferenceParams> request)
        {
            Result<Location[], ResponseError> r;
            try
            {
                r = FindReferences(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<Location[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<Location[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<Location[], ResponseError> FindReferences(ReferenceParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/documentHighlight")]
        public ResponseMessage<DocumentHighlight[]> DocumentHighlight(RequestMessage<TextDocumentPositionParams> request)
        {
            Result<DocumentHighlight[], ResponseError> r;
            try
            {
                r = DocumentHighlight(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<DocumentHighlight[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<DocumentHighlight[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<DocumentHighlight[], ResponseError> DocumentHighlight(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/documentSymbol")]
        public ResponseMessage<SymbolInformation[]> DocumentSymbols(RequestMessage<DocumentSymbolParams> request)
        {
            Result<SymbolInformation[], ResponseError> r;
            try
            {
                r = DocumentSymbols(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<SymbolInformation[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<SymbolInformation[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<SymbolInformation[], ResponseError> DocumentSymbols(DocumentSymbolParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/formatting")]
        public ResponseMessage<TextEdit[]> DocumentFormatting(RequestMessage<DocumentFormattingParams> request)
        {
            Result<TextEdit[], ResponseError> r;
            try
            {
                r = DocumentFormatting(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<TextEdit[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<TextEdit[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<TextEdit[], ResponseError> DocumentFormatting(DocumentFormattingParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/rangeFormatting")]
        public ResponseMessage<TextEdit[]> DocumentRangeFormatting(RequestMessage<DocumentRangeFormattingParams> request)
        {
            Result<TextEdit[], ResponseError> r;
            try
            {
                r = DocumentRangeFormatting(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<TextEdit[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<TextEdit[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<TextEdit[], ResponseError> DocumentRangeFormatting(DocumentRangeFormattingParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: DocumentOnTypeFormattingRegistrationOptions
        [JsonRpcMethod("textDocument/onTypeFormatting")]
        public ResponseMessage<TextEdit[]> DocumentOnTypeFormatting(RequestMessage<DocumentOnTypeFormattingParams> request)
        {
            Result<TextEdit[], ResponseError> r;
            try
            {
                r = DocumentOnTypeFormatting(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<TextEdit[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<TextEdit[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<TextEdit[], ResponseError> DocumentOnTypeFormatting(DocumentOnTypeFormattingParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/definition")]
        public ResponseMessage<ArrayOrObject<Location, Location>> GotoDefinition(RequestMessage<TextDocumentPositionParams> request)
        {
            Result<ArrayOrObject<Location, Location>, ResponseError> r;
            try
            {
                r = GotoDefinition(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<ArrayOrObject<Location, Location>, ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<ArrayOrObject<Location, Location>>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<ArrayOrObject<Location, Location>, ResponseError> GotoDefinition(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/codeAction")]
        public ResponseMessage<Command[]> CodeAction(RequestMessage<CodeActionParams> request)
        {
            Result<Command[], ResponseError> r;
            try
            {
                r = CodeAction(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<Command[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<Command[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<Command[], ResponseError> CodeAction(CodeActionParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: CodeLensRegistrationOptions
        [JsonRpcMethod("textDocument/codeLens")]
        public ResponseMessage<CodeLens[]> CodeLens(RequestMessage<CodeLensParams> request)
        {
            Result<CodeLens[], ResponseError> r;
            try
            {
                r = CodeLens(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<CodeLens[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<CodeLens[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<CodeLens[], ResponseError> CodeLens(CodeLensParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("codeLens/resolve")]
        public ResponseMessage<CodeLens> ResolveCodeLens(RequestMessage<CodeLens> request)
        {
            Result<CodeLens, ResponseError> r;
            try
            {
                r = ResolveCodeLens(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<CodeLens, ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<CodeLens>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<CodeLens, ResponseError> ResolveCodeLens(CodeLens @params)
        {
            throw new NotImplementedException();
        }

        // dynam0icRegistration?: boolean;
        // Registration Options: DocumentLinkRegistrationOptions
        [JsonRpcMethod("textDocument/documentLink")]
        public ResponseMessage<DocumentLink[]> DocumentLink(RequestMessage<DocumentLinkParams> request)
        {
            Result<DocumentLink[], ResponseError> r;
            try
            {
                r = DocumentLink(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<DocumentLink[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<DocumentLink[]>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<DocumentLink[], ResponseError> DocumentLink(DocumentLinkParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("documentLink/resolve")]
        public ResponseMessage<DocumentLink> ResolveDocumentLink(RequestMessage<DocumentLink> request)
        {
            Result<DocumentLink, ResponseError> r;
            try
            {
                r = ResolveDocumentLink(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<DocumentLink, ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<DocumentLink>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<DocumentLink, ResponseError> ResolveDocumentLink(DocumentLink @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: TextDocumentRegistrationOptions
        [JsonRpcMethod("textDocument/rename")]
        public ResponseMessage<WorkspaceEdit> Rename(RequestMessage<RenameParams> request)
        {
            Result<WorkspaceEdit, ResponseError> r;
            try
            {
                r = Rename(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<WorkspaceEdit, ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<WorkspaceEdit>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<WorkspaceEdit, ResponseError> Rename(RenameParams @params)
        {
            throw new NotImplementedException();
        }
    }
}
