namespace LifeLog.Api.Models
{
    public class StoreRequest
    {
        public string Message { get; set; }
    }
    public class GetResponse
    {
        public GetResponse(Message[] messages)
        {
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
        public QueryResponse(Message[] messages)
        {
            Messages = messages;
        }
        public Message[] Messages { get; set; }
    }
}