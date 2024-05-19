using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMedicine;
using WebMedicine.Models;

namespace WebMedicine.Controllers
{
    public class DoctorvisitsController : Controller
    {
        private readonly MedicineContext _context;

        public DoctorvisitsController(MedicineContext context)
        {
            _context = context;
        }

        // GET: Doctorvisits
        public async Task<IActionResult> Index()
        {
            var medicineContext = _context.Doctorvisits.Include(d => d.Doctor).Include(d => d.Patient);
            return View(await medicineContext.ToListAsync());
        }

        // GET: Doctorvisits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorvisit = await _context.Doctorvisits
                .Include(d => d.Doctor)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorvisit == null)
            {
                return NotFound();
            }

            return View(doctorvisit);
        }

        // GET: Doctorvisits/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.People, "Id", "Id");
            return View();
        }

        // POST: Doctorvisits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,DoctorId,Date,SymptomsDescription,Conclusion")] Doctorvisit doctorvisit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorvisit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Employees, "Id", "Id", doctorvisit.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.People, "Id", "Id", doctorvisit.PatientId);
            return View(doctorvisit);
        }

        // GET: Doctorvisits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorvisit = await _context.Doctorvisits.FindAsync(id);
            if (doctorvisit == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Employees, "Id", "Id", doctorvisit.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.People, "Id", "Id", doctorvisit.PatientId);
            return View(doctorvisit);
        }

        // POST: Doctorvisits/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,DoctorId,Date,SymptomsDescription,Conclusion")] Doctorvisit doctorvisit)
        {
            if (id != doctorvisit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorvisit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorvisitExists(doctorvisit.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Employees, "Id", "Id", doctorvisit.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.People, "Id", "Id", doctorvisit.PatientId);
            return View(doctorvisit);
        }

        // GET: Doctorvisits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorvisit = await _context.Doctorvisits
                .Include(d => d.Doctor)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorvisit == null)
            {
                return NotFound();
            }

            return View(doctorvisit);
        }

        // POST: Doctorvisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorvisit = await _context.Doctorvisits.FindAsync(id);
            if (doctorvisit != null)
            {
                _context.Doctorvisits.Remove(doctorvisit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorvisitExists(int id)
        {
            return _context.Doctorvisits.Any(e => e.Id == id);
        }
    }
}
