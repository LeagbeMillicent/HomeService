using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Repository.WorkUnits
{
    public interface IWorkUnitsRepository<TEntity> where TEntity : class
    {
        // Get all Workers
        Task<IReadOnlyList<TEntity>> GetAllAsync(string query);

        // Get Workers by ID
        Task<TEntity> GetId(FormattableString sqlQuery);

        // Create a new Workers
        Task<int> CreateAsync(FormattableString sqlQuery);

        // Update an existing Workers
        Task<int> UpdateAsync(FormattableString sqlQuery);

        // Delete Workers by ID
        Task<int> DeleteAsync(FormattableString sqlQuery);
    }
}
