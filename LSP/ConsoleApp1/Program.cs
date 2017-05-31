using LanguageServer;
using LanguageServer.Infrastructure.JsonDotNet;
using LanguageServer.Json;
using LanguageServer.Parameters.General;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestReadAndHandle();
        }

        static void TestReadAndHandle()
        {
            Serializer.Instance = new JsonDotNetSerializer();

            var msIn = new MemoryStream();
            var msOut = new MemoryStream();
            var conn = new Connection(msIn, msOut);
            conn.AddDefinedJsonRpcMethods(new[] { typeof(GeneralService) });

            Console.WriteLine("---1");
            msOut.SetLength(0L);
            var r1 = new RequestMessage<InitializeParams>
            {
                id = 123,
                method = "initialize",
                @params = new InitializeParams
                {
                    capabilities = new ClientCapabilities
                    {
                        textDocument = new TextDocumentClientCapabilities
                        {
                            formatting = new RegistrationCapabilities
                            {
                                dynamicRegistration = true
                            }
                        }
                    }
                }
            };
            conn.SendRequest<InitializeParams, InitializeResult, ResponseError<InitializeErrorData>>(r1, x => { });
            msOut.Position = 0L;
            var in1 = msOut.ToArray();
            msIn.SetLength(0L);
            msIn.Write(in1, 0, in1.Length);

            msIn.Position = 0L;
            Console.WriteLine("---input");
            Console.WriteLine(new StreamReader(msIn, Encoding.UTF8).ReadToEnd());
            Console.WriteLine("---");

            msIn.Position = 0L;
            msOut.SetLength(0L);
            conn.TestReadAndHandle();

            msOut.Position = 0L;
            Console.WriteLine("---output");
            Console.WriteLine(new StreamReader(msOut, Encoding.UTF8).ReadToEnd());
            Console.WriteLine("---");
            Console.ReadLine();

            Console.WriteLine("---2");
            msOut.SetLength(0L);
            var r2 = new VoidNotificationMessage
            {
                method = "initialized"
            };
            conn.SendNotification(r2);
            msOut.Position = 0L;
            var in2 = msOut.ToArray();
            msIn.SetLength(0L);
            msIn.Write(in2, 0, in2.Length);

            msIn.Position = 0L;
            Console.WriteLine("---input");
            Console.WriteLine(new StreamReader(msIn, Encoding.UTF8).ReadToEnd());
            Console.WriteLine("---");

            msIn.Position = 0L;
            msOut.SetLength(0L);
            conn.TestReadAndHandle();

            msOut.Position = 0L;
            Console.WriteLine("---output");
            Console.WriteLine(new StreamReader(msOut, Encoding.UTF8).ReadToEnd());
            Console.WriteLine("---");
            Console.ReadLine();

            msIn.SetLength(0L);
            msOut.SetLength(0L);
            Task.Delay(1000).ContinueWith(_ => msIn.Close());
            try
            {
                conn.TestReadAndHandle();
            }
            catch(AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions[0]);
            }

            Console.WriteLine("closed");
        }
    }
}
