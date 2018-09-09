using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.Application
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAsync();

        Task Add(Category category);
    }
}