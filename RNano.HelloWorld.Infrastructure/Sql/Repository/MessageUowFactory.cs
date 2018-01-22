using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model.Repository;
using RNano.HelloWorld.Infrastructure.Sql.Orm;
using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.Infrastructure.Sql.Repository
{
    public class MessageUowFactory : IMessageUowFactory
    {
        // Fields

        private readonly ILoggerFactory _loggerFactory;

        // Constructor

        public MessageUowFactory(ILoggerFactory loggerFactory)
        {
            // Assign
            _loggerFactory = loggerFactory;
        }

        // Public Methods

        public IMessageUnitOfWork Create()
        {
            return new MessageUnitOfWork(new MessageContext(), _loggerFactory); ;
        }
    }
}
