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

        public SheetController(ISheetService sheetService, UserManager<User> userManager)
        {
            _sheetService = sheetService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {

            var sheets = await _sheetService.GetAllAsync();


            return View(sheets);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var sheet = await _sheetService.GetByIdAsync(id);
            return View(sheet);
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
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (Guid.TryParse(userIdString, out Guid userId))
                {
                    sheetDTO.UserId = userId;

                    await _sheetService.CreateSheetAsync(sheetDTO);

                    return RedirectToAction(nameof(Index));
                }
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
