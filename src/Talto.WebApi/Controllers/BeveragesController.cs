using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talto.Repository;
using Talto.WebApi.Pagination;
using Talto.WebApi.ViewModels;

namespace Talto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : Controller
    {
        private readonly IBeverageRepository _repository;

        /// <summary>
        /// Inicia uma nova instância de <see cref="BeveragesController"/> com injeção de dependência.
        /// </summary>
        /// <param name="repository">A injeção de <see cref="IBeverageRepository"/>.</param>
        public BeveragesController(IBeverageRepository repository) => _repository = repository;

        /// <summary>
        /// Método GET que retorna as cervejas de forma paginada.
        /// </summary>
        /// <param name="pageNumber">O número da página.</param>
        /// <param name="pageSize">O tamanho da página.</param>
        /// <returns>A lista de cervejas paginada.</returns>
        [HttpGet]
        public async Task<IActionResult> Get( int? pageNumber, int? pageSize)
        {
            try
            {
                var pageFilter = new PaginationFilter(pageNumber.GetValueOrDefault(), pageSize.GetValueOrDefault());

                var results = await _repository
                    .AsQueryable()
                    .Include(o => o.Cashbacks)
                    .OrderBy(x => x.Name)
                    .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                    .Take(pageFilter.PageSize)
                    //Garante que apenas os dados necessários serão coletados na consulta ao SQL
                    .Select(o => new { o.Id, o.Name, o.Price, o.Cashbacks })
                    .AsNoTracking()
                    .ToListAsync();

                var totalRecords = await _repository.AsQueryable().CountAsync();

                //TO DO: Revisar a maneira como o Price é injetado no JSON (deveria ser um cálculo).
                var beverages = results
                    .Select(o => new BeverageResponse(o.Id, o.Name, o.Price, o.Cashbacks.Select(c => new CashbackResponse(c.Beverage.Name, c.DayOfWeek, c.Value))));


                return Ok(new PagedResponse<IEnumerable<BeverageResponse>>(beverages, pageFilter, totalRecords));
            }
            catch
            {
                //retorna o erro 500 Internal Server Error
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Método GET que retorna a cerveja com o ID fornecido.
        /// </summary>
        /// <param name="id">O ID da cerveja a buscar.</param>
        /// <returns>
        /// A cerveja cujo ID é o fornecido. 
        /// Retorna <see langword="null"/> se nenhuma cerveja for encontrada com o ID fornecido.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _repository.GetAsync(id);
                if (result == null)
                    return NotFound();

                var response = new BeverageResponse(result.Id, result.Name, result.Price, result.Cashbacks.Select(c => new CashbackResponse(c.Beverage.Name, c.DayOfWeek, c.Value)));

                return Ok(response);
            }
            catch
            {
                //retorna o erro 500 Internal Server Error
                return StatusCode(500);
            }
        }
    }
}
