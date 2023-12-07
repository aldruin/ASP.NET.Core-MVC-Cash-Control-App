using CashFlowMvc.DTOs;

namespace CashFlowMvc.Services.Interfaces
{
    public interface IFinancialExpenseService
    {
        Task<FinancialExpenseDTO> CreateExpenseAsync(FinancialExpenseDTO financialExpenseDTO);
        Task<FinancialExpenseDTO> UpdateExpenseAsync(FinancialExpenseDTO financialExpenseDTO, Guid expenseId);
        Task<FinancialExpenseDTO> DeleteExpenseAsync(Guid expenseId);
        Task<FinancialExpenseDTO> GetExpenseById(Guid expenseId);
        Task<List<FinancialExpenseDTO>> GetAllAsync();
    }
}
