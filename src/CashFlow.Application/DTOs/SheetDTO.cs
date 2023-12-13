using CashFlow.Domain.Entities;

namespace CashFlow.Application.DTOs
{
    public class SheetDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        //public User? User { get; set; }
        public List<FinancialEntry>? Entries { get; set; } 
        public List<FinancialExpense>? Expenses { get; set; } 
    }
}
