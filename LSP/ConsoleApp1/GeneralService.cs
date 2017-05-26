using LanguageServer;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Server;
using System;

namespace ConsoleApp1
{
    public class GeneralService : GeneralServiceTemplate
    {
        protected override Result<InitializeResult, Error<InitializeError>> Initialize(InitializeParams @params)
        {
            Console.WriteLine("[Initialize]");
            return new InitializeResult
            {
                capabilities = new ServerCapabilities
                {
                    definitionProvider = true,
                    textDocumentSync = TextDocumentSyncKind.Full
                }
            };
        }

        protected override void Initialized()
        {
            Console.WriteLine("[Initialized]");
        }
    }
}
