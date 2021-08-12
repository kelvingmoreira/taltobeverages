using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talto.Repository;
using Talto.Repository.Models;
using Talto.WebApi.Pagination;
using Talto.WebApi.ViewModels;

namespace Talto.WebApi.Controllers
{
    /// <summary>
    /// Controller com métodos de interação com as ordens de venda.
    /// </summary>
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

        /// <summary>
        /// Método GET que retorna as ordens de venda de forma paginada, filtrando opcionalmente por data e hora, em ordem decrescente.
        /// </summary>
        /// <param name="pageNumber">O número da página.</param>
        /// <param name="pageSize">O tamanho da página.</param>
        /// <param name="startDate">A data e hora de início a filtrar.</param>
        /// <param name="endDate">A data e hora de término a filtrar.</param>
        /// <returns>A lista de ordens paginada em orderm decrescente, filtrada por data.</returns>
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
            catch
            {
                //retorna o erro 500 Internal Server Error
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Método GET que retorna a ordem com o ID fornecido.
        /// </summary>
        /// <param name="id">O ID da ordem a buscar.</param>
        /// <returns>
        /// A ordem cujo ID é o fornecido. 
        /// Retorna <see langword="null"/> se nenhuma ordem for encontrada com o ID fornecido.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _repository.GetAsync(id);
                if (result == null)
                    return NotFound();

                var response = new OrderResponse(result.Id, result.DatePlaced,
                            result.Entries.Select(e => new OrderEntryResponse(e.BeverageId, e.Beverage.Name, e.Beverage.Price, e.Quantity, e.CashbackRefunded)), result.TotalCashbackRefunded);

                return Ok(response);
            }
            catch
            {
                //retorna o erro 500 Internal Server Error
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Método POST que cria uma nova ordem de venda com seus lançamentos no banco de dados.
        /// </summary>
        /// <param name="orderRequest">A ordem a criar.</param>
        /// <returns>A ordem criada.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderRequest orderRequest)
        {
            try
            {
                //Validação básica pra evitar ida ao banco de dados.
                if (orderRequest.Entries.Count == 0 || orderRequest.Entries.Any(o => o.BeverageId <= 0)) return BadRequest();

                Order newOrder = new()
                {
                    DatePlaced = orderRequest.DatePlaced,
                    Entries = orderRequest.Entries.GroupBy(g => g.BeverageId).Select(grp =>
                        new OrderEntry
                        {
                            BeverageId = grp.Key,
                            Quantity = grp.Sum(o => o.Quantity)
                        }).ToArray(),
                };

                var createdOrder = await _repository.InsertAsync(newOrder);

                var response = new OrderResponse(createdOrder.Id, createdOrder.DatePlaced,
                                createdOrder.Entries
                                .Select(e => new OrderEntryResponse(e.BeverageId, e.Beverage.Name, e.Beverage.Price, e.Quantity, e.CashbackRefunded)), createdOrder.TotalCashbackRefunded);

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
