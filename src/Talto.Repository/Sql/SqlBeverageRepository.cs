using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talto.Repository.Models;

namespace Talto.Repository.Sql
{
    public class SqlBeverageRepository : IBeverageRepository 
    {
        private readonly TaltoContext _db;

        public SqlBeverageRepository(TaltoContext db) => _db = db;

        public IQueryable<Beverage> AsQueryable() => _db.Beverages;

        public async Task<IEnumerable<Beverage>> GetAsync() =>
            await _db.Beverages
            .AsNoTracking()
            .ToListAsync();

        public async Task<Beverage> GetAsync(int id) =>
            await _db.Beverages
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<Beverage> InsertAsync(Beverage entity)
        {
            _db.Entry(entity).State = EntityState.Added;

            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Beverage> UpdateAsync(Beverage entity)
        {
            var tracked = await _db.Beverages
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            _db.Entry(tracked).CurrentValues.SetValues(entity);

            await _db.SaveChangesAsync();

            return entity;
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
