using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.Domain
{
    public static partial class Bootstrap
    {
        public static void ConfigureDomain(this ContainerBuilder c)
        {
            // Services
            c.RegisterType<MessageService>().AsImplementedInterfaces();
        }
    }
}
