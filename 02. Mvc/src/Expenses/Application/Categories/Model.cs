using System;

namespace Expenses.Application
{
    public class Category : IEquatable<string>
    {
        public string Name { get; private set; }

        public static Category Create(string category)
        {
            if (String.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category must have name");

            return new Category
            {
                Name = category.Trim()
            };
        }

        public bool Equals(string other)
        {
            return String.Equals(Name, other?.Trim());
        }
    }
}