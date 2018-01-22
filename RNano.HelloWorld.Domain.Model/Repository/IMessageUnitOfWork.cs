using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.Domain.Model.Repository
{
    public interface IMessageUnitOfWork : IDisposable
    {
        IMessageRepository Message { get; set; }
    }
}
