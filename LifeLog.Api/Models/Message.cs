using System;
using MongoDB.Bson.Serialization.Attributes;

namespace LifeLog.Api.Models
{
    public class Message
    {
        public Message(string body)
        {
            Body = body;
            Created = DateTime.Now;
        }
        
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id {get;set;}
        public string Body { get; set; }
        public DateTime Created {get;set;}
    }
    
}