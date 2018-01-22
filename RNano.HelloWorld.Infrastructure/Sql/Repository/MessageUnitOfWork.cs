using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model.Repository;
using RNano.HelloWorld.Infrastructure.Sql.Orm;
using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.Infrastructure.Sql.Repository
{
    public class MessageUnitOfWork : IMessageUnitOfWork
    {
        // Fields

        private bool _disposed;
        private readonly ILoggerFactory _loggerFactory;
        private readonly MessageContext _context;
        private IMessageRepository _messageRepository;

        // Properties

        public IMessageRepository Message
        {
            get
            {
                return _messageRepository;
            }
            set
            {
                _messageRepository = value;
            }
        }

        // Constructor

        public MessageUnitOfWork(MessageContext context, ILoggerFactory loggerFactory)
        {
            // Assign
            _context = context;
            _loggerFactory = loggerFactory;

            GetMessageRepository();
        }

        // Public

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposed)
        {
            if (disposed && !_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }

        // Non-Public

        private void GetMessageRepository()
        {
            var logger = _loggerFactory?.CreateLogger<MessageRepository>();
            _messageRepository = new MessageRepository(_context, logger);
        }
    }
}
