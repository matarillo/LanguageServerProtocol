using LanguageServer.Client;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using System;

namespace LanguageServer.Server
{
    public class GeneralServiceTemplate : JsonRpcService
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

        [JsonRpcMethod("initialize")]
        public ResponseMessage<InitializeResult, ResponseError<InitializeErrorData>> Initialize(RequestMessage<InitializeParams> request)
        {
            Result<InitializeResult, ResponseError<InitializeErrorData>> r;
            try
            {
                r = Initialize(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<InitializeErrorData>(null);
            }
            return new ResponseMessage<InitializeResult, ResponseError<InitializeErrorData>>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<InitializeResult, ResponseError<InitializeErrorData>> Initialize(InitializeParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("initialized")]
        public void Initialized(NotificationMessage notification)
        {
            try
            {
                this.Initialized();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        protected virtual void Initialized()
        {
        }

        [JsonRpcMethod("shutdown")]
        public ResponseMessage Shutdown(RequestMessage request)
        {
            Result<_Void, ResponseError> r;
            try
            {
                r = Shutdown();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError();
            }
            return new ResponseMessage
            {
                id = request.id,
                error = r.Error
            };
        }

        protected virtual Result<_Void, ResponseError> Shutdown()
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("exit")]
        public void Exit(NotificationMessage notification)
        {
            try
            {
                this.Exit();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        protected virtual void Exit()
        {
        }
    }
}
