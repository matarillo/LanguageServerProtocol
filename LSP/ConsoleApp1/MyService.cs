using LanguageServer;
using LanguageServer.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyService : JsonRpcService
    {
        [JsonRpcMethod("/initialize")]
        public ResponseMessage<InitializeResult, InitializeError> Initialize(RequestMessage<InitializeParams> request)
        {
            Console.WriteLine("/initialize: id=" + request.id);
            Console.WriteLine("CancellationToken: " + (this.CancellationToken == System.Threading.CancellationToken.None ? "None" : "Some"));
            return new ResponseMessage<InitializeResult, InitializeError>
            {
                id = request.id,
                result = new InitializeResult
                {
                    capabilities = new ServerCapabilities
                    {
                        hoverProvider = true
                    }
                }
            };
        }

        [JsonRpcMethod("/cancelRequest")]
        public void Cancel(RequestMessage<CancelParams> request)
        {
            Console.WriteLine("cancelRequest: id=" + request.@params.id);
            Console.WriteLine("CancellationToken: " + (this.CancellationToken == System.Threading.CancellationToken.None ? "None" : "Some"));
        }
    }
}
