using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

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
            Messages.Insert(0,msg);
            return msg;
        }

        [HttpGet]
        [Route("today")]
        public GetResponse Get()
        {
            return new GetResponse(Messages.ToArray());
        }

        [HttpPost]
        [Route("query")]
        public QueryResponse Query(QueryRequest request)
        {
            var results = Messages.Where(x=>x.Body.Contains(request.Query));
            return new QueryResponse(results.ToArray());
        }
    }
    public class StoreRequest
    {
        public string Message { get; set; }
    }
    public class GetResponse
    {
        public GetResponse(Message[] messages){
            Messages = messages;
        }
        public Message[] Messages { get; set; }
    }

    public class QueryRequest
    {
        public string Query { get; set; }
    }
    public class QueryResponse
    {
        public QueryResponse(Message[] messages){
            Messages = messages;
        }
        public Message[] Messages { get; set; }
    }

    public class Message
    {
        public Message(string body)
        {
            Body = body;
            Created = DateTime.Now;
        }
        public string Id {get;set;}
        public string Body { get; set; }
        public DateTime Created {get;set;}
    }
}