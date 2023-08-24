using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace FinalProject.Models.Manager
{
    public abstract class DatabaseController<T>
    {
        public delegate void RequestHandle(object data);
        public RequestHandle EventRequestHandler;
        public virtual string SendQuery()
        {
            string datas = string.Empty;
            return datas;
        }
        public virtual IMongoCollection<BsonDocument> GetCollection(string url  , string dataBaseName , string collectionName)
        {
            var settings = MongoClientSettings.FromConnectionString(url);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(dataBaseName);
            IMongoCollection<BsonDocument> collections = database.GetCollection<BsonDocument>(collectionName);
            return collections;
        }
        public virtual IMongoCollection<BsonDocument> GetCollection(string dataBaseName, string collectionName)
        {
            string url = "mongodb+srv://vu:17521274@mydatabase.n9xsq.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
            var settings = MongoClientSettings.FromConnectionString(url);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(dataBaseName);           
            IMongoCollection<BsonDocument> collections = database.GetCollection<BsonDocument>(collectionName);
            return collections;
        }
        public virtual IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            string url = "mongodb+srv://vu:17521274@mydatabase.n9xsq.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
            string dataBaseName = "MyDb";
            var settings = MongoClientSettings.FromConnectionString(url);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(dataBaseName);
            IMongoCollection<BsonDocument> collections = database.GetCollection<BsonDocument>(collectionName);
            return collections;
        }
        public virtual List<string> GetValuesByID(IMongoCollection<BsonDocument> collections , int id)
        {
            List<string> myDatas = new List<string>();
            var filter = Builders<BsonDocument>.Filter.Eq("Id" , id);
            var results = collections.Find(filter).ToList();
            foreach(BsonDocument e in results)
            {
                myDatas.Add(BsonTojson(e.ToJson()));
            }
            return myDatas;
        }
        public virtual List<string> GetvalueByKeyValue(IMongoCollection<BsonDocument> collections, string key , string value)
        {
            List<string> myDatas = new List<string>();
            var filter = Builders<BsonDocument>.Filter.Eq(key, value);
            var results = collections.Find(filter).ToList();
            foreach (BsonDocument e in results)
            {
                myDatas.Add(BsonTojson(e.ToJson()));
            }
            return myDatas;
        }
        public virtual List<string> GetvalueByKeyValue(IMongoCollection<BsonDocument> collections, string key, int value)
        {
            List<string> myDatas = new List<string>();
            var filter = Builders<BsonDocument>.Filter.Eq(key, value);
            var results = collections.Find(filter).ToList();
            foreach (BsonDocument e in results)
            {
                myDatas.Add(BsonTojson(e.ToJson()));
            }
            return myDatas;
        }
        public virtual List<string> GetAllValues(IMongoCollection<BsonDocument> collections)
        {
            List<string> myDatas = new List<string>();
            var results = collections.Find(new BsonDocument()).ToList();
            foreach (BsonDocument e in results)
            {
                myDatas.Add(BsonTojson(e.ToJson()));
            }
            return myDatas;
        }

        public void SendDataToSever(string  data , IMongoCollection<BsonDocument> collection)
        {
            BsonDocument bsonString = BsonDocument.Parse(data);
            collection.InsertOne(bsonString);
        }

        public static T JsonToObject<T>(string json)
        {
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
        public string BsonTojson(string bson)
        {
            string jsonResult = string.Empty ;
            List<string> values = new List<string>();
            values = bson.Split(new string[] { "{", "}", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            values.RemoveAt(0);
            values.Insert(0, "{");
            values.Insert(values.Count, "}");
            for (int i = 0; i <= values.Count - 1; i++)
            {
                jsonResult += values[i];
                if (values[i].Contains(":") == true && i != values.Count - 2)
                {
                    values.Insert(i + 1, ",");
                }
            }
            return jsonResult;
        }
    }
}
