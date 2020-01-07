using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LifeLog.Api.Models;

namespace LifeLog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        [HttpPost]
        public void Store(StoreEventRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("query")]
        public QueryEventResponse Query(QueryEventRequest request)
        {
            throw new NotImplementedException();
        }
    }
   

    
}