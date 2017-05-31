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
                r = Result<InitializeResult, ResponseError<InitializeErrorData>>.Error(Error.InternalError<InitializeErrorData>(null));
            }
            return new ResponseMessage<InitializeResult, ResponseError<InitializeErrorData>>
            {
                id = request.id,
                result = r.SuccessValue,
                error = r.ErrorValue
            };
        }

        protected virtual Result<InitializeResult, ResponseError<InitializeErrorData>> Initialize(InitializeParams @params)
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("initialized")]
        public void Initialized(VoidNotificationMessage notification)
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
        public VoidResponseMessage Shutdown(VoidRequestMessage request)
        {
            VoidResult<ResponseError> r;
            try
            {
                r = Shutdown();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                r = VoidResult<ResponseError>.Error(Error.InternalError());
            }
            return new VoidResponseMessage
            {
                id = request.id,
                error = r.ErrorValue
            };
        }

        protected virtual VoidResult<ResponseError> Shutdown()
        {
            throw new NotImplementedException();
        }

        [JsonRpcMethod("exit")]
        public void Exit(VoidNotificationMessage notification)
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
