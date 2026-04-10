using BusinessLogic.DTO.Departments;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Departments;

namespace Presentation.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentServices _departmentservices;
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IHostEnvironment _env;

        public DepartmentsController(IDepartmentServices departmentservices, ILogger<DepartmentsController> logger, IHostEnvironment env)
        {
            _departmentservices = departmentservices;
            _logger = logger;
            _env = env;
        }
        public IActionResult Index()
        {
            //ViewData["Message"] = new DepartmentDTO() { Name = "Hello from ViewData" };
            //ViewBag.Message = new DepartmentDTO() { Name = "Hello from ViewBag" };
            var d = _departmentservices.GetAllDepartments();
            return View(d);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentViewModel d)
        {
            if (!ModelState.IsValid)
            {
                return View(d);
            }
            var m = string.Empty;
            try
            {
                var depDTO = new CreatedDepartmentDTO()
                {
                    Code = d.Code,
                    Name = d.Name,
                    Description = d.Description,
                    DateofCreation = d.DateofCreation
                };
                var r = _departmentservices.AddDepartment(depDTO);
                string message;
                if (r > 0)
                {
                    message = "Department Created Successfully";
                }
                else
                {
                    message = "Department cannot be Created now,Try later";
                }
                TempData["Message"] = message;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    m = ex.Message;
                    return View(d);
                }
                else
                {
                    m = "Department Cannot be Created";
                    return View("Index");
                }
            }
        }

        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();
            var d = _departmentservices.SetDepartmentDetailsById(id.Value);
            if (d is null) return NotFound();
            return View(d);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();
            var d = _departmentservices.SetDepartmentDetailsById(id.Value);
            if (d is null) return NotFound();
            return View(new DepartmentViewModel()
            {
                Code = d.Code,
                Name = d.Name,
                Description = d.Description,
                DateofCreation = d.DateofCreation
            });
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentViewModel d)
        {
            if (!ModelState.IsValid)
            {
                return View(d);
            }
            var m = string.Empty;
            try
            {
                var r = _departmentservices.UpdateDepartment(new UpdatedDepartmentDTO()
                {
                    Id = id,
                    Code = d.Code,
                    Name = d.Name,
                    Description = d.Description,
                    DateofCreation = d.DateofCreation
                });
                if (r > 0) return RedirectToAction(nameof(Index));
                else
                {
                    m = "Department Cannot be Updated";
                    return View(d);
                }
            }
            catch (Exception ex)
            {
                m = _env.IsDevelopment() ? ex.Message : "Department Cannot be Updated";
            }
            return View(d);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            var d = _departmentservices.SetDepartmentDetailsById(id.Value);
            if (d is null) return NotFound();
            return View(d);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var m = string.Empty;
            try
            {
                var r = _departmentservices.DeleteDepartment(id);
                if (r) return RedirectToAction(nameof(Index));
                else
                {
                    m = "Department Cannot be Deleted";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                m = _env.IsDevelopment() ? ex.Message : "Department Cannot be Deleted";
            }
            return View(nameof(Index));
        }
    }
}
