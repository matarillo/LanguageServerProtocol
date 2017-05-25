using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Client
{
    public sealed class Proxy
    {
        private Connection _connection;
        private WindowProxy _window;
        private ClientProxy _client;
        private WorkspaceProxy _workspace;

        public Proxy(Connection connection)
        {
            _connection = connection;
        }

        public WindowProxy Window
        {
            get
            {
                _window = _window ?? new WindowProxy(_connection);
                return _window;
            }
        }

        public ClientProxy Client
        {
            get
            {
                _client = _client ?? new ClientProxy(_connection);
                return _client;
            }
        }

        public WorkspaceProxy Workspace
        {
            get
            {
                _workspace = _workspace ?? new WorkspaceProxy(_connection);
                return _workspace;
            }
        }

    }
}
