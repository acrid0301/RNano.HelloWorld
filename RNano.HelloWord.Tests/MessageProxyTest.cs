using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RNano.HelloWord.Tests.Handler;
using RNano.HelloWorld.Api.Controllers;
using RNano.HelloWorld.Domain;
using RNano.HelloWorld.Domain.Model;
using RNano.HelloWorld.Domain.Model.Proxy;
using RNano.HelloWorld.Domain.Model.Repository;
using RNano.HelloWorld.Domain.Model.Service;
using RNano.HelloWorld.Infrastructure.Sql.Orm;
using RNano.HelloWorld.Infrastructure.Sql.Repository;
using RNano.HelloWorld.Proxy;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RNano.HelloWord.Tests
{
    public class MessageProxyTestShould : IDisposable
    {
        private Mock<ILogger<MessageProxy>> logger;
        private Mock<IMessageProxy> msgProxy;

        public MessageProxyTestShould()
        {
            logger = new Mock<ILogger<MessageProxy>>();
            msgProxy = new Mock<IMessageProxy>();
        }

        [Fact]
        public async void ShowHelloWorldMessage()
        {
            // Arrange
            var fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri(string.Format("{0}Message/", HELLO_API)), await GetFakeHttpResponseMessage());

            var httpClient = new HttpClient(fakeResponseHandler) { BaseAddress = new Uri(HELLO_API) };
            var fakeMessage = GetNotifyMessage();
            msgProxy.Setup(x => x.GetMessage()).Returns(fakeMessage);

            MessageProxy proxy = new MessageProxy(httpClient, logger.Object);

            //Act
            var message = await proxy.GetMessage();

            //Assert
            Assert.NotNull(message);
            Assert.IsType<MessageModel>(message);
            Assert.Equal(HELLO_WORLD, message.Message);
        }

        public void Dispose()
        {
            logger = null;
            msgProxy = null;
        }

        // Non-Public

        private Task<MessageModel> GetNotifyMessage()
        {
            return Task.Run( ()=> new MessageModel() { Id = Guid.NewGuid(), Message = HELLO_WORLD } );
        }

        public async Task<HttpResponseMessage> GetFakeHttpResponseMessage()
        {
            var fakeMessage = await GetNotifyMessage();
            var json = JsonConvert.SerializeObject(fakeMessage);
            var jObject = JObject.Parse(json);

            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new StringContent(jObject.ToString(), Encoding.UTF8, APPJSON)
            };
            return response;
        }
        
        private const string APPJSON = "application/json";
        private const string HELLO_WORLD = "RNano Hello World";
        private const string HELLO_SERVICE = "http://rnano.helloworld/service";
        private const string HELLO_API = "http://rnano.helloworld/api/";
    }
}
