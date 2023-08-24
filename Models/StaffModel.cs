using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class StaffModel : IModelsControll
    {
        public static StaffModel instance;

        private int id;
        public int Id {
            get { return id; }
            set { id = value; }
        } 
        private string name;
        public string Name {
            get { return name; }
            set { name = value.ToUpper(); }
        } 
        private string role;
        public string Role {
            get { return role; }
            set { role = value; }
        } 
        private string avatar;
        public string Avarta {
            get { return avatar; }
            set { avatar = value; }
        }

        public StaffModel()
        {
            this.Id = 0;
            this.Name = "null";
            this.Role = "null";
            this.Avarta = "null";
        }

        public StaffModel(int _id , string _name , string _role , string _avarta)
        {
            this.Id = _id;
            this.Name = _name;
            this.Role = _role;
            this.Avarta = _avarta;
        }
        public string ObjToJson()
        {
            string value = string.Empty;
            value += "{\"Id\":";
            value += Id;
            value += ",\"Name\":\"";
            value += Name.ToString();
            value += "\",\"Role\":\"";
            value += Role.ToString();
            value += "\",\"Avarta\":\"";
            value += Avarta.ToString();
            value += "\"}";
            return value;
        }

        public void JsonToObj(string json)
        {
            instance = null;
        }
        public string  Base64Decode()
        {
            if(this.Avarta == "null")
            {
                return string.Empty;
            }else
            {
                var base64DecodeBytes = System.Convert.FromBase64String(this.avatar);
                return System.Text.Encoding.UTF8.GetString(base64DecodeBytes);
            }
           
        }
    }
}
