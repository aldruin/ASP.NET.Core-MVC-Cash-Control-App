using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories
{
    public class FinancialExpenseRepository : Repository<FinancialExpense>, IFinancialExpenseRepository
    {
        public FinancialExpenseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ICollection<FinancialExpense>> GetExpenseBySheetIdAsync(Guid sheetId)
        {
            try
            {
                var expenses = await Query.Cast<FinancialExpense>().Where(s => s.SheetId == sheetId).ToListAsync();
                return expenses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
