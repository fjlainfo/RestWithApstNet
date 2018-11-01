using Microsoft.AspNetCore.Mvc;
using RestWithApstNet.Model;
using RestWithApstNet.Business;

namespace RestWithApstNet.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    //[ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personService)
        {
            _personBusiness = personService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            var updatePerson = _personBusiness.Update(person);
            if (updatePerson == null) return NoContent();
            return new ObjectResult(updatePerson);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
