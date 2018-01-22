using Autofac;
using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RNano.HelloWorld.Proxy
{
    public static class Bootstrap
    {
        public static void ConfigureClient(this ContainerBuilder c)
        {
            // Proxies
            c.RegisterType<MessageProxy>().AsImplementedInterfaces();
        }
    }
}
