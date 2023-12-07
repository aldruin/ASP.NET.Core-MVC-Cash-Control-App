using CashFlowMvc.DTOs;

namespace CashFlowMvc.Services.Interfaces
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
