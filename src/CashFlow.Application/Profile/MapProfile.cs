using CashFlow.Application.DTOs;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.Profile
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            CreateMap<Sheet, SheetDTO>();
            CreateMap<SheetDTO, Sheet>();
            CreateMap<FinancialEntry, FinancialEntryDTO>();
            CreateMap<FinancialEntryDTO, FinancialEntry>();
            CreateMap<FinancialExpense, FinancialExpenseDTO>();
            CreateMap<FinancialExpenseDTO, FinancialExpense>();
        }
    }
}
