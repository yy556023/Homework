using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HW_20211105.Models;

namespace HW_20211105.Controllers
{
    public class StaffController : Controller
    {
        private readonly HomeWorkContext _context;

        public StaffController(HomeWorkContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }


        // GET: Staff
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblStaff.ToListAsync());
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblStaff = await _context.TblStaff
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblStaff == null)
            {
                return NotFound();
            }

            return View(tblStaff);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department,Title,Age")] TblStaff tblStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblStaff);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblStaff = await _context.TblStaff.FindAsync(id);
            if (tblStaff == null)
            {
                return NotFound();
            }
            return View(tblStaff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Department,Title,Age")] TblStaff tblStaff)
        {
            if (id != tblStaff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStaffExists(tblStaff.Id))
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
            return View(tblStaff);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblStaff = await _context.TblStaff.FindAsync(id);
            if (tblStaff == null)
            {
                return NotFound();
            }

            return View(tblStaff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblStaff = await _context.TblStaff.FindAsync(id);
            _context.TblStaff.Remove(tblStaff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public void MoreLinq()
        {
            // (a)
            var Lista = _context.TblStaff.Where(x => x.Department == 1).ToList();
            // (b)
            var Listb = _context.TblStaff.OrderByDescending(x => x.Age).ToList();
            // (c)
            var Listc = ((uint?)_context.TblStaff.Sum(x => x.Age));
            // (d)
            var Listd = _context.TblStaff.Where(x => x.Department == 2 || x.Department == 3).Count();
            // (e)
            var Liste = _context.TblStaff.Where(x => x.Name.Contains("e")).Max(x => x.Age);
            // (f)
            var Listf = (_context.TblStaff.Where(x => x.Title == "專員")
                                        .Select(x => new
                                        {
                                            ID = x.Id,
                                            Name = x.Name,
                                            Age = x.Age
                                        })).ToList();
        }

        public async Task<IActionResult> List()
        {
            var List = await _context.TblStaff
                              .Join(_context.TblDepartment, s => s.Department, d => d.Id, (s, d) => new { s, d })
                              .Select(x => new Challenge()
                              {
                                  Id = x.s.Id,
                                  Name = x.s.Name,
                                  Department = x.d.Name,
                                  Title = x.s.Title,
                                  Age = x.s.Age
                              }).ToListAsync();

            return View(List);
        }

        private bool TblStaffExists(int id)
        {
            return _context.TblStaff.Any(e => e.Id == id);
        }

        [HttpPost]
        [ActionName("CreateAjax")]
        public async Task<IActionResult> CreateAjax(TblStaff model)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
