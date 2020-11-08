using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookApp2.Repository;

namespace BookApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        //api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var data = await _repository.GetAll();
            return Ok(data);
        }

        //api/Books
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            var data = await _repository.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book model)
        {
            var result = await _repository.Add(model);
            return Ok(result == 1 ? 1 : 0);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Book model)
        {
            var result = await _repository.GetById(id);
            result.Price = model.Price;
            result.Title = model.Title;
            result.Author = model.Author;
            result.Genre = model.Genre;
            result.Publisher = model.Publisher;
            result.CatalogueId = model.CatalogueId;

            if (result != null)
            {
                try { await _repository.Update(result); }
                catch (Exception ex)
                {
                    return Ok(ex.Message);

                }

            }
            return Ok("Success");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var data = await _repository.GetById(id);
            await _repository.Delete(data);
            return Ok();
        }
    }
}