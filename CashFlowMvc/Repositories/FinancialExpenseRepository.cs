using CashFlowMvc.Data;
using CashFlowMvc.Models;
using CashFlowMvc.Repositories.Interfaces;

namespace CashFlowMvc.Repositories
{
    public class FinancialExpenseRepository : Repository<FinancialExpense>, IFinancialExpenseRepository
    {
        public FinancialExpenseRepository(AppDbContext context) : base(context)
        {
        }
    }
}
