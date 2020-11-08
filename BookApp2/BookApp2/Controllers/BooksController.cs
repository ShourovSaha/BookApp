using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookApp2.Repository;
using BookApp2.Models;

namespace BookApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IBookAppUnitOfWork _unitOfWork;

        public BooksController(IBookAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var data = await _unitOfWork.BookRepository.GetAll();
            return Ok(data);
        }

        //api/Books
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            var data = await _unitOfWork.BookRepository.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book model)
        {
            await _unitOfWork.BookRepository.Add(model);
            return Ok(await _unitOfWork.Save() == 1 ? 1 : 0);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Book model)
        {
            var result = await _unitOfWork.BookRepository.GetById(id);
            result.Price = model.Price;
            result.Title = model.Title;
            result.Author = model.Author;
            result.Genre = model.Genre;
            result.Publisher = model.Publisher;
            result.CatalogueId = model.CatalogueId;

            if (result != null)
            {
                try { _unitOfWork.BookRepository.Update(result); }
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
            var data = await _unitOfWork.BookRepository.GetById(id);
            _unitOfWork.BookRepository.Delete(data);
            var result = await _unitOfWork.Save();
            return Ok(result);
        }

        //api/Books
        [Route("PostBookInfo")]
        [HttpPost]
        public async Task<IActionResult> PostBookInfo([FromBody]BookInfoRequestModel requestModel)
        {
            var book = new Book
            {
                Title = requestModel.Title,
                Author = requestModel.Author,
                Publisher = requestModel.Publisher,
                Genre = requestModel.Genre,
                Price = requestModel.Price
            };

            var catalogue = new Catalogue
            {
                Name = requestModel.CatalogueName
            };

            await _unitOfWork.CatalogueRepository.Add(catalogue);
            await _unitOfWork.BookRepository.Add(book);
            var result = await _unitOfWork.Save();
            return Ok(result);
        }
    }
}