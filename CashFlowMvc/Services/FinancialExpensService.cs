using AutoMapper;
using CashFlowMvc.DTOs;
using CashFlowMvc.Models;
using CashFlowMvc.Repositories.Interfaces;
using CashFlowMvc.Services.Interfaces;

namespace CashFlowMvc.Services
{
    public class FinancialExpenseService : IFinancialExpenseService
    {
        private readonly IFinancialExpenseRepository _financialExpenseRepository;
        private readonly IMapper _mapper;

        public FinancialExpenseService(IFinancialExpenseRepository financialExpenseRepository, IMapper mapper)
        {
            _mapper = mapper;
            _financialExpenseRepository = financialExpenseRepository;
        }
        public async Task<FinancialExpenseDTO> CreateExpenseAsync(FinancialExpenseDTO financialExpenseDTO)
        {
            if (financialExpenseDTO.Value == null || financialExpenseDTO.Name == null || financialExpenseDTO.Category == null || financialExpenseDTO.SheetId == null)
                throw new Exception("Dados inválidos");
            var expense = _mapper.Map<FinancialExpense>(financialExpenseDTO);
            await _financialExpenseRepository.AddAsync(expense);
            return _mapper.Map<FinancialExpenseDTO>(expense);


        }
        public async Task<FinancialExpenseDTO> UpdateExpenseAsync(FinancialExpenseDTO financialExpenseDTO, Guid expenseId)
        {
            var expense = await _financialExpenseRepository.GetByIdAsync(expenseId);
            if (expense == null)
                throw new Exception("O usuario não foi encontrado.");
            expense.Update(financialExpenseDTO.Name, financialExpenseDTO.Value, financialExpenseDTO.Category, financialExpenseDTO.ExpenseDate);
            await _financialExpenseRepository.UpdateAsync(expense);
            return _mapper.Map<FinancialExpenseDTO>(expense);
        }
        public async Task<FinancialExpenseDTO> DeleteExpenseAsync(Guid expenseId)
        {
            var expense = await _financialExpenseRepository.GetByIdAsync(expenseId);
            if (expense == null)
                throw new Exception("Evento não encontrado");
            await _financialExpenseRepository.DeleteAsync(expenseId);
            return null;
        }
        public async Task<FinancialExpenseDTO> GetExpenseById(Guid expenseId)
        {
            var expense = await _financialExpenseRepository.GetByIdAsync(expenseId);
            if (expense == null)
                throw new Exception("Evento não encontrado");
            return _mapper.Map<FinancialExpenseDTO>(expense);
        }
        public async Task<List<FinancialExpenseDTO>> GetAllAsync()
        {
            var expense = await _financialExpenseRepository.GetAllAsync();
            return _mapper.Map<List<FinancialExpenseDTO>>(expense);
        }
    }
}
