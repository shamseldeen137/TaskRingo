using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task.Repos.Models;
using Task.Services.IServices;

namespace Task.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(ILogger<HomeController> logger, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _logger = logger;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
         var departments=   _departmentService.GetMainDepartments();


            return View(departments);
        }


        public async Task< ActionResult> GetDepartmentChildren(Guid Id)
        {
            ViewBag.SelectedDepartmentId = Id;
            var departments = await _departmentService.GetDepartmentChildren(Id);


            return View("Hirarichay", departments);
        }
        public async Task<ActionResult> GetDepartmentParents(Guid Id)
        {
            ViewBag.SelectedDepartmentId = Id;
            var departments = await _departmentService.GetDepartmentParents(Id);


            return View("Hirarichay", departments);
        }
        // GET: DepartmentController/Details/5
        public ActionResult Details(Guid id)
        {
          var department=  _departmentService.GetDepartment(id);
            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            ViewBag.ParentId =new SelectList( _departmentService.GetDepartments(),nameof(Department.DepartmentId), nameof(Department.DepartmentName));
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task< ActionResult> Create(Department department)
        {
            try
            {
                await _departmentService.CreateDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
