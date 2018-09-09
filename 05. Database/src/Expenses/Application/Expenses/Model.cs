using System;

namespace Expenses.Application
{
    public class Expense
    {
        public int Id { get; set; }

        public decimal Amount { get; private set; }

        public string Category { get; private set; }

        public static Expense Create(decimal amount, string category)
        {
            if (amount == 0)
                throw new ArgumentException("Amount must be non zer");

            if (category == null)
                throw new ArgumentException("Category is required to create expense");

            return new Expense
            {
                Amount = amount,
                Category = category
            };
        }
    }
}
