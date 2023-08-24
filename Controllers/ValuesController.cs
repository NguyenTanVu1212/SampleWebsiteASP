using FinalProject.Models;
using FinalProject.Models.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            List<LogModel> user = ClientRequest<LogModel>.instance.GetAllData();
            string results = string.Empty;
            foreach (var e in user)
            {
                results += e.ObjToJson() + "\n";
            }
            return results;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] LogModel datas )
        {
            Random rand = new Random();
            LogModel model = new LogModel();
            List<StaffModel> staff = ClientRequest<StaffModel>.instance.GetDatasById(datas.ID);
            string values = string.Empty;
            foreach(var e in staff)
            {
                model.ID = datas.ID;
                model.Temperature = float.Parse(rand.NextDouble().ToString())% 0.5f  + 36.5f;
                if (model.ID != 1) model.Temperature = 26f;
                model.Name = e.Name;
                DateTime myTime = DateTime.Now;
                model.TimeEnter = myTime.ToString(); ;
                ClientRequest<LogModel>.instance.ClientSendData(model.ObjToJson());
                values += e.ObjToJson();
            }
            return values ;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
