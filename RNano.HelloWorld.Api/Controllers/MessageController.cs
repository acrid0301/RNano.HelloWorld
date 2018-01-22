using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RNano.HelloWorld.Domain.Model;
using RNano.HelloWorld.Domain.Model.Service;

namespace RNano.HelloWorld.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private IMessageService _svc;
        private ILogger<MessageController> _logger;

        public MessageController(IMessageService svc, ILogger<MessageController> logger)
        {
            // Assign
            _svc = svc;
            _logger = logger;
        }

        [HttpGet]
        public MessageModel Get()
        {
            return _svc.GetMessage();
        }
    }
}