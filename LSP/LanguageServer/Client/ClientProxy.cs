using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Client
{
    public sealed class ClientProxy
    {
        private Connection _connection;
        private Window _window;

        public ClientProxy(Connection connection)
        {
            _connection = connection;
        }

        public Window Window
        {
            get
            {
                _window = _window ?? new Window(_connection);
                return _window;
            }
        }
    }
}
