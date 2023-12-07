using System.Linq.Expressions;

namespace CashFlow.Domain.Interfaces
{

    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<ICollection<T>> GetAllAsync();
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(Guid id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
