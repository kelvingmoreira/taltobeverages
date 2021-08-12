using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talto.Repository.Models;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Sql
{
    /// <summary>
    /// Implementação dos métodos de interação básicos de <see cref="IOrderRepository"/> com o back-end de <see cref="Order"/>.
    /// </summary>
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly TaltoContext _db;

        public SqlOrderRepository(TaltoContext db) => _db = db;

        public IQueryable<Order> AsQueryable() => _db.Orders;

        public async Task<IEnumerable<Order>> GetAsync() =>
            await _db.Orders
            .Include(e => e.Entries)
            .ThenInclude(o => o.Beverage)
            .AsNoTracking()
            .ToListAsync();

        public async Task<Order> GetAsync(int id) =>
            await _db.Orders
            .Include(e => e.Entries)
            .ThenInclude(o => o.Beverage)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Order> InsertAsync(Order entity)
        {
            entity.SetTraceValues();

            double totalCashbackRefunded = 0;
            foreach(OrderEntry entry in entity.Entries)
            {
                entry.SetTraceValues();

                //Busca a cerveja de forma rastreada
                Beverage beverage = await _db.Beverages
                    .Include(e => e.Cashbacks)
                    .FirstOrDefaultAsync(e => e.Id == entry.BeverageId);

                entry.SalePrice = beverage.Price;
                entry.CashbackRefunded = beverage.Cashbacks.First(o => o.DayOfWeek == entity.DatePlaced.DayOfWeek).Value * entry.SalePrice * entry.Quantity;

                totalCashbackRefunded += entry.CashbackRefunded;
            }

            entity.TotalCashbackRefunded = totalCashbackRefunded;

            _db.Orders.Add(entity);

            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tracked = await _db.Orders.FindAsync(id);

            if (null != tracked)
            {
                _db.Orders.Remove(tracked);
                var result = await _db.SaveChangesAsync();

                return result > 0;
            }
            else return false;
        }
    }
}
