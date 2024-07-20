using Microsoft.AspNetCore.Mvc;
using Task.Repos.Models;
using Task.Services.IServices;

namespace Task.Controllers
{
    public class RemindersController : Controller
    {
        private readonly IReminderService _reminderService;

        public RemindersController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpGet]
        public IActionResult index()
        {
            var reminders = _reminderService.GetReminders();
            return View(reminders);
        } 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                await _reminderService.CreateReminderAsync(reminder);
                return RedirectToAction("Index");
            }

            return View(reminder);
        }
    }
}
