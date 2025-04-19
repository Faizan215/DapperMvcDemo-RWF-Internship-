using DapperMvcDemo.Data.Models.Domain;
using DapperMvcDemo.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperMvcDemo.UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // Show all persons (page with filter/search)
        public async Task<IActionResult> DisplayAll()
        {
            var departments = await _personRepository.GetDepartmentsAsync();
            ViewBag.Departments = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> GetPersons(int? departmentId)
        {
            IEnumerable<Person> persons;

            if (departmentId.HasValue)
            {
                persons = await _personRepository.GetPersonsByDepartmentAsync(departmentId.Value);
            }
            else
            {
                persons = await _personRepository.GetAllPersonsAsync();
            }

            return Json(persons);
        }

        // GET: Add Person
        public async Task<IActionResult> Add()
        {
            var departments = await _personRepository.GetDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        // POST: Add Person
        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _personRepository.GetDepartmentsAsync();
                ViewBag.Departments = new SelectList(departments, "Id", "Name");
                return View(person);
            }

            var result = await _personRepository.AddAsync(person);
            if (result)
                return RedirectToAction(nameof(DisplayAll));

            ModelState.AddModelError("", "Failed to add person.");
            return View(person);
        }

        // GET: Edit Person
        public async Task<IActionResult> Edit(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return NotFound();

            var departments = await _personRepository.GetDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", person.DepartmentId);
            return View(person);
        }

        // POST: Edit Person
        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _personRepository.GetDepartmentsAsync();
                ViewBag.Departments = new SelectList(departments, "Id", "Name", person.DepartmentId);
                return View(person);
            }

            var result = await _personRepository.UpdateAsync(person);
            if (result)
                return RedirectToAction(nameof(DisplayAll));

            ModelState.AddModelError("", "Failed to update person.");
            return View(person);
        }
    }
}
