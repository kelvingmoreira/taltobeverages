using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _repository;

        /// <summary>
        /// Inicia uma nova instância de <see cref="OrdersController"/> com injeção de dependência.
        /// </summary>
        /// <param name="repository">A injeção de  de <see cref="IOrderRepository"/>.</param>
        public OrdersController(IOrderRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> Get(int? pageNumber, int? pageSize, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                if (startDate.HasValue && endDate.HasValue && endDate < startDate) return BadRequest();

                var pageFilter = new PaginationFilter(pageNumber.GetValueOrDefault(), pageSize.GetValueOrDefault());

                var results = await _repository
                    .AsQueryable()
                    .Include(o => o.Entries)
                    .ThenInclude(o => o.Beverage)
                    .OrderByDescending(x => x.DatePlaced)
                    .Where(o => o.DatePlaced >= (startDate.HasValue ? startDate : DateTime.MinValue) && o.DatePlaced <= (endDate.HasValue ? endDate : DateTime.MaxValue))
                    .Skip((pageFilter.PageNumber - 1) * pageFilter.PageSize)
                    .Take(pageFilter.PageSize)
                    //Garante que apenas os dados necessários serão coletados na consulta ao SQL
                    .Select(o => new { o.Id, o.DatePlaced, o.Entries, o.TotalCashbackRefunded })
                    .AsNoTracking()
                    .ToListAsync();

                var totalRecords = await _repository
                    .AsQueryable()
                    .Where(o => o.DatePlaced >= (startDate.HasValue ? startDate : DateTime.MinValue) && o.DatePlaced <= (endDate.HasValue ? endDate : DateTime.MaxValue))
                    .CountAsync();

                var orders = results
                    .Select(o => 
                        new OrderResponse(o.Id, o.DatePlaced, 
                            o.Entries.Select(e => new OrderEntryResponse(e.BeverageId, e.Beverage.Name, e.Beverage.Price, e.Quantity, e.CashbackRefunded)), o.TotalCashbackRefunded));


                return Ok(new PagedResponse<IEnumerable<OrderResponse>>(orders, pageFilter, totalRecords));
            }
            catch (Exception ex)
            {
                //retorna o erro 500 Internal Server Error
                return StatusCode(500);
            }

        }
    }
}
