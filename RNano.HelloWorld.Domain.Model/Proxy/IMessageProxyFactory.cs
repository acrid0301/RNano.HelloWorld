using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.Domain.Model.Proxy
{
    public interface IMessageProxyFactory
    {
        // Proxy Factory Methods
        IMessageProxy CreateMessageProxy();
    }
}
