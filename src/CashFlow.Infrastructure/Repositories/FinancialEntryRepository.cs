using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Data;

namespace CashFlow.Infrastructure.Repositories
{
    public class FinancialEntryRepository : Repository<FinancialEntry>, IFinancialEntryRepository
    {
        public FinancialEntryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
