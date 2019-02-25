using Microsoft.AspNetCore.Mvc;
using RestWithApstNet.Model;
using RestWithApstNet.Business;
using RestWithApstNet.Data.VO;
using System.Collections.Generic;
using System;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Tapioca.HATEOAS;

namespace RestWithApstNet.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    //[ApiController]
    public class BooksController : ControllerBase
    {
        private IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookService)
        {
            _bookBusiness = bookService;
        }

        // GET api/values
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<BookVO>))]
        [SwaggerResponse(200)]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
           return Ok(_bookBusiness.FindAll());
           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(BookVO))]
        [SwaggerResponse(200)]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(BookVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
            
        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(BookVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            var updateBook = _bookBusiness.Update(book);
            if (updateBook == null) return NoContent();
            return new ObjectResult(updateBook);
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
            
        }
    }
}
