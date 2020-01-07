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
        public static List<Event> Events = new List<Event>();

        [HttpPost]
        public MessageViewModel Store(StoreRequest request)
        {
            var msg = new Event(EventType.Log, request.Message);
            Events.Insert(0,msg);
            return new MessageViewModel(msg);
        }

        [HttpGet]
        [Route("today")]
        public GetResponse Get()
        {
            return new GetResponse(Events.ToArray());
        }

        [HttpPost]
        [Route("query")]
        public QueryResponse Query(QueryRequest request)
        {
            var results = Events.Where(x=>x.Body.Contains(request.Query));
            return new QueryResponse(results.ToArray());
        }
    }
   

    
}