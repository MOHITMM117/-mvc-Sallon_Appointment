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
    public class HairdressersController : Controller
    {
        private readonly SallonappointmentDbContext _context;

        public HairdressersController(SallonappointmentDbContext context)
        {
            _context = context;
        }

        // GET: Hairdressers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hairdresser.ToListAsync());
        }

        // GET: Hairdressers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairdresser = await _context.Hairdresser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairdresser == null)
            {
                return NotFound();
            }

            return View(hairdresser);
        }

        // GET: Hairdressers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hairdressers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsPermanent")] Hairdresser hairdresser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hairdresser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hairdresser);
        }

        // GET: Hairdressers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairdresser = await _context.Hairdresser.FindAsync(id);
            if (hairdresser == null)
            {
                return NotFound();
            }
            return View(hairdresser);
        }

        // POST: Hairdressers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsPermanent")] Hairdresser hairdresser)
        {
            if (id != hairdresser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hairdresser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HairdresserExists(hairdresser.Id))
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
            return View(hairdresser);
        }

        // GET: Hairdressers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairdresser = await _context.Hairdresser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairdresser == null)
            {
                return NotFound();
            }

            return View(hairdresser);
        }

        // POST: Hairdressers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hairdresser = await _context.Hairdresser.FindAsync(id);
            _context.Hairdresser.Remove(hairdresser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HairdresserExists(int id)
        {
            return _context.Hairdresser.Any(e => e.Id == id);
        }
    }
}
