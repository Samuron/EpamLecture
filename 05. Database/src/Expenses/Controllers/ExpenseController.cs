using Expenses.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Expenses.Controllers
{
    /// <summary>
    /// Provides API to manage expenses.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public ExpenseController(ExpenseService service)
        {
            _service = service;
        }

        /// <summary>
        /// Finds the expense with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "FindExpense")]
        public async Task<ActionResult<ExpenseResponse>> Find(int id)
        {
            var expense = await _service.Find(id);
            if (expense == null)
                return NotFound();

            return ToResponse(expense);
        }

        /// <summary>
        /// Creates new expense.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ExpenseResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CreateExpenseRequest request)
        {
            var expense = await _service.Add(request.Amount.Value, request.Category);
            var responese = ToResponse(expense);
            return CreatedAtRoute("FindExpense", new { id = expense.Id }, responese);
        }

        private static ExpenseResponse ToResponse(Expense expense)
        {
            return new ExpenseResponse
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Category = expense.Category
            };
        }
    }

    /// <summary>
    /// Request to create new expense.
    /// </summary>
    public class CreateExpenseRequest
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [Required]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [Required]
        public string Category { get; set; }
    }

    /// <summary>
    /// Represents expense.
    /// </summary>
    public class ExpenseResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }
    }
}