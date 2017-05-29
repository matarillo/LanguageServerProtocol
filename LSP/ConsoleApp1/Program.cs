using LanguageServer;
using LanguageServer.Infrastructure.JsonDotNet;
using LanguageServer.Json;
using Newtonsoft.Json;
using System;
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
        static void M()
        {
            SDS(new G
            {
                eo = E.B,
                so = "string",
                no = 123,
            });
            SDS(new G
            {
                eo = new F { name = "eo" },
                so = new F { name = "so" },
                no = new F { name = "no" },
            });
        }
        static void SDS(G g)
        {
            var conv = new EitherConverter();
            var json1 = JsonConvert.SerializeObject(g, conv);
            Console.WriteLine(json1);
            var g2 = JsonConvert.DeserializeObject<G>(json1, conv);
            Console.WriteLine(g2.eo.IsLeft ? (object)g2.eo.Left : g2.eo.Right);
            Console.WriteLine(g2.so.IsLeft ? (object)g2.so.Left : g2.so.Right);
            Console.WriteLine(g2.no.IsLeft ? (object)g2.no.Left : g2.no.Right);
        }
        public enum E { A=1, B=2 }
        public class F
        {
            public string name { get; set; }
            public override string ToString()
            {
                return $"{{name:{this.name}}}";
            }
        }
        public class G
        {
            public NumberOrObject<E, F> eo { get; set; }
            public StringOrObject<F> so { get; set; }
            public NumberOrObject<int, F> no { get; set; }
        }

        static void TestReadAndHandle()
        {
            Serializer.Instance = new JsonDotNetSerializer();

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
            conn.SendRequest<LanguageServer.Parameters.General.InitializeParams, LanguageServer.Parameters.General.InitializeResult, ResponseError<LanguageServer.Parameters.General.InitializeErrorData>>(r1, x => { });
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
