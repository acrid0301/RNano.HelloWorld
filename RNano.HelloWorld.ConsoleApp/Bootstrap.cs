using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RNano.HelloWorld.ConsoleApp.Handler;
using RNano.HelloWorld.Domain.Model.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RNano.HelloWorld.ConsoleApp
{
    public static class Bootstrap
    {
        public static IContainer Configure()
        {
            // Init
            var sc = new ServiceCollection();
            var cb = new ContainerBuilder();

            // Config
            var builder = new ConfigurationBuilder()
                 .AddJsonFile("config\\appsettings.json", optional: false, reloadOnChange: true)
            ;
            var root = builder.Build();

            // Init Config
            var cfgClientOpts = root.Get<ClientConfigOptions>();

            // Framework Services
            sc.AddLogging();

            // Connect Autofac
            cb.Populate(sc);

            // Autofac Module Registration
         
            cb.RegisterModule(new Proxy.BootstrapModule(cfgClientOpts));
            cb.RegisterModule(new Infrastructure.BootstrapModule());

            // Host
            cb.RegisterInstance<HttpMessageHandler>(new ProxyDelegatingHandler());
            cb.RegisterType<ConsoleTest>();

            // Build
            var result = cb.Build();

            return result;
        }
    }
}
