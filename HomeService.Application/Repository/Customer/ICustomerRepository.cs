using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Repository.Customer
{
    public interface ICustomerRepository<TEntity> where TEntity : class
    {

        // Get all Customers
        Task<IReadOnlyList<TEntity>> GetAllAsync(string query);

        // Get Customers by ID
        Task<TEntity> GetId(FormattableString sqlQuery);

        // Add a new Customers
        Task<int> CreateAsync(FormattableString sqlQuery);

        // Update an existing Customers
        Task<int> UpdateAsync(FormattableString sqlQuery);

        // Delete Customers by ID
        Task<int> DeleteAsync(FormattableString sqlQuery);

    }
}
