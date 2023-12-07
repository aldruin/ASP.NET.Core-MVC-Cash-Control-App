using CashFlowMvc.DTOs;
using CashFlowMvc.Models;

namespace CashFlowMvc.Profile
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
