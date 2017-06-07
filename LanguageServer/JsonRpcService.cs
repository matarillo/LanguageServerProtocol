using LanguageServer.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Reflection;

namespace LanguageServer
{
    public class JsonRpcService
    {
        public virtual Connection Connection { get; set; }

        public CancellationToken CancellationToken { get; set; }

        public static void Register(Connection connection, Type[] serviceTypes)
        {
            var rpcType = typeof(JsonRpcService).GetTypeInfo();
            if (serviceTypes.Any(x => !rpcType.IsAssignableFrom(x.GetTypeInfo())))
            {
                throw new ArgumentException("Specify types derived from JsonRpcService", nameof(serviceTypes));
            }
            foreach (var serviceType in serviceTypes)
            {
                Register(connection, serviceType);
            }
        }

        public static void Register(Connection connection, Type serviceType)
        {
            var reflector = new Reflector(serviceType);
            connection.Handlers.AddRequestHandlers(reflector.RequestHandlers);
            connection.Handlers.AddNotificationHandlers(reflector.NotificationHandlers);
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class JsonRpcMethodAttribute : Attribute
    {
        private string _method;

        public JsonRpcMethodAttribute(string method)
        {
            _method = method;
        }

        public string Method
        {
            get => _method;
        }
    }
}
