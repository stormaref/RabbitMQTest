using MassTransit;
using MassTransit.Definition;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTwo
{
    public class MessageConsumer : IConsumer<Message> 
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            var data = context.Message;
            data.Succeed = true;
            //if (new Random().Next(10) % 2 == 0)
                throw new Exception("test");
            await context.RespondAsync(data);
        }
    }
}
