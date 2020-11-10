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
            var catalogueId = Guid.NewGuid();

            var catalogue = new Catalogue
            {
                CatalogueId = catalogueId,
                Name = requestModel.CatalogueName
            };

            await _unitOfWork.CatalogueRepository.Add(catalogue);

            foreach  (var i in requestModel.BooksInfo)
            {
                var book = new Book
                {
                    Title = i.Title,
                    Author = i.Author,
                    Publisher = i.Publisher,
                    Genre = i.Genre,
                    Price = i.Price,
                    CatalogueId = catalogueId
                };

                await _unitOfWork.BookRepository.Add(book);
            }
            
            var result = await _unitOfWork.Save();
            return Ok(result);
        }

        [Route("BookCount")]
        public async Task<IActionResult> BookCount()
        {
            var numberOfBooks = await _unitOfWork.BookRepository.Count(c => c.Price > 220);
            return  Ok(numberOfBooks);
        }

        [Route("GetBooksForPagination")]
        [HttpGet]
        public async Task<IActionResult> GetBooks(int numberOfRowsToShow, int pageIndex)
        {
            var data = await _unitOfWork.BookRepository.GetDataDinamicaly(numberOfRowsToShow, pageIndex);
            return Ok(data);
        }
    }
}