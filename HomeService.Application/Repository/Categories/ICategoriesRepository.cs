using HomeService.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Repository.Categories
{
    public interface ICategoriesRepository<TEntity> where TEntity : class
    {
        // Get all Categories
        Task<ReadCategoriesDto> GetAllCategory(FormattableString query);

        // Get Category by ID
        Task<ReadCategoriesByIdDto> GetCategoryBId(FormattableString sqlQuery);

        // Add a new Categories
        Task<int> CreateCategory(FormattableString sqlQuery);

        // Update an existing Categories
        Task<int> UpdateCategory(FormattableString sqlQuery);

        // Delete an Categories by ID
        Task<int> DeleteCategory(FormattableString sqlQuery);
    }
}
