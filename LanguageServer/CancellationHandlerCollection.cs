using System.Threading;
using LanguageServer.Json;

namespace LanguageServer
{
    internal class CancellationHandlerCollection
    {
        private readonly SyncDictionary<NumberOrString, CancellationTokenSource> cancellations = new SyncDictionary<NumberOrString, CancellationTokenSource>();

        internal void AddCancellationTokenSource(NumberOrString id, CancellationTokenSource tokenSource)
        {
            cancellations.Set(id, tokenSource);
        }

        internal void RemoveCancellationTokenSource(NumberOrString id)
        {
            cancellations.Remove(id);
        }

        internal bool TryRemoveCancellationTokenSource(NumberOrString id, out CancellationTokenSource tokenSource)
        {
            return cancellations.TryRemove(id, out tokenSource);
        }
    }
}