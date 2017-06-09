using LanguageServer.Client;
using LanguageServer.Parameters.General;
using System;

namespace LanguageServer.Server
{
    public class GeneralServiceTemplate : Service
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
        protected virtual Result<InitializeResult, ResponseError<InitializeErrorData>> Initialize(InitializeParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("initialized")]
        protected virtual void Initialized()
        {
        }

        [JsonRpcMethod("shutdown")]
        protected virtual VoidResult<ResponseError> Shutdown()
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("exit")]
        protected virtual void Exit()
        {
        }
    }
}
