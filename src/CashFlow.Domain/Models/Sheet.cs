using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Domain.Models
{
    public class Sheet
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<FinancialEntry> FinancialEntries { get; set; } = new List<FinancialEntry> { };

        [Required]
        public List<FinancialExpense> FinancialExpenses { get; set; } = new List<FinancialExpense>();


        protected Sheet() { }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
