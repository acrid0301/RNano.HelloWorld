using Autofac;
using RNano.HelloWorld.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.Infrastructure
{
    public class BootstrapModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.ConfigureDomain();
            builder.ConfigureServer();

            base.Load(builder);
        }
    }
}
