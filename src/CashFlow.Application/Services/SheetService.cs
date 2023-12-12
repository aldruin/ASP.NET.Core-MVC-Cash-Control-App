using AutoMapper;
using CashFlow.Application.DTOs;
using CashFlow.Application.Interfaces;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CashFlow.Application.Services
{
    public class SheetService : ISheetService
    {
        private readonly ISheetRepository _sheetRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SheetService(ISheetRepository sheetRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _sheetRepository = sheetRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private Guid GetCurrentUserId()
        {
            var userIdString = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(userIdString, out Guid userId))
            {
                return userId;
            }
            throw new Exception("Usuário não autenticado ou ID inválido.");
        }

        public async Task<SheetDTO> CreateSheetAsync(SheetDTO sheetDTO)
        {
            var userId = GetCurrentUserId();

            if (sheetDTO == null)
                throw new Exception("Insira um nome válido");


            var sheet = _mapper.Map<Sheet>(sheetDTO);
            sheet.UserId = userId;
            await _sheetRepository.AddAsync(sheet);
            return _mapper.Map<SheetDTO>(sheet);
        }

        public async Task<List<SheetDTO>> GetAllAsync()
        {
            var userId = GetCurrentUserId();
            var sheets = await _sheetRepository.GetSheetsByUserIdAsync(userId);
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
            {
                throw new Exception("A planilha não foi encontrada");
            }

            await _sheetRepository.DeleteAsync(sheetId);
            return null;
        }
    }
}