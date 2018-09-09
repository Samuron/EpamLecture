using Expenses.Application;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Infrastructure
{
    public class ExpenseRepository : IExpenseRepository
    {
        private ConcurrentDictionary<int, Expense> _storage;

        public ExpenseRepository()
        {
            _storage = new ConcurrentDictionary<int, Expense>();
        }

        public Task Add(Expense expense)
        {
            var id = _storage.Keys.DefaultIfEmpty().Max() + 1;
            expense.Id = id;
            _storage.TryAdd(id, expense);
            return Task.CompletedTask;
        }

        public Task<Expense> Find(int id)
        {
            var expense = _storage.GetValueOrDefault(id);
            return Task.FromResult(expense);
        }
    }
}
