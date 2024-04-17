using AutoMapper;
using HomeService.Application.Repository;
using HomeService.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HomeService.Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HomeServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenericRepository(HomeServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Create(T entity)
        {
            var result = await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(T Id)
        {
            _dbContext.Set<T>().Remove(Id);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll(FormattableString query)
        {
            var response = await _dbContext.Set<T>().FromSqlInterpolated(query).ToListAsync();
            return response;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string sqlCommand)
        {
            return await _dbContext.Set<T>().FromSqlRaw(sqlCommand).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            var result = await _dbContext.FindAsync<T>(id);
            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Detached;
            }
            return result;
        }

        public async Task<T> GetById(FormattableString query)
        {
            var response =  await _dbContext.Set<T>().FromSqlInterpolated(query).FirstOrDefaultAsync();
            return response;
        }

        public async Task<T> GetByIntId(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            
           
        }

        public Task UpdateAsync(int reqId)
        {
            throw new NotImplementedException();
        }
    }
}
