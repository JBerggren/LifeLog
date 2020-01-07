namespace LifeLog.Api.Models
{
    public class StoreEventRequest
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
    public class GetEventResponse
    {
        public GetEventResponse(Event[] events)
        {
            Events = events;
        }
        public Event[] Events { get; set; }
    }

    public class QueryEventRequest
    {
        public string Query { get; set; }
    }

    public class QueryEventResponse
    {
        public QueryEventResponse(Event[] events)
        {
            Events = events;
        }
        public Event[] Events { get; set; }
    }
}