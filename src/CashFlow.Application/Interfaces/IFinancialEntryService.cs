using CashFlow.Application.DTOs;

namespace CashFlow.Application.Interfaces
{
    public interface IFinancialEntryService
    {
        Task<FinancialEntryDTO> CreateEntryAsync(FinancialEntryDTO financialEntryDTO);
        Task<FinancialEntryDTO> UpdateEntryAsync(FinancialEntryDTO financialEntryDTO, Guid entryId);
        Task<FinancialEntryDTO> DeleteEntryAsync(Guid entryId);
        Task<FinancialEntryDTO> GetEntryById(Guid entryId);
        Task<List<FinancialEntryDTO>> GetAllAsync();
    }
}
