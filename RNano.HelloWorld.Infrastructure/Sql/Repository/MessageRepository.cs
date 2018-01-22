using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model;
using RNano.HelloWorld.Domain.Model.Repository;
using RNano.HelloWorld.Infrastructure.Sql.Orm;
using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.Infrastructure.Sql.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ILogger _logger;
        private readonly MessageContext _context;

        public MessageRepository(MessageContext context, ILogger<MessageRepository> logger)
        {
            // Assign
            _context = context;
            _logger = logger;
        }

        public MessageModel GetMessage()
        {
            return _context.Get();
        }
    }
}
