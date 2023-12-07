namespace CashFlowMvc.DTOs
{
    public class FinancialEntryDTO
    {
        public Guid SheetId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Category { get; set; }
        public DateOnly EntryDate { get; set; }
    }
}
