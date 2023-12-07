using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Data;

namespace CashFlow.Infrastructure.Repositories
{
    public class SheetRepository : Repository<Sheet>, ISheetRepository
    {
        public SheetRepository(AppDbContext context) : base(context)
        {
        }
    }
}
