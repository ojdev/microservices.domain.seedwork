using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YYY.Microservices.Domain.SeedWork;

namespace WebApplication1.Controllers
{
    public class VId
    {
        public string Id { set; get; }
    }
    [Route("api")]
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
        [HttpGet("{id}/{body}")]
        public ActionResult<string> Get(int id, string body)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("{id}/del/{key}")]
        public string Post(int id, string key, [FromBody] VId value)
        {
            return $"{id},{value.Id}";
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
