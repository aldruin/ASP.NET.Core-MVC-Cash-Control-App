using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Domain.Models
{
    public class FinancialEntry
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Required]
        [ForeignKey("Sheet")]
        public Guid SheetId { get; set; }

        [Required]
        public Sheet Sheet { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly EntryDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }

        [Required]
        public string Category { get; set; }



        protected FinancialEntry() { }
        public void Update(string name, decimal value, string category, DateOnly entrydate)
        {
            Name = name;
            EntryDate = entrydate;
            Value = value;
            Category = category;
        }
    }
}
