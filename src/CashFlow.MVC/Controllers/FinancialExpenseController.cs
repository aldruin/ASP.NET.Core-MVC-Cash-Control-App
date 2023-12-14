using CashFlow.Application.DTOs;
using CashFlow.Application.Interfaces;
using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.MVC.Controllers
{
    public class FinancialExpenseController : Controller
    {
        private readonly IFinancialExpenseService _expenseService;
        private readonly ISheetService _sheetService;

        public FinancialExpenseController(IFinancialExpenseService expenseService, ISheetService sheetService)
        {
            _expenseService = expenseService;
            _sheetService = sheetService;
        }


        public async Task<IActionResult> Index(Guid sheetId)
        {

            var expenses = await _expenseService.GetAllAsync(sheetId);


            return View(expenses);
        }



        public async Task<IActionResult> Details(Guid id)
        {
            var expense = await _expenseService.GetExpenseById(id);
            return View(expense);
        }

        public async Task<IActionResult> Create(Guid sheetId)
        {
            ViewBag.SheetId = sheetId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SheetId,Name,Value,Category,ExpenseDate")] FinancialExpenseDTO expenseDTO)
        {
            if (ModelState.IsValid)
            {

                await _expenseService.CreateExpenseAsync(expenseDTO);

                return RedirectToAction("Details", "Sheet", new { id = expenseDTO.SheetId });
            }

            return View(expenseDTO);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var expense = await _expenseService.GetExpenseById(id);
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Value,Category,ExpenseDate")] FinancialExpenseDTO expenseDTO)
        {
            if (ModelState.IsValid)
            {
                await _expenseService.UpdateExpenseAsync(expenseDTO, id);
                return RedirectToAction("Details", "Sheet", new { id = expenseDTO.SheetId });
            }

            return View(expenseDTO);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _expenseService.GetExpenseById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var expense = await _expenseService.GetExpenseById(id);
            if (expense == null)
            {
                ViewBag.ErrorMessage = "Saída não encontrada.";
                return View();
            }

            var sheetId = expense.SheetId;

            await _expenseService.DeleteExpenseAsync(id);

            return RedirectToAction("Details", "Sheet", new { id = sheetId });
        }
    }
}
