using Expenses.Application;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ConcurrentDictionary<string, Category> _storage;

        public CategoryRepository()
        {
            _storage = new ConcurrentDictionary<string, Category>();
        }

        public Task Add(Category category)
        {
            _storage.TryAdd(category.Name, category);
            return Task.CompletedTask;
        }

        public Task<List<Category>> Get()
        {
            var categories = _storage.Values.ToList();
            return Task.FromResult(categories);
        }
    }
}
