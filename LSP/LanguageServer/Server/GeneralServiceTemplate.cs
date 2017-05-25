using LanguageServer.Client;
using LanguageServer.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

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
        public ResponseMessage<InitializeResult, InitializeError> Initialize(RequestMessage<InitializeParams> request)
        {
            Result<InitializeResult, Error<InitializeError>> r;
            try
            {
                r = Initialize(request.@params);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<InitializeError>();
            }
            return new ResponseMessage<InitializeResult, InitializeError>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<InitializeResult, Error<InitializeError>> Initialize(InitializeParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("initialized")]
        public void Initialized(NotificationMessage<_Void> notification)
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
        public ResponseMessage<_Void, _Void> Shutdown(RequestMessage<_Void> request)
        {
            Result<_Void, Error<_Void>> r;
            try
            {
                r = Shutdown();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = Error.InternalError<_Void>();
            }
            return new ResponseMessage<_Void, _Void>
            {
                id = request.id,
                result = r.Success,
                error = r.Error
            };
        }

        protected virtual Result<_Void, Error<_Void>> Shutdown()
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("exit")]
        public void Exit(NotificationMessage<_Void> notification)
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
