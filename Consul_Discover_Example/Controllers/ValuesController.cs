using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.Common.Discovery;
using System.Net.Http;

namespace Consul_Discover_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;
        DiscoveryHttpClientHandler _handler;
        public ValuesController(ILogger<ValuesController> logger, IDiscoveryClient client)
        {
            _logger = logger;
            _handler = new DiscoveryHttpClientHandler(client);
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var client = new HttpClient(_handler, false);
            string response = "Client invoked service and got result: " + await client.GetStringAsync("http://Consul-Register-Example/api/values");
            _logger.LogDebug(response);
            
            return response;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
}
