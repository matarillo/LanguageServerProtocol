using LanguageServer;
using LanguageServer.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void TestReadAndHandle()
        {
            Serializer.Instance = new LanguageServer.Infrastructure.JsonDotNet.JsonDotNetSerializer();

            var msIn = new System.IO.MemoryStream();
            var msOut = new System.IO.MemoryStream();
            var conn = new Connection(msIn, msOut);
            conn.AddDefinedJsonRpcMethods(typeof(Program).Assembly);

            Console.WriteLine("---1");
            msOut.SetLength(0L);
            var r1 = new RequestMessage<LanguageServer.Parameters.General.InitializeParams>
            {
                id = 123,
                method = "initialize",
                @params = new LanguageServer.Parameters.General.InitializeParams
                {
                    capabilities = new LanguageServer.Parameters.General.ClientCapabilities
                    {
                        textDocument = new LanguageServer.Parameters.General.TextDocumentClientCapabilities
                        {
                            formatting = new LanguageServer.Parameters.General.RegistrationCapabilities
                            {
                                dynamicRegistration = true
                            }
                        }
                    }
                }
            };
            conn.SendRequest<LanguageServer.Parameters.General.InitializeParams, LanguageServer.Parameters.General.InitializeResult, LanguageServer.Parameters.General.InitializeError>(r1, x => { });
            msOut.Position = 0L;
            var in1 = msOut.ToArray();
            msIn.SetLength(0L);
            msIn.Write(in1, 0, in1.Length);

            msIn.Position = 0L;
            Console.WriteLine("---input");
            Console.WriteLine(new System.IO.StreamReader(msIn, Encoding.UTF8).ReadToEnd());
            Console.WriteLine("---");

            msIn.Position = 0L;
            msOut.SetLength(0L);
            conn.TestReadAndHandle();

            msOut.Position = 0L;
            Console.WriteLine("---output");
            Console.WriteLine(new System.IO.StreamReader(msOut, Encoding.UTF8).ReadToEnd());
            Console.WriteLine("---");
            Console.ReadLine();

            Console.WriteLine("---2");
            msOut.SetLength(0L);
            var r2 = new NotificationMessage<LanguageServer.Parameters._Void>
            {
                method = "initialized"
            };
            conn.SendNotification<LanguageServer.Parameters._Void>(r2);
            msOut.Position = 0L;
            var in2 = msOut.ToArray();
            msIn.SetLength(0L);
            msIn.Write(in2, 0, in2.Length);

            msIn.Position = 0L;
            Console.WriteLine("---input");
            Console.WriteLine(new System.IO.StreamReader(msIn, Encoding.UTF8).ReadToEnd());
            Console.WriteLine("---");

            msIn.Position = 0L;
            msOut.SetLength(0L);
            conn.TestReadAndHandle();

            msOut.Position = 0L;
            Console.WriteLine("---output");
            Console.WriteLine(new System.IO.StreamReader(msOut, Encoding.UTF8).ReadToEnd());
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
