using Expenses.Application;
using Expenses.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Expenses.Infrastructure
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpensesContext _context;
        private readonly ConcurrentDictionary<int, Expense> _storage;

        public ExpenseRepository(ExpensesContext context)
        {
            _context = context;
        }

        public async Task Add(Expense expense)
        {
            var entity = new ExpenseEntity
            {
                Amount = expense.Amount,
                CategoryId = expense.Category,
            };
            _context.Expenses.Add(entity);
            await _context.SaveChangesAsync();
            expense.Id = entity.Id;
        }

        public async Task<Expense> Find(int id)
        {
            var entity = await _context.Expenses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;

            var expense = Expense.Create(entity.Amount, entity.CategoryId);
            expense.Id = entity.Id;
            return expense;
        }
    }
}
