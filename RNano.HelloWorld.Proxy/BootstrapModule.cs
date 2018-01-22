using Autofac;
using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model.Config;
using RNano.HelloWorld.Domain.Model.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RNano.HelloWorld.Proxy
{
    public class BootstrapModule : Module
    {
        private readonly ClientConfigOptions _options;

        public BootstrapModule(ClientConfigOptions options)
        {
            _options = options;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx =>
            {
                var handler = ctx.Resolve<HttpMessageHandler>();
                var client = new HttpClient(handler) { BaseAddress = new Uri(_options.ServiceBaseUri) };
                var loggerFactory = ctx.Resolve<ILoggerFactory>();
                return new MessageProxyFactory(client, loggerFactory);
            })
            .As<IMessageProxyFactory>()
            .SingleInstance();

            builder.ConfigureClient();

            base.Load(builder);
        }
    }
}
