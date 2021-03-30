using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _mvc_Sallon_Appointment.Data;
using _mvc_Sallon_Appointment.Models;
using Microsoft.AspNetCore.Authorization;

namespace _mvc_Sallon_Appointment.Controllers
{
    [Authorize]
    public class HaircutsController : Controller
    {
        private readonly SallonappointmentDbContext _context;

        public HaircutsController(SallonappointmentDbContext context)
        {
            _context = context;
        }

        // GET: Haircuts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Haircut.ToListAsync());
        }

        // GET: Haircuts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haircut = await _context.Haircut
                .FirstOrDefaultAsync(m => m.Id == id);
            if (haircut == null)
            {
                return NotFound();
            }

            return View(haircut);
        }

        // GET: Haircuts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Haircuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OptionName,Charge")] Haircut haircut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haircut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haircut);
        }

        // GET: Haircuts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haircut = await _context.Haircut.FindAsync(id);
            if (haircut == null)
            {
                return NotFound();
            }
            return View(haircut);
        }

        // POST: Haircuts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OptionName,Charge")] Haircut haircut)
        {
            if (id != haircut.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haircut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaircutExists(haircut.Id))
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
            return View(haircut);
        }

        // GET: Haircuts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haircut = await _context.Haircut
                .FirstOrDefaultAsync(m => m.Id == id);
            if (haircut == null)
            {
                return NotFound();
            }

            return View(haircut);
        }

        // POST: Haircuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var haircut = await _context.Haircut.FindAsync(id);
            _context.Haircut.Remove(haircut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaircutExists(int id)
        {
            return _context.Haircut.Any(e => e.Id == id);
        }
    }
}
