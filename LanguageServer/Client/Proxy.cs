using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Client
{
    /// <summary>
    /// The proxy class for sending messages from the server to the client.
    /// </summary>
    public sealed class Proxy
    {
        private Connection _connection;
        private WindowProxy _window;
        private ClientProxy _client;
        private WorkspaceProxy _workspace;
        private TextDocumentProxy _textDocument;

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy"/>.
        /// </summary>
        /// <param name="connection"></param>
        public Proxy(Connection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Gets the proxy object for sending messages related to <c>window</c>.
        /// </summary>
        public WindowProxy Window
        {
            get
            {
                _window = _window ?? new WindowProxy(_connection);
                return _window;
            }
        }

        /// <summary>
        /// Gets the proxy object for sending messages related to <c>client</c>.
        /// </summary>
        public ClientProxy Client
        {
            get
            {
                _client = _client ?? new ClientProxy(_connection);
                return _client;
            }
        }

        /// <summary>
        /// Gets the proxy object for sending messages related to <c>workspace</c>.
        /// </summary>
        public WorkspaceProxy Workspace
        {
            get
            {
                _workspace = _workspace ?? new WorkspaceProxy(_connection);
                return _workspace;
            }
        }

        /// <summary>
        /// Gets the proxy object for sending messages related to <c>textDocument</c>.
        /// </summary>
        public TextDocumentProxy TextDocument
        {
            get
            {
                _textDocument = _textDocument ?? new TextDocumentProxy(_connection);
                return _textDocument;
            }
        }
    }
}
