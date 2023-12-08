using AutoMapper;
using CashFlow.Application.DTOs;
using CashFlow.Application.Interfaces;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Application.Services
{
    public class SheetService : ISheetService
    {
        private readonly ISheetRepository _sheetRepository;
        private readonly IMapper _mapper;

        public SheetService(ISheetRepository sheetRepository, IMapper mapper)
        {
            _sheetRepository = sheetRepository;
            _mapper = mapper;
        }

        public async Task<SheetDTO> CreateSheetAsync(SheetDTO sheetDTO)
        {
            if (sheetDTO == null)
                throw new Exception("Insira um nome válido");
            var sheet = _mapper.Map<Sheet>(sheetDTO);
            await _sheetRepository.AddAsync(sheet);
            return _mapper.Map<SheetDTO>(sheet);
        }

        public async Task<List<SheetDTO>> GetAllAsync()
        {
            var sheets = await _sheetRepository.GetAllAsync();
            return _mapper.Map<List<SheetDTO>>(sheets);
        }
        public async Task<SheetDTO> GetByIdAsync(Guid sheetId)
        {
            var sheet = await _sheetRepository.GetByIdAsync(sheetId);
            return _mapper.Map<SheetDTO>(sheet);
        }
        public async Task<SheetDTO> UpdateByIdAsync(Guid sheetId, SheetDTO sheetDTO)
        {
            var sheet = await _sheetRepository.GetByIdAsync(sheetId);
            sheet.Update(sheetDTO.Name);
            await _sheetRepository.UpdateAsync(sheet);
            return _mapper.Map<SheetDTO>(sheet);
        }
        public async Task<SheetDTO> DeleteByIdAsync(Guid sheetId)
        {
            var sheet = await _sheetRepository.GetByIdAsync(sheetId);
            if (sheet == null)
                throw new Exception("A planilha não foi encontrada");
            await _sheetRepository.DeleteAsync(sheetId);
            return null;
        }
    }
}
