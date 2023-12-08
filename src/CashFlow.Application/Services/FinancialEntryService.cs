using AutoMapper;
using CashFlow.Application.DTOs;
using CashFlow.Application.Interfaces;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Application.Services;

public class FinancialEntryService : IFinancialEntryService
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IMapper _mapper;

    public FinancialEntryService(IFinancialEntryRepository financialEntryRepository, IMapper mapper)
    {
        _financialEntryRepository = financialEntryRepository;
        _mapper = mapper;
    }

    public async Task<FinancialEntryDTO> CreateEntryAsync(FinancialEntryDTO financialEntryDTO)
    {
        if (financialEntryDTO.Value == null || financialEntryDTO.Name == null || financialEntryDTO.Category == null || financialEntryDTO.SheetId == null)
            throw new Exception("Dados inválidos");
        var entry = _mapper.Map<FinancialEntry>(financialEntryDTO);
        await _financialEntryRepository.AddAsync(entry);
        return _mapper.Map<FinancialEntryDTO>(entry);


    }
    public async Task<FinancialEntryDTO> UpdateEntryAsync(FinancialEntryDTO financialEntryDTO, Guid entryId)
    {
        var entry = await _financialEntryRepository.GetByIdAsync(entryId);
        if (entry == null)
            throw new Exception("O usuario não foi encontrado.");
        entry.Update(financialEntryDTO.Name, financialEntryDTO.Value, financialEntryDTO.Category, financialEntryDTO.EntryDate);
        await _financialEntryRepository.UpdateAsync(entry);
        return _mapper.Map<FinancialEntryDTO>(entry);
    }
    public async Task<FinancialEntryDTO> DeleteEntryAsync(Guid entryId)
    {
        var entry = await _financialEntryRepository.GetByIdAsync(entryId);
        if (entry == null)
            throw new Exception("Evento não encontrado");
        await _financialEntryRepository.DeleteAsync(entryId);
        return null;
    }
    public async Task<FinancialEntryDTO> GetEntryById(Guid entryId)
    {
        var entry = await _financialEntryRepository.GetByIdAsync(entryId);
        if (entry == null)
            throw new Exception("Evento não encontrado");
        return _mapper.Map<FinancialEntryDTO>(entry);
    }
    public async Task<List<FinancialEntryDTO>> GetAllAsync()
    {
        var entry = await _financialEntryRepository.GetAllAsync();
        return _mapper.Map<List<FinancialEntryDTO>>(entry);
    }
}
