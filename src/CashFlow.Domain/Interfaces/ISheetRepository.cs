using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces
{
    public interface ISheetRepository : IRepository<Sheet>
    {
        Task<ICollection<Sheet>> GetSheetsByUserIdAsync(Guid userId);
    }
}