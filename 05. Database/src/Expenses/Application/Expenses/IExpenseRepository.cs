using System.Threading.Tasks;

namespace Expenses.Application
{
    public interface IExpenseRepository
    {
        Task<Expense> Find(int id);

        Task Add(Expense expense);
    }

}
