using CashFlow.Application.DTOs;

namespace CashFlow.Application.Interfaces
{
    public interface IFinancialExpenseService
    {
        Task<FinancialExpenseDTO> CreateExpenseAsync(FinancialExpenseDTO financialExpenseDTO);
        Task<FinancialExpenseDTO> UpdateExpenseAsync(FinancialExpenseDTO financialExpenseDTO, Guid expenseId);
        Task<FinancialExpenseDTO> DeleteExpenseAsync(Guid expenseId);
        Task<FinancialExpenseDTO> GetExpenseById(Guid expenseId);
        Task<List<FinancialExpenseDTO>> GetAllAsync(Guid sheetId);
    }
}
