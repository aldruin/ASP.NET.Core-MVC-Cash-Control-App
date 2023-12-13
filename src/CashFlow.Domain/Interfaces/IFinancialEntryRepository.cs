using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces
{
    public interface IFinancialEntryRepository : IRepository<FinancialEntry>
    {
        Task<ICollection<FinancialEntry>> GetEntryBySheetIdAsync(Guid sheetId);
    }
}
