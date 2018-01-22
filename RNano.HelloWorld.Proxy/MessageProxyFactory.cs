using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RNano.HelloWorld.Proxy
{
    public class MessageProxyFactory : IMessageProxyFactory
    {
        private readonly HttpClient _http;
        private readonly ILoggerFactory _loggerFactory;

        public MessageProxyFactory(HttpClient http, ILoggerFactory loggerFactory)
        {
            // Assign
            _http = http;
            _loggerFactory = loggerFactory;
        }

        // Proxy Factory Methods

        public IMessageProxy CreateMessageProxy()
        {
            var logger = _loggerFactory?.CreateLogger<MessageProxy>();
            return new MessageProxy(_http, logger);
        }
    }
}
