using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    interface IModelsControll
    {
        public string ObjToJson();
        public void JsonToObj(string json);
    }
}
