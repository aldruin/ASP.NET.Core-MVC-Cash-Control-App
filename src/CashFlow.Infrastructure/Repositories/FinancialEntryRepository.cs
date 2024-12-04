using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories
{
    public class FinancialEntryRepository : Repository<FinancialEntry>, IFinancialEntryRepository
    {
        public FinancialEntryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ICollection<FinancialEntry>> GetEntryBySheetIdAsync(Guid sheetId)
        {
                var entries = await Query.Cast<FinancialEntry>().Where(s => s.SheetId == sheetId).ToListAsync();
                return entries;
        }
    }
}
