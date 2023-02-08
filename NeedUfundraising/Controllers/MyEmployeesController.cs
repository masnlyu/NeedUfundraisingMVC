using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NeedUfundraising.Models;

namespace NeedUfundraising.Controllers
{
    public class MyEmployeesController : Controller
    {
        private readonly FundraisingDbContext _context;

        public MyEmployeesController(FundraisingDbContext context)
        {
            _context = context;
        }

        // GET: MyEmployees
        public async Task<IActionResult> Index()
        {
            var fundraisingDbContext = _context.Employees.Include(e => e.PositionNavigation).Include(e => e.StatusNavigation);
            return View(await fundraisingDbContext.ToListAsync());
        }

        // GET: MyEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.PositionNavigation)
                .Include(e => e.StatusNavigation)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: MyEmployees/Create
        public IActionResult Create()
        {
            ViewData["Position"] = new SelectList(_context.EmployeePositions, "PositionId", "PositionName");
            ViewData["Status"] = new SelectList(_context.EmployeeStatuses, "StatusId", "StatusName");
            return View();
        }

        // POST: MyEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Account,Password,Name,Email,Phone,Status,Position,Sexy,Employeephoto")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Position"] = new SelectList(_context.EmployeePositions, "PositionId", "PositionName", employee.Position);
            ViewData["Status"] = new SelectList(_context.EmployeeStatuses, "StatusId", "StatusName", employee.Status);
            return View(employee);
        }

        // GET: MyEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["Position"] = new SelectList(_context.EmployeePositions, "PositionId", "PositionName", employee.Position);
            ViewData["Status"] = new SelectList(_context.EmployeeStatuses, "StatusId", "StatusName", employee.Status);
            return View(employee);
        }

        // POST: MyEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Account,Password,Name,Email,Phone,Status,Position,Sexy,Employeephoto")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["Position"] = new SelectList(_context.EmployeePositions, "PositionId", "PositionName", employee.Position);
            ViewData["Status"] = new SelectList(_context.EmployeeStatuses, "StatusId", "StatusName", employee.Status);
            return View(employee);
        }

        // GET: MyEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.PositionNavigation)
                .Include(e => e.StatusNavigation)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: MyEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
