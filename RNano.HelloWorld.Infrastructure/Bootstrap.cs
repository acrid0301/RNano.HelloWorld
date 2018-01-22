using Autofac;
using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model.Repository;
using RNano.HelloWorld.Infrastructure.Sql.Repository;

namespace RNano.HelloWorld.Infrastructure
{
    public static partial class Bootstrap
    {
        public static void ConfigureServer(this ContainerBuilder c)
        {
            c.Register(ctx => new MessageUowFactory(ctx.Resolve<ILoggerFactory>()))
                .As<IMessageUowFactory>()
                .SingleInstance();
        }
    }
}
