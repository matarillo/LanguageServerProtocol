using LanguageServer.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Reflection;

namespace LanguageServer
{
    public class Service
    {
        public virtual Connection Connection { get; set; }

        public CancellationToken CancellationToken { get; set; }

        public static void Register(Connection connection, Type[] serviceTypes)
        {
            var rpcType = typeof(Service).GetTypeInfo();
            if (serviceTypes.Any(x => !rpcType.IsAssignableFrom(x.GetTypeInfo())))
            {
                throw new ArgumentException("Specify types derived from JsonRpcService", nameof(serviceTypes));
            }
            var provider = new ServiceHandlerProvider();
            foreach (var serviceType in serviceTypes)
            {
                provider.AddHandlers(connection.Handlers, serviceType);
            }
        }

        public static void Register(Connection connection, Type serviceType)
        {
            var provider = new ServiceHandlerProvider();
            provider.AddHandlers(connection.Handlers, serviceType);
        }
    }
}
