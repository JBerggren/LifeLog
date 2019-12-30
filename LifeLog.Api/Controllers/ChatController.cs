using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LifeLog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        public static List<Message> Messages = new List<Message>();

        [HttpPost]
        public Message Store(StoreRequest request)
        {
            var msg = new Message(request.Message);
            Messages.Add(msg);
            return msg;
        }

        [HttpGet]
        public GetResponse Get()
        {
            return new GetResponse() { Messages = Messages.ToArray() };
        }
    }
    public class StoreRequest
    {
        public string Message { get; set; }
    }
    public class GetResponse
    {
        public Message[] Messages { get; set; }
    }

    public class Message
    {
        public Message(string body)
        {
            Body = body;
        }
        public string Body { get; set; }
    }
}