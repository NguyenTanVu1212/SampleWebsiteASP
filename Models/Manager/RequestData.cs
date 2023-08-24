using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    
    public class RequestData<T>
    {
        protected string url= "mongodb+srv://vu:17521274@mydatabase.n9xsq.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
        public List<T> GetData(string database , string collection , string a)
        {
            List<T> values = new List<T>();
            return values;
        }
        public virtual List<T> ConvertData()
        {
            List<T> datas = new List<T>();
            
            return datas;
        }

        String ToJson(string json)
        {
            List<string> values = new List<string>();
            values = json.Split(new string[] { "{", "}", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            values.RemoveAt(0);
            values.Insert(0, "{");
            values.Insert(values.Count, "}");
            string result = string.Empty;
            for (int i = 0; i <= values.Count - 1; i++)
            {
                result += values[i];
                if (values[i].Contains(":") == true && i != values.Count - 2)
                {
                    values.Insert(i + 1, ",");
                }
            }
            return result;
        }

        
    }
}
