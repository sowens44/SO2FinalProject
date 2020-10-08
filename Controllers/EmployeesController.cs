using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SO2FinalProject.Models;

namespace SO2FinalProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly OwensDbContext _context;

        public EmployeesController(OwensDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchBy, string search)
        {
            var owensDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Job);
            if (searchBy == "FirstName")
            {  
            //var owensDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Job);
            return View(await owensDbContext.Where(x => x.FirstName == search || search == null).ToListAsync());
            }
            else
            {
              //  var owensDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Job);
                return View(await owensDbContext.Where(x => x.FirstName.StartsWith(search) || search == null).ToListAsync());

            }

            if (searchBy == "LastName")
            {
                //var owensDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Job);
                return View(await owensDbContext.Where(x => x.LastName == search || search == null).ToListAsync());
            }
            else
            {
                //var owensDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Job);
                return View(await owensDbContext.Where(x => x.LastName.StartsWith(search) || search == null).ToListAsync());

            }
            if (searchBy == "Email")
            {
                //var owensDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Job);
                return View(await owensDbContext.Where(x => x.Email == search || search == null).ToListAsync());
            }
            else
            {
                //var owensDbContext = _context.Employees.Include(e => e.Department).Include(e => e.Job);
                return View(await owensDbContext.Where(x => x.Email.StartsWith(search) || search == null).ToListAsync());

            }
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "Title");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Email,PhoneNum,HireDate,JobId,DepartmentId")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", employees.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "Title", employees.JobId);
            return View(employees);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", employees.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "Title", employees.JobId);
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Email,PhoneNum,HireDate,JobId,DepartmentId")] Employees employees)
        {
            if (id != employees.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", employees.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "Title", employees.JobId);
            return View(employees);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employees = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
