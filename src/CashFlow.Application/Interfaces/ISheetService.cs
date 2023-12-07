using CashFlow.Application.DTOs;

namespace CashFlow.Application.Interfaces
{
    public interface ISheetService
    {
        Task<SheetDTO> CreateSheetAsync(SheetDTO sheetDTO);
        Task<List<SheetDTO>> GetAllAsync();
        Task<SheetDTO> GetByIdAsync(Guid sheetId);
        Task<SheetDTO> UpdateByIdAsync(Guid sheetId, SheetDTO sheetDTO);
        Task<SheetDTO> DeleteByIdAsync(Guid sheetId);

    }
}
