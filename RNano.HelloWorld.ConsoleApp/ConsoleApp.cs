using System;
using System.Collections.Generic;
using System.Text;

namespace RNano.HelloWorld.ConsoleApp
{
    public abstract class ConsoleApp
    {
        public void Run(string[] args)
        {
            //TODO: Initialize arguments if available.

            try
            {
                Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }

        protected abstract void Execute();
    }

}
