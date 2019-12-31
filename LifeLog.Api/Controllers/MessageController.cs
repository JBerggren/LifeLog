using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LifeLog.Api.Models;

namespace LifeLog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
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
   

    
}