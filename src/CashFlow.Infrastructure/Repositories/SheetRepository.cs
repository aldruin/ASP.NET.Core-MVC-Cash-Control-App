using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories
{
    public class SheetRepository : Repository<Sheet>, ISheetRepository
    {
        public SheetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Sheet>> GetSheetsByUserIdAsync(Guid userId)
        {
            try
            {
                var sheets = await Query.Cast<Sheet>().Where(s => s.UserId == userId).ToListAsync();
                return sheets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
