using CashFlow.Application.DTOs;
using CashFlow.Application.Interfaces;
using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CashFlow.MVC.Controllers
{
    [Authorize]
    public class SheetController : Controller
    {
        private readonly ISheetService _sheetService;
        private readonly UserManager<User> _userManager;
        private readonly IFinancialEntryService _entryService;
        private readonly IFinancialExpenseService _expenseService;

        public SheetController(ISheetService sheetService, UserManager<User> userManager, IFinancialEntryService entryService, IFinancialExpenseService expenseService)
        {
            _sheetService = sheetService;
            _userManager = userManager;
            _entryService = entryService;
            _expenseService = expenseService;
        }


        public async Task<IActionResult> Index()
        {

            var sheets = await _sheetService.GetAllAsync();


            return View(sheets);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var sheet = await _sheetService.GetByIdAsync(id);

            if (sheet == null)
            {
                return NotFound();
            }

            var entries = await _entryService.GetAllAsync(id);

            var expenses = await _expenseService.GetAllAsync(id);

            var viewModel = new SheetDetailsViewModel
            {
                Sheet = sheet,
                Entries = entries,
                Expenses = expenses
            };

            return View(viewModel);
        }


        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SheetDTO sheetDTO)
        {
            if (ModelState.IsValid)
            {

                await _sheetService.CreateSheetAsync(sheetDTO);

                return RedirectToAction(nameof(Index));
            }

            return View(sheetDTO);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var sheet = await _sheetService.GetByIdAsync(id);
            return View(sheet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name")] SheetDTO sheetDTO)
        {
            if (ModelState.IsValid)
            {
                await _sheetService.UpdateByIdAsync(id, sheetDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(sheetDTO);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _sheetService.GetByIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (ModelState.IsValid)
            {
                await _sheetService.DeleteByIdAsync(id);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
