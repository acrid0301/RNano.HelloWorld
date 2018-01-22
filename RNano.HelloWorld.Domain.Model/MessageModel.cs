using System;

namespace RNano.HelloWorld.Domain.Model
{
    public class MessageModel : DomainEntity
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
