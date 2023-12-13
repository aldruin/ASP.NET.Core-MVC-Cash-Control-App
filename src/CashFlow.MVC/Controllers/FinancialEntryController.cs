using CashFlow.Application.DTOs;
using CashFlow.Application.Interfaces;
using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.MVC.Controllers
{
    public class FinancialEntryController : Controller
    {
        private readonly IFinancialEntryService _entryService;
        private readonly ISheetService _sheetService;

        public FinancialEntryController(IFinancialEntryService entryService, ISheetService sheetService)
        {
            _entryService = entryService;
            _sheetService = sheetService;
        }


        public async Task<IActionResult> Index()
        {

            var entries = await _entryService.GetAllAsync();


            return View(entries);
        }



        public async Task<IActionResult> Details(Guid id)
        {
            var entry = await _entryService.GetEntryByIdAsync(id);
            return View(entry);
        }

        public async Task<IActionResult> Create(Guid sheetId)
        {
            ViewBag.SheetId = sheetId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SheetId,Name,Value,Category,EntryDate")] FinancialEntryDTO entryDTO)
        {
            if (ModelState.IsValid)
            {

                await _entryService.CreateEntryAsync(entryDTO);

                return RedirectToAction("Details", "Sheet");
            }

            return View(entryDTO);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var entry = await _entryService.GetEntryByIdAsync(id);
            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Value,Category,EntryDate")] FinancialEntryDTO entryDTO)
        {
            if (ModelState.IsValid)
            {
                await _entryService.UpdateEntryAsync(entryDTO, id);
                return RedirectToAction(nameof(Index));
            }

            return View(entryDTO);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _entryService.GetEntryByIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (ModelState.IsValid)
            {
                await _entryService.DeleteEntryAsync(id);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
