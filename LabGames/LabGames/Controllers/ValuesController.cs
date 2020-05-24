using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LabGames.Core;
using Microsoft.AspNetCore.Mvc;
using LabGames.Core.Scene;
using Microsoft.AspNetCore.Http;
using LabGames.API.Interfaces;

namespace LabGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDataService dataService;
        public ValuesController(IDataService dataService)
        {
            this.dataService = dataService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get(string Id)
        {
            //string res = TimeManager.CurrentStep.Description;
            //TimeManager.NextPart();
            //return Ok(JsonConvert.SerializeObject(res));
            
            return "ok";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {  
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<bool> Post()
        {
            return true;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
