using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Application
{
    public class ExpenseService
    {
        private readonly IExpenseRepository _expenses;
        private readonly ICategoryRepository _categories;

        public ExpenseService(IExpenseRepository expenses, ICategoryRepository categories)
        {
            _expenses = expenses;
            _categories = categories;
        }

        public async Task<Expense> Find(int id)
        {
            var expense = await _expenses.Find(id);
            return expense;
        }

        public async Task<Expense> Add(decimal amount, string category)
        {
            var expense = Expense.Create(amount, category);
            var categories = await _categories.GetAsync();

            if (categories.All(c => !c.Name.Equals(category)))
            {
                await _categories.Add(Category.Create(category));
            }

            await _expenses.Add(expense);
            return expense;
        }
    }
}
