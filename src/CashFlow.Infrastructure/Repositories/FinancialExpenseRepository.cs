using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Data;

namespace CashFlow.Infrastructure.Repositories
{
    public class FinancialExpenseRepository : Repository<FinancialExpense>, IFinancialExpenseRepository
    {
        public FinancialExpenseRepository(AppDbContext context) : base(context)
        {
        }
    }
}
