using RNano.HelloWorld.Domain.Model.Proxy;
using RNano.HelloWorld.Domain.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.ConsoleApp
{
    public class ConsoleTest : ConsoleApp
    {
        private readonly IMessageUowFactory _uFactory;
        private readonly IMessageProxyFactory _pFactory;

        public ConsoleTest(IMessageUowFactory uFactory, IMessageProxyFactory pFactory)
        {
            // Assign
            _uFactory = uFactory;
            _pFactory = pFactory;
        }
        protected async override void Execute()
        {
            Console.WriteLine("======= Get Hello Message using Uow Factory =======");
            using (var svc = _uFactory.Create())
            {
                var model = svc.Message.GetMessage();
                if (model != null)
                    Console.WriteLine(model.Message);
            };

            Console.WriteLine("======= Get Hello Message using Proxy Factory =======");
            using (var proxy = _pFactory.CreateMessageProxy())
            {
                var model = await proxy.GetMessage();
                if (model != null)
                    Console.WriteLine(model.Message);
            };
        }
    }
}
