using CashFlowMvc.Data;
using CashFlowMvc.Models;
using CashFlowMvc.Repositories.Interfaces;

namespace CashFlowMvc.Repositories
{
    public class SheetRepository : Repository<Sheet>, ISheetRepository
    {
        public SheetRepository(AppDbContext context) : base(context)
        {
        }
    }
}
