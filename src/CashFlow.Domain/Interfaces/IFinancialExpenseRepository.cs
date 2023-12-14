using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces
{
    public interface IFinancialExpenseRepository : IRepository<FinancialExpense>
    {
        Task<ICollection<FinancialExpense>> GetExpenseBySheetIdAsync(Guid sheetId);
    }
}
