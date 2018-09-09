using Expenses.Application;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Expenses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _service;

        public ExpenseController(ExpenseService service)
        {
            _service = service;
        }

        [HttpGet("{id}", Name = "FindExpense")]
        public async Task<ActionResult<ExpenseResponse>> Find(int id)
        {
            var expense = await _service.Find(id);
            if (expense == null)
                return NotFound();

            return ToResponse(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateExpenseRequest request)
        {
            var expense = await _service.Add(request.Amount.Value, request.Category);
            var responese = ToResponse(expense);
            return CreatedAtRoute("FindExpense", new { id = expense.Id }, responese);
        }

        public static ExpenseResponse ToResponse(Expense expense)
        {
            return new ExpenseResponse
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Category = expense.Category
            };
        }
    }

    public class CreateExpenseRequest
    {
        [Required]
        public decimal? Amount { get; set; }

        [Required]
        public string Category { get; set; }
    }

    public class ExpenseResponse
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Category { get; set; }
    }
}