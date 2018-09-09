using Expenses.Application;
using Expenses.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpensesContext _context;

        public CategoryRepository(ExpensesContext context)
        {
            _context = context;
        }

        public async Task Add(Category category)
        {
            var entity = new CategoryEntity
            {
                Id = category.Name
            };
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAsync()
        {
            var entities = await _context.Categories.AsNoTracking().ToListAsync();
            return entities.Select(x => Category.Create(x.Id)).ToList();
        }
    }
}
