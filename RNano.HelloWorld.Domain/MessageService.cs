using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model;
using RNano.HelloWorld.Domain.Model.Repository;
using RNano.HelloWorld.Domain.Model.Service;
using System;

namespace RNano.HelloWorld.Domain
{
    public class MessageService : IMessageService
    {
        // Fields

        private readonly IMessageUowFactory _uFactory;
        private readonly ILogger _logger;

        // Constructor

        public MessageService(IMessageUowFactory uFactory, ILogger<MessageService> logger)
        {
            // Assign
            _uFactory = uFactory;
            _logger = logger;
        }

        // Public

        /// <summary>
        /// Get Hello World Message
        /// </summary>
        /// <returns></returns>
        public MessageModel GetMessage()
        {
            _logger?.LogInformation("GetMessage - Executed.");

            using (var u = _uFactory.Create())
            {
                _logger?.LogDebug("GetMessage - Retrieving Hello World Message...");

                var msg = u.Message.GetMessage();
                if (msg == null) return null;
                
                return msg;
            }
        }
    }
}
