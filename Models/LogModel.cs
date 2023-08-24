using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class LogModel : IModelsControll
    {
        public static LogModel instance;

        private int id;
        public int ID { get => id; set => id = value; }

        private string name;
        public string Name { get => name; set => name = value.ToUpper(); }

        private float temperature;
        public float Temperature { get => temperature; set => temperature = value; }

        private string timeEnter;
        public string TimeEnter { get => timeEnter; set => timeEnter = value; }

        public LogModel(int _id , string _name , int _temp , string _timeEnter)
        {
            this.ID = _id;
            this.Name = _name;
            this.Temperature = temperature;
            this.TimeEnter = _timeEnter;
        }
        public LogModel()
        {
            this.ID = 0;
            this.Name = "null";
            this.Temperature = 0;
            this.TimeEnter = "null";
        }

        public string ObjToJson()
        {
            string value = string.Empty;
            value += "{\"Id\":";
            value += ID;
            value += ",\"Name\":\"";
            value += Name.ToString();
            value += "\",\"Temperature\":";
            value += Temperature;
            value += ",\"TimeEnter\":\"";
            value += TimeEnter.ToString();
            value += "\"}";
            return value;
        }

        public void JsonToObj(string json)
        {
            instance = null;
        }
    }

}
