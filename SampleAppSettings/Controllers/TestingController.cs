using Microsoft.AspNetCore.Mvc;
using SampleAppSettings.Services;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAppSettings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private IScopedService _scopedService1;
        private IScopedService _scopedService2;
        private ITransientService _transientService2;
        private ITransientService _transientService1;
        private ISingletonService _singletonService1;
        private ISingletonService _singletonService2;
        public TestingController(ISingletonService singletonService1, ISingletonService singletonService2,
            ITransientService transientService1, ITransientService transientService2,
            IScopedService scopedService1, IScopedService scopedService2
            )
        {
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }
        // GET: api/<TestingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            StringBuilder message = new StringBuilder();
            message.Append($"Transient 1:{ _transientService1.GetGuid() }\n");
            message.Append($"Transient 1:{ _transientService2.GetGuid() }\n");
            message.Append($"Scoped 1:{ _scopedService1.GetGuid() }\n");
            message.Append($"Scoped 2:{ _scopedService2.GetGuid() }\n");
            message.Append($"SingleTon1:{ _singletonService1.GetGuid() }\n");
            message.Append($"Singleton 2:{ _singletonService2.GetGuid() }\n");
            return Ok(message.ToString());
        }

        // POST api/<TestingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
