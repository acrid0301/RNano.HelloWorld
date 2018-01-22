using Newtonsoft.Json;
using RNano.HelloWorld.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RNano.HelloWorld.Infrastructure.Sql.Orm
{
    /// <summary>
    /// Fake DB Context
    /// </summary>
    public class MessageContext : IDisposable
    {
        private MessageModel _helloWorldMessage;

        // Constructor
        public MessageContext()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var json = File.ReadAllText($"{dir}\\Sql\\Data\\Message.json");

            _helloWorldMessage = JsonConvert.DeserializeObject<MessageModel>(json);
        }

        public MessageModel Get()
        {
            return _helloWorldMessage;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
