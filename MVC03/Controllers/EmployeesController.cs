using BusinessLogic.DTO.Employees;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Employees;

namespace Presentation.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IHostEnvironment _env;

        public EmployeesController(IEmployeeServices employeeServices, ILogger<DepartmentsController> logger, IHostEnvironment env)
        {
            _employeeServices = employeeServices;
            _logger = logger;
            _env = env;
        }

        public IActionResult Index(string? EmployeeSearchName)
        {
            var e = _employeeServices.GetAllEmployees(EmployeeSearchName);
            return View(e);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel e)
        {
            if (!ModelState.IsValid)
            {
                return View(e);
            }
            var m = string.Empty;
            try
            {
                var empDTO = new CreatedEmployeeDTO()
                {
                    Name = e.Name,
                    Email = e.Email,
                    Address = e.Address,
                    PhoneNumber = e.PhoneNumber,
                    Age = e.Age,
                    Salary = e.Salary,
                    IsActive = e.IsActive,
                    HiringDate = e.HiringDate,
                    Gender = e.Gender,
                    EmployeeType = e.EmployeeType,
                    DepartmentId = e.DepartmentId,
                    Image = e.Image
                };
                var r = _employeeServices.CreateEmployee(empDTO);
                if (r > 0) return RedirectToAction(nameof(Index));
                else
                {
                    m = "Employee Cannot be Created";
                    ModelState.AddModelError(string.Empty, m);
                    return View(e);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    m = ex.Message;
                    return View(e);
                }
                else
                {
                    m = "Employee Cannot be Created";
                    return View("Index");
                }
            }
        }

        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();
            var e = _employeeServices.GetEmployeeById(id.Value);
            if (e is null) return NotFound();
            return View(e);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();
            var e = _employeeServices.GetEmployeeById(id.Value);
            if (e is null) return NotFound();
            return View(new EmployeeViewModel()
            {
                Name = e.Name,
                Address = e.Address,
                Age = e.Age,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Salary = e.Salary,
                IsActive = e.IsActive,
                HiringDate = e.HiringDate,
                Gender = Enum.Parse<Gender>(e.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(e.EmployeeType),
                DepartmentId = e.DepartmentId
            });
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel e)
        {
            if (id is null) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var empDTO = new UpdatedEmployeeDTO()
                    {
                        Id = id.Value,
                        Name = e.Name,
                        Email = e.Email,
                        Address = e.Address,
                        Salary = e.Salary,
                        Age = e.Age,
                        PhoneNumber = e.PhoneNumber,
                        IsActive = e.IsActive,
                        HiringDate = e.HiringDate,
                        Gender = e.Gender,
                        EmployeeType = e.EmployeeType,
                        DepartmentId = e.DepartmentId

                    };
                    var r = _employeeServices.UpdateEmployee(empDTO);

                    if (r > 0) return RedirectToAction(nameof(Index));
                    else ModelState.AddModelError(string.Empty, "Employee is not Updated");

                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment()) ModelState.AddModelError(string.Empty, ex.Message);
                    else _logger.LogError(ex.Message);
                }

            }
            return View(e);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            var e = _employeeServices.GetEmployeeById(id.Value);
            if (e is null) return NotFound();
            return View(e);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var m = string.Empty;
            try
            {
                var r = _employeeServices.DeleteEmployee(id);
                if (r) return RedirectToAction(nameof(Index));
                else
                {
                    m = "Employee Cannot be Deleted";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                m = _env.IsDevelopment() ? ex.Message : "Employee Cannot be Deleted";
            }
            return View(nameof(Index));
        }

    }
}
