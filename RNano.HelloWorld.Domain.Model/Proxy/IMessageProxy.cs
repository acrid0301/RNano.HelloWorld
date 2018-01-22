using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RNano.HelloWorld.Domain.Model.Proxy
{
    public interface IMessageProxy: IDisposable
    {
        Task<MessageModel> GetMessage();
    }
}
