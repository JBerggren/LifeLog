using System;
using MongoDB.Bson.Serialization.Attributes;

namespace LifeLog.Api.Models
{
    public class Event
    {
        public Event(EventType type, string body)
        {
            Type = type;
            Body = body;
            Created = DateTime.Now;
        }
        
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id {get;set;}
        public string Body { get; set; }
        public EventType Type { get; set; }
        public DateTime Created {get;set;}
    }
    
    public enum EventType{
        Log,
        PhoneCall,
        SMS,
        Location
    }
}