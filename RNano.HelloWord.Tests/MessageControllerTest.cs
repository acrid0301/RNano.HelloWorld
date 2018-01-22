using Microsoft.Extensions.Logging;
using Moq;
using RNano.HelloWorld.Api.Controllers;
using RNano.HelloWorld.Domain;
using RNano.HelloWorld.Domain.Model;
using RNano.HelloWorld.Domain.Model.Repository;
using RNano.HelloWorld.Domain.Model.Service;
using RNano.HelloWorld.Infrastructure.Sql.Orm;
using RNano.HelloWorld.Infrastructure.Sql.Repository;
using System;
using Xunit;

namespace RNano.HelloWord.Tests
{
    public class MessageControllerTestShould : IDisposable
    {
        private Mock<ILogger<MessageController>> logger;
        private Mock<IMessageService> msgService;

        public MessageControllerTestShould()
        {
            logger = new Mock<ILogger<MessageController>>();
            msgService = new Mock<IMessageService>();
        }

        [Fact]
        public void ShowHelloWorldMessage()
        {
            // Arrange
            var fakeMessage = GetNotifyMessage();
            msgService.Setup(x => x.GetMessage()).Returns(fakeMessage);

            MessageController controller = new MessageController(msgService.Object, logger.Object);

            //Act
            var message = controller.Get();

            //Assert
            Assert.NotNull(message);
            Assert.IsType<MessageModel>(message);
            Assert.Equal(HELLO_WORLD, message.Message);
        }

        public void Dispose()
        {
            logger = null;
            msgService = null;
        }

        // Non-Public

        private MessageModel GetNotifyMessage()
        {
            return new MessageModel() { Id = Guid.NewGuid(), Message = HELLO_WORLD };
        }
        
        private const string HELLO_WORLD = "RNano Hello World";
    }
}
