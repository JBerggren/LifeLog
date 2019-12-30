using MongoDB.Driver;
using System;
using System.Collections.Generic;
using LifeLog.Api.Models;

namespace LifeLog.Api.Services
{
    public class MessageService
    {
        private MongoClient Client { get; set; }
        private IMongoDatabase Database { get; set; }
        private IMongoCollection<Message> MessageCollection { get; set; }
        private const string CollectionName = "Messages";

        public MessageService(IMongoDbSettings settings)
        {
            Client = new MongoClient(settings.ConnectionString);
            Database = Client.GetDatabase(settings.DatabaseName);
            MessageCollection = Database.GetCollection<Message>(CollectionName);
        }

        public void DeleteDatabase()
        {
            Client.DropDatabase(Database.DatabaseNamespace.DatabaseName);
        }

        public bool DeleteById(string id)
        {
            var result = MessageCollection.DeleteOne(x => x.Id == id);
            return result.DeletedCount == 1;
        }

        public IList<Message> FindByBody(string body)
        {
            return MessageCollection.Find(x => x.Body.Contains(body)).ToList();
        }

        public long GetNumberOfTodos()
        {
            return MessageCollection.CountDocuments(x => true);
        }

        internal List<Message> GetAll()
        {
            return MessageCollection.Find(x => true).ToList();
        }

        public Message GetById(string id)
        {
            return MessageCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Save(Message item)
        {
            MessageCollection.InsertOne(item);
        }
    }
}