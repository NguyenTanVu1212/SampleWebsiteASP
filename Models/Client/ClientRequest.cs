using FinalProject.Models.Manager;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.Client
{
    public class ClientRequest<T> : DatabaseController<T>
    {
        public static ClientRequest<T> instance = new ClientRequest<T>();
        string dataBaseName = "MyDb";
        string collectionName = typeof(T).Name.Split("Model")[0];

        public override IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return base.GetCollection(collectionName);
        }
        public List<T> GetDatasByKeyValue(string key , string value)
        {
            List<T> result = new List<T>();
            IMongoCollection<BsonDocument> collection = instance.GetCollection(dataBaseName , collectionName);
            List<string> datas = instance.GetvalueByKeyValue(collection,key, value);
            foreach(var e in datas)
            {
                result.Add(JsonToObject<T>(e));
            }
            return result;
        }
        public List<T> GetDatasByKeyValue(string key, int value)
        {
            List<T> result = new List<T>();
            IMongoCollection<BsonDocument> collection = instance.GetCollection(dataBaseName, collectionName);
            List<string> datas = instance.GetvalueByKeyValue(collection, key, value);
            foreach (var e in datas)
            {
                result.Add(JsonToObject<T>(e));
            }
            return result;
        }
        public List<T> GetDatasById(int id)
        {
            List<T> result = new List<T>();
            IMongoCollection<BsonDocument> collection = instance.GetCollection(dataBaseName, collectionName);
            List<string> datas = instance.GetValuesByID(collection,id);
            foreach (var e in datas)
            {
                result.Add(JsonToObject<T>(e));
            }
            return result;
        }

        public List<T> GetAllData()
        {
            List<T> result = new List<T>();
            IMongoCollection<BsonDocument> collection = instance.GetCollection(dataBaseName, collectionName);
            List<string> datas = instance.GetAllValues(collection);
            foreach (var e in datas)
            {
                result.Add(JsonToObject<T>(e));
            }
            return result;
        }
        public void ClientSendData(string data)
        {
            IMongoCollection<BsonDocument> collection = instance.GetCollection(dataBaseName, collectionName);
            instance.SendDataToSever(data , collection);
        }


    }
}
