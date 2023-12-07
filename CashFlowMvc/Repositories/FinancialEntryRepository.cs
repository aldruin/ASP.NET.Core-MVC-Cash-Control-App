using CashFlowMvc.Data;
using CashFlowMvc.Models;
using CashFlowMvc.Repositories.Interfaces;

namespace CashFlowMvc.Repositories
{
    public class FinancialEntryRepository : Repository<FinancialEntry>, IFinancialEntryRepository
    {
        public FinancialEntryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
