using LanguageServer.Client;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Parameters.Workspace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Linq;

namespace LanguageServer
{
    public abstract class ServiceConnection : Connection
    {
        private readonly Proxy _proxy;
        public Proxy Proxy => _proxy;
        private AsyncLocal<CancellationToken> _token = new AsyncLocal<CancellationToken>();
        public CancellationToken CancellationToken => _token.Value;
        private List<MethodInfo> _methods;

        protected ServiceConnection(Stream input, Stream output)
            : base(input, output)
        {
            _proxy = new Proxy(this);
            _methods = this.GetType().GetRuntimeMethods().ToList();
            RegisterGeneralHandlers();
            RegisterWorkspaceHandlers();
            // RegisterTextEditHandlers();
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

    }
}
