using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model;
using RNano.HelloWorld.Domain.Model.Proxy;
using RNano.HelloWorld.Proxy.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RNano.HelloWorld.Proxy
{
    public class MessageProxy : IMessageProxy
    {
        // Fields

        private bool _disposed;
        private readonly HttpClient _http;
        private readonly string _extBaseUriString;
        private readonly ILogger _logger;

        // Constructor

        public MessageProxy(HttpClient http, ILogger<MessageProxy> logger)
        {
            // Assign
            _http = http;
            _extBaseUriString = "Message/";
            _logger = logger;
        }

        // Public

        public async Task<MessageModel> GetMessage()
        {
            var r = await _http.GetAsync($"{_extBaseUriString}");
            return await r.JsonAsObject<MessageModel>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposed)
        {
            if (disposed && !_disposed)
            {
                _http.Dispose();
                _disposed = true;
            }
        }
    }
}
