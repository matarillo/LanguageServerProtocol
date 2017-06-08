using LanguageServer.Client;
using LanguageServer.Json;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Parameters.TextDocument;
using LanguageServer.Parameters.Workspace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace LanguageServer
{
    public abstract class ServiceConnection : Connection
    {
        private readonly Proxy _proxy;
        public Proxy Proxy => _proxy;
        private AsyncLocal<CancellationToken> _token = new AsyncLocal<CancellationToken>();
        public CancellationToken CancellationToken
        {
            get => _token.Value;
            internal set => _token.Value = value;
        }
        private List<MethodInfo> _methods;

        protected ServiceConnection(Stream input, Stream output)
            : base(input, output)
        {
            _proxy = new Proxy(this);
            _methods = this.GetType().GetRuntimeMethods().ToList();
            RegisterGeneralHandlers();
            RegisterWorkspaceHandlers();
            RegisterTextDocumentHandlers();
            _methods = null;
        }

        private bool IsOverridden(string methodName)
        {
            var baseType = typeof(ServiceConnection);
            return _methods.Exists(m => m.Name == methodName && m.DeclaringType != baseType && m.GetRuntimeBaseDefinition().DeclaringType == baseType);
        }

        private RequestHandlerDelegate CreateRequestHandlerDelegate<TParams, TResult, TResponseError>(Func<TParams, Result<TResult, TResponseError>> func)
            where TResponseError : ResponseError, new()
        {
            return (r, c, t) =>
            {
                var request = (RequestMessage<TParams>)r;
                _token.Value = t;
                try
                {
                    Result<TResult, TResponseError> result;
                    try
                    {
                        result = func(request.@params);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                        result = Result<TResult, TResponseError>.Error(Message.InternalError<TResponseError>());
                    }
                    return new ResponseMessage<TResult, TResponseError>
                    {
                        id = request.id,
                        result = result.SuccessValue,
                        error = result.ErrorValue
                    };
                }
                finally
                {
                    _token.Value = CancellationToken.None;
                }
            };
        }

        private RequestHandlerDelegate CreateRequestHandlerDelegate<TResult, TResponseError>(Func<Result<TResult, TResponseError>> func)
            where TResponseError : ResponseError, new()
        {
            return (r, c, t) =>
            {
                var request = (VoidRequestMessage)r;
                _token.Value = t;
                try
                {
                    Result<TResult, TResponseError> result;
                    try
                    {
                        result = func();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                        result = Result<TResult, TResponseError>.Error(Message.InternalError<TResponseError>());
                    }
                    return new ResponseMessage<TResult, TResponseError>
                    {
                        id = request.id,
                        result = result.SuccessValue,
                        error = result.ErrorValue
                    };
                }
                finally
                {
                    _token.Value = CancellationToken.None;
                }
            };
        }

        private RequestHandlerDelegate CreateRequestHandlerDelegate<TResponseError>(Func<VoidResult<TResponseError>> func)
            where TResponseError : ResponseError, new()
        {
            return (r, c, t) =>
            {
                var request = (VoidRequestMessage)r;
                _token.Value = t;
                try
                {
                    VoidResult<TResponseError> result;
                    try
                    {
                        result = func();
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                        result = VoidResult<TResponseError>.Error(Message.InternalError<TResponseError>());
                    }
                    return new VoidResponseMessage<TResponseError>
                    {
                        id = request.id,
                        error = result.ErrorValue
                    };
                }
                finally
                {
                    _token.Value = CancellationToken.None;
                }
            };
        }

        private NotificationHandlerDelegate CreateNotificationHandlerDelegate<TParams>(Action<TParams> action)
        {
            return (n, c) =>
            {
                var notification = (NotificationMessage<TParams>)n;
                try
                {
                    action(notification.@params);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            };
        }

        private NotificationHandlerDelegate CreateNotificationHandlerDelegate(Action action)
        {
            return (n, c) =>
            {
                var notification = (VoidNotificationMessage)n;
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            };
        }

        #region General

        private void RegisterGeneralHandlers()
        {
            if (IsOverridden(nameof(Initialize)))
            {
                var initializeDelegate = CreateRequestHandlerDelegate<InitializeParams, InitializeResult, ResponseError<InitializeErrorData>>(Initialize);
                var initialize = new RequestHandler("initialize", typeof(RequestMessage<InitializeParams>), typeof(ResponseMessage<InitializeResult, ResponseError<InitializeErrorData>>), initializeDelegate);
                Handlers.AddRequestHandler(initialize);
            }
            if (IsOverridden(nameof(Initialized)))
            {
                var initializedDelegate = CreateNotificationHandlerDelegate(Initialized);
                var initialized = new NotificationHandler("initialized", typeof(VoidNotificationMessage), initializedDelegate);
                Handlers.AddNotificationHandler(initialized);
            }
            if (IsOverridden(nameof(Shutdown)))
            {
                var shutdownDelegate = CreateRequestHandlerDelegate<ResponseError>(Shutdown);
                var shutdown = new RequestHandler("shutdown", typeof(VoidRequestMessage), typeof(VoidResponseMessage<ResponseError>), shutdownDelegate);
                Handlers.AddRequestHandler(shutdown);
            }
            if (IsOverridden(nameof(Exit)))
            {
                var exitDelegate = CreateNotificationHandlerDelegate(Exit);
                var exit = new NotificationHandler("exit", typeof(VoidNotificationMessage), exitDelegate);
                Handlers.AddNotificationHandler(exit);
            }
        }

        protected virtual Result<InitializeResult, ResponseError<InitializeErrorData>> Initialize(InitializeParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual void Initialized()
        {
        }

        protected virtual VoidResult<ResponseError> Shutdown()
        {
            throw new NotImplementedException();
        }

        protected virtual void Exit()
        {
        }

        #endregion

        #region Workspace

        private void RegisterWorkspaceHandlers()
        {
            if (IsOverridden(nameof(DidChangeConfiguration)))
            {
                var didChangeConfigurationDelegate = CreateNotificationHandlerDelegate<DidChangeConfigurationParams>(DidChangeConfiguration);
                var didChangeConfiguration = new NotificationHandler("workspace/didChangeConfiguration", typeof(VoidNotificationMessage), didChangeConfigurationDelegate);
                Handlers.AddNotificationHandler(didChangeConfiguration);
            }
            if (IsOverridden(nameof(DidChangeWatchedFiles)))
            {
                var didChangeWatchedFilesDelegate = CreateNotificationHandlerDelegate<DidChangeWatchedFilesParams>(DidChangeWatchedFiles);
                var didChangeWatchedFiles = new NotificationHandler("workspace/didChangeWatchedFiles", typeof(VoidNotificationMessage), didChangeWatchedFilesDelegate);
                Handlers.AddNotificationHandler(didChangeWatchedFiles);
            }
            if (IsOverridden(nameof(Symbol)))
            {
                var symbolDelegate = CreateRequestHandlerDelegate<WorkspaceSymbolParams, SymbolInformation[], ResponseError>(Symbol);
                var symbol = new RequestHandler("workspace/symbol", typeof(RequestMessage<WorkspaceSymbolParams>), typeof(ResponseMessage<SymbolInformation[], ResponseError>), symbolDelegate);
                Handlers.AddRequestHandler(symbol);
            }
            if (IsOverridden(nameof(ExecuteCommand)))
            {
                var executeCommandDelegate = CreateRequestHandlerDelegate<ExecuteCommandParams, dynamic, ResponseError>(ExecuteCommand);
                var executeCommand = new RequestHandler("workspace/executeCommand", typeof(RequestMessage<ExecuteCommandParams>), typeof(ResponseMessage<dynamic, ResponseError>), executeCommandDelegate);
                Handlers.AddRequestHandler(executeCommand);
            }
        }

        protected virtual void DidChangeConfiguration(DidChangeConfigurationParams @params)
        {
        }

        protected virtual void DidChangeWatchedFiles(DidChangeWatchedFilesParams @params)
        {
        }

        protected virtual Result<SymbolInformation[], ResponseError> Symbol(WorkspaceSymbolParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<dynamic, ResponseError> ExecuteCommand(ExecuteCommandParams @params)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TextDocument

        private void RegisterTextDocumentHandlers()
        {
            if (IsOverridden(nameof(DidOpenTextDocument)))
            {
                var didOpenDelegate = CreateNotificationHandlerDelegate<DidOpenTextDocumentParams>(DidOpenTextDocument);
                var didOpen = new NotificationHandler("textDocument/didOpen", typeof(NotificationMessage<DidOpenTextDocumentParams>), didOpenDelegate);
                Handlers.AddNotificationHandler(didOpen);
            }
            if (IsOverridden(nameof(DidChangeTextDocument)))
            {
                var didChangeDelegate = CreateNotificationHandlerDelegate<DidChangeTextDocumentParams>(DidChangeTextDocument);
                var didChange = new NotificationHandler("textDocument/didChange", typeof(NotificationMessage<DidChangeTextDocumentParams>), didChangeDelegate);
                Handlers.AddNotificationHandler(didChange);
            }
            if (IsOverridden(nameof(WillSaveTextDocument)))
            {
                var willSaveDelegate = CreateNotificationHandlerDelegate<WillSaveTextDocumentParams>(WillSaveTextDocument);
                var willSave = new NotificationHandler("textDocument/willSave", typeof(NotificationMessage<WillSaveTextDocumentParams>), willSaveDelegate);
                Handlers.AddNotificationHandler(willSave);
            }
            if (IsOverridden(nameof(WillSaveWaitUntilTextDocument)))
            {
                var willSaveWaitUntilDelegate = CreateRequestHandlerDelegate<WillSaveTextDocumentParams, TextEdit[], ResponseError>(WillSaveWaitUntilTextDocument);
                var willSaveWaitUntil = new RequestHandler("textDocument/willSaveWaitUntil", typeof(RequestMessage<WillSaveTextDocumentParams>), typeof(ResponseMessage<TextEdit[], ResponseError>), willSaveWaitUntilDelegate);
                Handlers.AddRequestHandler(willSaveWaitUntil);
            }
            if (IsOverridden(nameof(DidSaveTextDocument)))
            {
                var didSaveDelegate = CreateNotificationHandlerDelegate<DidSaveTextDocumentParams>(DidSaveTextDocument);
                var didSave = new NotificationHandler("textDocument/didSave", typeof(NotificationMessage<DidOpenTextDocumentParams>), didSaveDelegate);
                Handlers.AddNotificationHandler(didSave);
            }
            if (IsOverridden(nameof(DidCloseTextDocument)))
            {
                var didCloseDelegate = CreateNotificationHandlerDelegate<DidCloseTextDocumentParams>(DidCloseTextDocument);
                var didClose = new NotificationHandler("textDocument/didClose", typeof(NotificationMessage<DidChangeTextDocumentParams>), didCloseDelegate);
                Handlers.AddNotificationHandler(didClose);
            }
            if (IsOverridden(nameof(Completion)))
            {
                var completionDelegate = CreateRequestHandlerDelegate<TextDocumentPositionParams, ArrayOrObject<CompletionItem, CompletionList>, ResponseError>(Completion);
                var completion = new RequestHandler("textDocument/completion", typeof(RequestMessage<TextDocumentPositionParams>), typeof(ResponseMessage<ArrayOrObject<CompletionItem, CompletionList>, ResponseError>), completionDelegate);
                Handlers.AddRequestHandler(completion);
            }
            if (IsOverridden(nameof(ResolveCompletionItem)))
            {
                var resolveCompletionItemDelegate = CreateRequestHandlerDelegate<CompletionItem, CompletionItem, ResponseError>(ResolveCompletionItem);
                var resolveCompletionItem = new RequestHandler("completionItem/resolve", typeof(RequestMessage<CompletionItem>), typeof(ResponseMessage<CompletionItem, ResponseError>), resolveCompletionItemDelegate);
                Handlers.AddRequestHandler(resolveCompletionItem);
            }
            if (IsOverridden(nameof(Hover)))
            {
                var hoverDelegate = CreateRequestHandlerDelegate<TextDocumentPositionParams, Hover, ResponseError>(Hover);
                var hover = new RequestHandler("textDocument/hover", typeof(RequestMessage<TextDocumentPositionParams>), typeof(ResponseMessage<Hover, ResponseError>), hoverDelegate);
                Handlers.AddRequestHandler(hover);
            }
            if (IsOverridden(nameof(SignatureHelp)))
            {
                var signatureHelpDelegate = CreateRequestHandlerDelegate<TextDocumentPositionParams, SignatureHelp, ResponseError>(SignatureHelp);
                var signatureHelp = new RequestHandler("textDocument/signatureHelp", typeof(RequestMessage<TextDocumentPositionParams>), typeof(ResponseMessage<SignatureHelp, ResponseError>), signatureHelpDelegate);
                Handlers.AddRequestHandler(signatureHelp);
            }
            if (IsOverridden(nameof(FindReferences)))
            {
                var findReferencesDelegate = CreateRequestHandlerDelegate<ReferenceParams, Location[], ResponseError>(FindReferences);
                var findReferences = new RequestHandler("textDocument/references", typeof(RequestMessage<ReferenceParams>), typeof(ResponseMessage<Location[], ResponseError>), findReferencesDelegate);
                Handlers.AddRequestHandler(findReferences);
            }
            if (IsOverridden(nameof(DocumentHighlight)))
            {
                var documentHighlightDelegate = CreateRequestHandlerDelegate<TextDocumentPositionParams, DocumentHighlight[], ResponseError>(DocumentHighlight);
                var documentHighlight = new RequestHandler("textDocument/documentHighlight", typeof(RequestMessage<TextDocumentPositionParams>), typeof(ResponseMessage<DocumentHighlight[], ResponseError>), documentHighlightDelegate);
                Handlers.AddRequestHandler(documentHighlight);
            }
            if (IsOverridden(nameof(DocumentSymbols)))
            {
                var documentSymbolsDelegate = CreateRequestHandlerDelegate<DocumentSymbolParams, SymbolInformation[], ResponseError>(DocumentSymbols);
                var documentSymbols = new RequestHandler("textDocument/documentSymbol", typeof(RequestMessage<DocumentSymbolParams>), typeof(ResponseMessage<SymbolInformation[], ResponseError>), documentSymbolsDelegate);
                Handlers.AddRequestHandler(documentSymbols);
            }
            if (IsOverridden(nameof(DocumentFormatting)))
            {
                var documentFormattingDelegate = CreateRequestHandlerDelegate<DocumentFormattingParams, TextEdit[], ResponseError>(DocumentFormatting);
                var documentFormatting = new RequestHandler("textDocument/formatting", typeof(RequestMessage<DocumentFormattingParams>), typeof(ResponseMessage<TextEdit[], ResponseError>), documentFormattingDelegate);
                Handlers.AddRequestHandler(documentFormatting);
            }
            if (IsOverridden(nameof(DocumentRangeFormatting)))
            {
                var documentRangeFormattingDelegate = CreateRequestHandlerDelegate<DocumentRangeFormattingParams, TextEdit[], ResponseError>(DocumentRangeFormatting);
                var documentRangeFormatting = new RequestHandler("textDocument/rangeFormatting", typeof(RequestMessage<DocumentRangeFormattingParams>), typeof(ResponseMessage<TextEdit[], ResponseError>), documentRangeFormattingDelegate);
                Handlers.AddRequestHandler(documentRangeFormatting);
            }
            if (IsOverridden(nameof(DocumentOnTypeFormatting)))
            {
                var documentOnTypeFormattingDelegate = CreateRequestHandlerDelegate<DocumentOnTypeFormattingParams, TextEdit[], ResponseError>(DocumentOnTypeFormatting);
                var documentOnTypeFormatting = new RequestHandler("textDocument/onTypeFormatting", typeof(RequestMessage<DocumentOnTypeFormattingParams>), typeof(ResponseMessage<TextEdit[], ResponseError>), documentOnTypeFormattingDelegate);
                Handlers.AddRequestHandler(documentOnTypeFormatting);
            }
            if (IsOverridden(nameof(GotoDefinition)))
            {
                var gotoDefinitionDelegate = CreateRequestHandlerDelegate<TextDocumentPositionParams, ArrayOrObject<Location, Location>, ResponseError>(GotoDefinition);
                var gotoDefinition = new RequestHandler("textDocument/definition", typeof(RequestMessage<TextDocumentPositionParams>), typeof(ResponseMessage<ArrayOrObject<Location, Location>, ResponseError>), gotoDefinitionDelegate);
                Handlers.AddRequestHandler(gotoDefinition);
            }
            if (IsOverridden(nameof(CodeAction)))
            {
                var codeActionDelegate = CreateRequestHandlerDelegate<CodeActionParams, Command[], ResponseError>(CodeAction);
                var codeAction = new RequestHandler("textDocument/codeAction", typeof(RequestMessage<CodeActionParams>), typeof(ResponseMessage<Command[], ResponseError>), codeActionDelegate);
                Handlers.AddRequestHandler(codeAction);
            }
            if (IsOverridden(nameof(CodeLens)))
            {
                var codeLensDelegate = CreateRequestHandlerDelegate<CodeLensParams, CodeLens[], ResponseError>(CodeLens);
                var codeLens = new RequestHandler("textDocument/codeLens", typeof(RequestMessage<CodeLensParams>), typeof(ResponseMessage<CodeLens[], ResponseError>), codeLensDelegate);
                Handlers.AddRequestHandler(codeLens);
            }
            if (IsOverridden(nameof(ResolveCodeLens)))
            {
                var resolveCodeLensDelegate = CreateRequestHandlerDelegate<CodeLens, CodeLens, ResponseError>(ResolveCodeLens);
                var resolveCodeLens = new RequestHandler("codeLens/resolve", typeof(RequestMessage<CodeLens>), typeof(ResponseMessage<CodeLens, ResponseError>), resolveCodeLensDelegate);
                Handlers.AddRequestHandler(resolveCodeLens);
            }
            if (IsOverridden(nameof(DocumentLink)))
            {
                var documentLinkDelegate = CreateRequestHandlerDelegate<DocumentLinkParams, DocumentLink[], ResponseError>(DocumentLink);
                var documentLink = new RequestHandler("textDocument/documentLink", typeof(RequestMessage<DocumentLinkParams>), typeof(ResponseMessage<DocumentLink[], ResponseError>), documentLinkDelegate);
                Handlers.AddRequestHandler(documentLink);
            }
            if (IsOverridden(nameof(ResolveDocumentLink)))
            {
                var resolveDocumentLinkDelegate = CreateRequestHandlerDelegate<DocumentLink, DocumentLink, ResponseError>(ResolveDocumentLink);
                var resolveDocumentLink = new RequestHandler("documentLink/resolve", typeof(RequestMessage<DocumentLink>), typeof(ResponseMessage<DocumentLink, ResponseError>), resolveDocumentLinkDelegate);
                Handlers.AddRequestHandler(resolveDocumentLink);
            }
            if (IsOverridden(nameof(Rename)))
            {
                var renameDelegate = CreateRequestHandlerDelegate<RenameParams, WorkspaceEdit, ResponseError>(Rename);
                var rename = new RequestHandler("textDocument/rename", typeof(RequestMessage<RenameParams>), typeof(ResponseMessage<WorkspaceEdit, ResponseError>), renameDelegate);
                Handlers.AddRequestHandler(rename);
            }
        }

        protected virtual void DidOpenTextDocument(DidOpenTextDocumentParams @params)
        {
        }

        protected virtual void DidChangeTextDocument(DidChangeTextDocumentParams @params)
        {
        }

        protected virtual void WillSaveTextDocument(WillSaveTextDocumentParams @params)
        {
        }

        protected virtual Result<TextEdit[], ResponseError> WillSaveWaitUntilTextDocument(WillSaveTextDocumentParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual void DidSaveTextDocument(DidSaveTextDocumentParams @params)
        {
        }

        protected virtual void DidCloseTextDocument(DidCloseTextDocumentParams @params)
        {
        }

        protected virtual Result<ArrayOrObject<CompletionItem, CompletionList>, ResponseError> Completion(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<CompletionItem, ResponseError> ResolveCompletionItem(CompletionItem @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<Hover, ResponseError> Hover(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<SignatureHelp, ResponseError> SignatureHelp(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<Location[], ResponseError> FindReferences(ReferenceParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<DocumentHighlight[], ResponseError> DocumentHighlight(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<SymbolInformation[], ResponseError> DocumentSymbols(DocumentSymbolParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<TextEdit[], ResponseError> DocumentFormatting(DocumentFormattingParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<TextEdit[], ResponseError> DocumentRangeFormatting(DocumentRangeFormattingParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<TextEdit[], ResponseError> DocumentOnTypeFormatting(DocumentOnTypeFormattingParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<ArrayOrObject<Location, Location>, ResponseError> GotoDefinition(TextDocumentPositionParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<Command[], ResponseError> CodeAction(CodeActionParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<CodeLens[], ResponseError> CodeLens(CodeLensParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<CodeLens, ResponseError> ResolveCodeLens(CodeLens @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<DocumentLink[], ResponseError> DocumentLink(DocumentLinkParams @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<DocumentLink, ResponseError> ResolveDocumentLink(DocumentLink @params)
        {
            throw new NotImplementedException();
        }

        protected virtual Result<WorkspaceEdit, ResponseError> Rename(RenameParams @params)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
