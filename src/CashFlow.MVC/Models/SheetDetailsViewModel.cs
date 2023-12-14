using CashFlow.Application.DTOs;

public class SheetDetailsViewModel
{
    public SheetDTO Sheet { get; set; }
    public IEnumerable<FinancialEntryDTO> Entries { get; set; }
    public IEnumerable<FinancialExpenseDTO> Expenses { get; set; }
}
