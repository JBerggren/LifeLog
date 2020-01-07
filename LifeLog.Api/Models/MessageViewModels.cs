using System;
using System.Linq;

namespace LifeLog.Api.Models
{
    public class StoreRequest
    {
        public string Message { get; set; }
    }

    public class GetResponse
    {
        public GetResponse(Event[] events)
        {
            Messages = events.Select(x => new MessageViewModel(x)).ToArray();
        }
        public MessageViewModel[] Messages { get; set; }
    }

    public class QueryRequest
    {
        public string Query { get; set; }
    }

    public class QueryResponse
    {
        public QueryResponse(Event[] events)
        {
            Messages = events.Select(x => new MessageViewModel(x)).ToArray();
        }
        public MessageViewModel[] Messages { get; set; }
    }

    public class MessageViewModel
    {
        public MessageViewModel(Event ev)
        {
            Id = ev.Id;
            Body = ev.Body;
            Created = ev.Created;
        }
        public string Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
    }
}