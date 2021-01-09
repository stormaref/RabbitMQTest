using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly ILogger<PublisherController> _logger;
        private readonly IBus _bus;

        public PublisherController(ILogger<PublisherController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Publish()
        {
            var message = new Message { Text = "Kose amme mamad" };
            Uri uri = new Uri("rabbitmq://localhost/testQueue");
            var client = _bus.CreateRequestClient<Message>(uri);
            await client.GetResponse<Message>(message);
            return Ok();
        }
    }
}
