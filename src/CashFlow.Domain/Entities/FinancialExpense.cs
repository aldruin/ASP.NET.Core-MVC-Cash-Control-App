using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Domain.Entities
{
    public class FinancialExpense
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Sheet")]
        public Guid SheetId { get; set; }

        [Required]
        public Sheet Sheet { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly ExpenseDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Value { get; set; }

        [Required]
        public string Category { get; set; }

        protected FinancialExpense() { }
        public void Update(string name, decimal? value, string category, DateOnly expensedate)
        {
            Name = name;
            ExpenseDate = expensedate;
            Value = value;
            Category = category;
        }
    }
}
