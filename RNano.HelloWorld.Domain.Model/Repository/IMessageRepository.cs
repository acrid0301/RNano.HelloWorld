using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.Domain.Model.Repository
{
    public interface IMessageRepository
    {
        MessageModel GetMessage();
    }
}
