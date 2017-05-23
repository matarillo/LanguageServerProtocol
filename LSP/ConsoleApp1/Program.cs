using LanguageServer;
using LanguageServer.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        static void TestSerializer()
        {
            Serializer.Instance = new LanguageServer.Infrastructure.JsonDotNet.JsonDotNetSerializer();
            var f1 = new Foo { Bar = new NumberOrObject<Bar>(123) };
            var json1 = Serializer.Instance.Serialize(f1.GetType(), f1);
            var f11 = (NumberOrObject<Foo>)Serializer.Instance.Deserialize(typeof(NumberOrObject<Foo>), json1);
            Console.WriteLine(f11);

            var f2 = new Foo { Bar = new NumberOrObject<Bar>(new Bar { A = 123 }) };
            var json2 = Serializer.Instance.Serialize(f1.GetType(), f2);
            var f22 = (NumberOrObject<Foo>)Serializer.Instance.Deserialize(typeof(NumberOrObject<Foo>), json2);
            Console.WriteLine(f22);
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
            var r1 = new RequestMessage<LanguageServer.Parameters.InitializeParams>
            {
                id = 123,
                method = "/initialize",
                @params = new LanguageServer.Parameters.InitializeParams
                {
                    capabilities = new LanguageServer.Parameters.ClientCapabilities
                    {
                        textDocument = new LanguageServer.Parameters.TextDocumentClientCapabilities
                        {
                            formatting = new LanguageServer.Parameters.RegistrationCapabilities
                            {
                                dynamicRegistration = true
                            }
                        }
                    }
                }
            };
            conn.SendRequest<LanguageServer.Parameters.InitializeParams, LanguageServer.Parameters.InitializeResult, LanguageServer.Parameters.InitializeError>(r1, x => { });
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
            var r2 = new NotificationMessage<LanguageServer.Parameters.CancelParams>
            {
                method = "/cancelRequest",
                @params = new LanguageServer.Parameters.CancelParams
                {
                    id = 12
                }
            };
            conn.SendNotification<LanguageServer.Parameters.CancelParams>(r2);
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

    public class Foo
    {
        public NumberOrObject<Bar> Bar { get; set; }
        public override string ToString()
        {
            return "{Bar: " + Bar.ToString() + "}";
        }
    }
    public class Bar
    {
        public NumberOrString A { get; set; }
        public override string ToString()
        {
            return "{A: " + A + "}";
        }
    }
}
