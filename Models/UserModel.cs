using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class UserModel : IModelsControll
    {
        public static UserModel instance;
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string role;
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public UserModel()
        {
            this.Id = 0;
            this.UserName = "null";
            this.Password = "null";
            this.Role = "null";
        }
        public UserModel(int _id , string _userName , string _password , string  _role)
        {
            this.Id = _id;
            this.UserName = _userName;
            this.Password = _password;
            this.Role = _role;
            
        }
        public string ObjToJson()
        {
            string value = string.Empty;
            value += "{\"Id\":";
            value += Id;
            value += ",\"UserName\":\"";
            value += UserName.ToString();
            value += "\",\"Password\":\"";
            value += Password.ToString();
            value += "\",\"Role\":\"";
            value += Role.ToString();
            value += "\"}";
            return value;
        }

        public void JsonToObj(string json)
        {
            instance = null;
        }
    }
}
