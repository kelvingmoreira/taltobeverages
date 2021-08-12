using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talto.Repository.Models;
using Talto.Repository.Models.Helpers;

namespace Talto.Repository.Sql
{
    /// <summary>
    /// Implementação dos métodos de interação básicos de <see cref="IBeverageRepository"/>  com o back-end de <see cref="Beverage"/>.
    /// </summary>
    public class SqlBeverageRepository : IBeverageRepository 
    {
        private readonly TaltoContext _db;

        /// <summary>
        /// Cria uma nova instância de <see cref="SqlBeverageRepository"/>
        /// </summary>
        /// <param name="db">O contexto do banco de dados.</param>
        public SqlBeverageRepository(TaltoContext db) => _db = db;

        public IQueryable<Beverage> AsQueryable() => _db.Beverages;

        public async Task<IEnumerable<Beverage>> GetAsync() =>
            await _db.Beverages
            .Include(e => e.Cashbacks)
            .AsNoTracking()
            .ToListAsync();

        public async Task<Beverage> GetAsync(int id) =>
            await _db.Beverages
            .Include(e => e.Cashbacks)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Beverage> InsertAsync(Beverage entity)
        {
            entity.SetTraceValues();

            foreach (Cashback cashback in entity.Cashbacks) 
                cashback.SetTraceValues();

            _db.Entry(entity).State = EntityState.Added;

            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Beverage> UpdateAsync(Beverage entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tracked = await _db.Beverages.FindAsync(id);

            if (null != tracked)
            {
                _db.Beverages.Remove(tracked);
                var result = await _db.SaveChangesAsync();

                return result > 0;
            }
            else return false;
        }
    }
}
