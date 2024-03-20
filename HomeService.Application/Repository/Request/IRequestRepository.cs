using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Repository.Request
{
    public interface IRequestRepository<TEntity> where TEntity : class
    {
        // Get all Request
        Task<IReadOnlyList<TEntity>> GetAllAsync(string query);

        // Get Request by ID
        Task<TEntity> GetId(FormattableString sqlQuery);

        // Create a new request
        Task<int> CreateAsync(FormattableString sqlQuery);

        // Update an existing Request
        Task<int> UpdateAsync(FormattableString sqlQuery);

        // Delete Request by ID
        Task<int> DeleteAsync(FormattableString sqlQuery);
    }
}
