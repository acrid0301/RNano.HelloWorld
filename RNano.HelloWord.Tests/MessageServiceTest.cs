using Microsoft.Extensions.Logging;
using Moq;
using RNano.HelloWorld.Domain;
using RNano.HelloWorld.Domain.Model;
using RNano.HelloWorld.Domain.Model.Repository;
using RNano.HelloWorld.Infrastructure.Sql.Orm;
using RNano.HelloWorld.Infrastructure.Sql.Repository;
using System;
using Xunit;

namespace RNano.HelloWord.Tests
{
    public class MessageServiceTestShould : IDisposable
    {
        private Mock<ILogger<MessageService>> logger;
        private Mock<IMessageUowFactory> msgUowFactory;
        private Mock<IMessageRepository> msgRepository;

        public MessageServiceTestShould()
        {
            logger = new Mock<ILogger<MessageService>>();
            msgUowFactory = new Mock<IMessageUowFactory>();
            msgRepository = new Mock<IMessageRepository>();
        }

        [Fact]
        public void ShowHelloWorldMessage()
        {
            // Arrange
            var fakeMessageUowFactory = GetMessageUowFactory();
            msgUowFactory.Setup(x => x.Create()).Returns(fakeMessageUowFactory);

            MessageService service = new MessageService(msgUowFactory.Object, logger.Object);

            //Act
            var message = service.GetMessage();

            //Assert
            Assert.NotNull(message);
            Assert.IsType<MessageModel>(message);
            Assert.Equal(HELLO_WORLD, message.Message);
        }

        public void Dispose()
        {
            logger = null;
            msgUowFactory = null;
            msgRepository = null;
        }

        // Non-Public

        private MessageModel GetNotifyMessage()
        {
            return new MessageModel() { Id = Guid.NewGuid(), Message = HELLO_WORLD };
        }

        private IMessageUnitOfWork GetMessageUowFactory()
        {
            var msgUow = new MessageUnitOfWork(new MessageContext(), new LoggerFactory());

            // Arrange
            var fakeMessage = GetNotifyMessage();
            msgRepository.Setup(x => x.GetMessage()).Returns(fakeMessage);
            msgUow.Message = msgRepository.Object;

            return msgUow;
        }

        private const string HELLO_WORLD = "RNano Hello World";
    }
}
