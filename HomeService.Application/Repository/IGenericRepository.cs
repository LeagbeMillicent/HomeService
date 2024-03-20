using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll(FormattableString query);

        Task<T> GetById(FormattableString query);

        Task<T> Create(T entity);
    }
}
