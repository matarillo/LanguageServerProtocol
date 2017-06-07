using LanguageServer.Client;
using LanguageServer.Parameters;
using LanguageServer.Parameters.Workspace;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Server
{
    public class WorkspaceServiceTemplate : JsonRpcService
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

        // dynamicRegistration?: boolean;
        [JsonRpcMethod("workspace/didChangeConfiguration")]
        public void DidChangeConfiguration(NotificationMessage<DidChangeConfigurationParams> notification)
        {
            try
            {
                this.DidChangeConfiguration(notification.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        protected virtual void DidChangeConfiguration(DidChangeConfigurationParams @params)
        {
        }

        // dynamicRegistration?: boolean;
        [JsonRpcMethod("workspace/didChangeWatchedFiles")]
        public void DidChangeWatchedFiles(NotificationMessage<DidChangeWatchedFilesParams> notification)
        {
            try
            {
                this.DidChangeWatchedFiles(notification.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        protected virtual void DidChangeWatchedFiles(DidChangeWatchedFilesParams @params)
        {
        }

        // dynamicRegistration?: boolean;
        // Registration Options: void
        [JsonRpcMethod("workspace/symbol")]
        public ResponseMessage<SymbolInformation[], ResponseError> Symbol(RequestMessage<WorkspaceSymbolParams> request)
        {
            Result<SymbolInformation[], ResponseError> r;
            try
            {
                r = Symbol(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<SymbolInformation[], ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<SymbolInformation[], ResponseError>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<SymbolInformation[], ResponseError> Symbol(WorkspaceSymbolParams @params)
        {
            throw new NotImplementedException();
        }

        // dynamicRegistration?: boolean;
        // Registration Options: ExecuteCommandRegistrationOptions
        [JsonRpcMethod("workspace/executeCommand")]
        public ResponseMessage<dynamic, ResponseError> ExecuteCommand(RequestMessage<ExecuteCommandParams> request)
        {
            Result<dynamic, ResponseError> r;
            try
            {
                r = ExecuteCommand(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Result<dynamic, ResponseError>.Error(Message.InternalError());
            }
            return new ResponseMessage<dynamic, ResponseError>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<dynamic, ResponseError> ExecuteCommand(ExecuteCommandParams @params)
        {
            throw new NotImplementedException();
        }
    }
}
