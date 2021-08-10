using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talto.Repository;
using Talto.Repository.Models;
using Talto.WebApi.ViewModels;

namespace Talto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : Controller
    {
        private readonly IBeverageRepository _repository;

        public BeveragesController(IBeverageRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var beverages = await _repository
                    .AsQueryable()
                    .Select(o => new BeverageDto
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Price = o.Price
                    })
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                return Ok(beverages);
            }
            catch
            {
                //retorna o erro 500 Internal Server Error
                return StatusCode(500);
            }

        }
    }
}
