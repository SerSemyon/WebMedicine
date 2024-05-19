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
    public class MedicationprescriptionsController : Controller
    {
        private readonly MedicineContext _context;

        public MedicationprescriptionsController(MedicineContext context)
        {
            _context = context;
        }

        // GET: Medicationprescriptions
        public async Task<IActionResult> Index()
        {
            var medicineContext = _context.Medicationprescriptions.Include(m => m.Medication).Include(m => m.Treatment);
            return View(await medicineContext.ToListAsync());
        }

        // GET: Medicationprescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationprescription = await _context.Medicationprescriptions
                .Include(m => m.Medication)
                .Include(m => m.Treatment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicationprescription == null)
            {
                return NotFound();
            }

            return View(medicationprescription);
        }

        // GET: Medicationprescriptions/Create
        public IActionResult Create()
        {
            ViewData["MedicationId"] = new SelectList(_context.Medicationcatalogs, "Id", "Id");
            ViewData["TreatmentId"] = new SelectList(_context.Treatments, "Id", "Id");
            return View();
        }

        // POST: Medicationprescriptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MedicationId,TreatmentId,Duration")] Medicationprescription medicationprescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationprescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicationId"] = new SelectList(_context.Medicationcatalogs, "Id", "Id", medicationprescription.MedicationId);
            ViewData["TreatmentId"] = new SelectList(_context.Treatments, "Id", "Id", medicationprescription.TreatmentId);
            return View(medicationprescription);
        }

        // GET: Medicationprescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationprescription = await _context.Medicationprescriptions.FindAsync(id);
            if (medicationprescription == null)
            {
                return NotFound();
            }
            ViewData["MedicationId"] = new SelectList(_context.Medicationcatalogs, "Id", "Id", medicationprescription.MedicationId);
            ViewData["TreatmentId"] = new SelectList(_context.Treatments, "Id", "Id", medicationprescription.TreatmentId);
            return View(medicationprescription);
        }

        // POST: Medicationprescriptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MedicationId,TreatmentId,Duration")] Medicationprescription medicationprescription)
        {
            if (id != medicationprescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationprescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationprescriptionExists(medicationprescription.Id))
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
            ViewData["MedicationId"] = new SelectList(_context.Medicationcatalogs, "Id", "Id", medicationprescription.MedicationId);
            ViewData["TreatmentId"] = new SelectList(_context.Treatments, "Id", "Id", medicationprescription.TreatmentId);
            return View(medicationprescription);
        }

        // GET: Medicationprescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationprescription = await _context.Medicationprescriptions
                .Include(m => m.Medication)
                .Include(m => m.Treatment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicationprescription == null)
            {
                return NotFound();
            }

            return View(medicationprescription);
        }

        // POST: Medicationprescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicationprescription = await _context.Medicationprescriptions.FindAsync(id);
            if (medicationprescription != null)
            {
                _context.Medicationprescriptions.Remove(medicationprescription);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationprescriptionExists(int id)
        {
            return _context.Medicationprescriptions.Any(e => e.Id == id);
        }
    }
}
