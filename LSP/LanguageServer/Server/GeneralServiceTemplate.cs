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
        public _ResponseMessage<InitializeResult, InitializeError> Initialize(RequestMessage<InitializeParams> request)
        {
            Result<InitializeResult, InitializeError> r;
            try
            {
                r = Initialize(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error._InternalError<InitializeError>();
            }
            return new _ResponseMessage<InitializeResult, InitializeError>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<InitializeResult, InitializeError> Initialize(InitializeParams @params)
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
        public _ResponseMessage Shutdown(RequestMessage request)
        {
            Result<_Void, ResponseError> r;
            try
            {
                r = Shutdown();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error._InternalError<ResponseError>();
            }
            return new _ResponseMessage
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
