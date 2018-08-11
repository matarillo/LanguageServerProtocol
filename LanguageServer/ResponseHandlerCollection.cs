using LanguageServer.Json;

namespace LanguageServer
{
    internal class ResponseHandlerCollection
    {
        private readonly SyncDictionary<NumberOrString, ResponseHandler> responseHandlers = new SyncDictionary<NumberOrString, ResponseHandler>();
        
        internal void AddResponseHandler(ResponseHandler responseHandler)
        {
            responseHandlers.Set(responseHandler.Id, responseHandler);
        }

        internal bool TryRemoveResponseHandler(NumberOrString id, out ResponseHandler responseHandler)
        {
            return responseHandlers.TryRemove(id, out responseHandler);
        }
    }
}