# LanguageServerProtocol

A library to handle [Language Server Protocol](https://github.com/Microsoft/language-server-protocol).

# Usage

- Client to Server
  - Define service classes derived from `LanguageServer.Server.GeneralServiceTemplate`, `LanguageServer.Server.WorkspaceServiceTemplate`, and `LanguageServer.Server.TextDocumentServiceTemplate`.
  - Override virtual methods.

- Server to Client
  - Call methods of `LanguageServer.Client.ClientProxy`, `LanguageServer.Client.WindowProxy`, `LanguageServer.Client.WorkspaceProxy`, and `LanguageServer.Client.TextDocumentProxy` classes via service classes' `Proxy` property.

- Run
  - Create an instance of `LanguageServer.Connection` class.
  - Register types of service classes via `Connection.RegisterHandlerMethods(Type[] serviceTypes)` instance method.
  - Call `Connection.Start()` instance method.
