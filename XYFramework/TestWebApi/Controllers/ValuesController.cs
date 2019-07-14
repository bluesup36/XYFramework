using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XYFramework.Authcode;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("Kenco/{id}")]
        public ActionResult<string> Get(string id)
        {
            Result result = new Result
            {
                State = id.Substring(0,1),
                Msg = URLb64.Url_b64decode(id.Substring(1,id.Length-1), "VincentDong")
            };
            return new JsonResult(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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

    public class Result
    {
        public string State { get; set; }
        public string Msg { get; set; }
    }
}
