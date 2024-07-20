using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task.Models;
using Task.Services.IServices;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;

        public HomeController(ILogger<HomeController> logger,IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        public async Task< IActionResult> Index()
        {
            var deps = await _departmentService.GetDepartmentChildren(Guid.Parse("828C63B6-00DF-4579-A4EA-9E2E469AAFDE"));
            return View(deps);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
