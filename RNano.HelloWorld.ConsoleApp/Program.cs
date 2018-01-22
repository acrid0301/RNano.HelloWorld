using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace RNano.HelloWorld.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var s = new ServiceCollection();
                var c = Bootstrap.Configure();
                var ca = c.Resolve<ConsoleTest>();
                ca.Run(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
    }
}
