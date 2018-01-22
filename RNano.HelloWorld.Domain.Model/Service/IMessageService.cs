using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.Domain.Model.Service
{
    public interface IMessageService
    {
        MessageModel GetMessage();
    }
}
