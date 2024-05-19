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
    public class InventoryresultsController : Controller
    {
        private readonly MedicineContext _context;

        public InventoryresultsController(MedicineContext context)
        {
            _context = context;
        }

        // GET: Inventoryresults
        public async Task<IActionResult> Index()
        {
            var medicineContext = _context.Inventoryresults.Include(i => i.Equipment).Include(i => i.Inventory);
            return View(await medicineContext.ToListAsync());
        }

        // GET: Inventoryresults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryresult = await _context.Inventoryresults
                .Include(i => i.Equipment)
                .Include(i => i.Inventory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryresult == null)
            {
                return NotFound();
            }

            return View(inventoryresult);
        }

        // GET: Inventoryresults/Create
        public IActionResult Create()
        {
            ViewData["EquipmentId"] = new SelectList(_context.Equipment, "Id", "Id");
            ViewData["InventoryId"] = new SelectList(_context.Inventories, "Id", "Id");
            return View();
        }

        // POST: Inventoryresults/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InventoryId,EquipmentId,EquipmentPresence,Description")] Inventoryresult inventoryresult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryresult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipment, "Id", "Id", inventoryresult.EquipmentId);
            ViewData["InventoryId"] = new SelectList(_context.Inventories, "Id", "Id", inventoryresult.InventoryId);
            return View(inventoryresult);
        }

        // GET: Inventoryresults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryresult = await _context.Inventoryresults.FindAsync(id);
            if (inventoryresult == null)
            {
                return NotFound();
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipment, "Id", "Id", inventoryresult.EquipmentId);
            ViewData["InventoryId"] = new SelectList(_context.Inventories, "Id", "Id", inventoryresult.InventoryId);
            return View(inventoryresult);
        }

        // POST: Inventoryresults/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InventoryId,EquipmentId,EquipmentPresence,Description")] Inventoryresult inventoryresult)
        {
            if (id != inventoryresult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryresult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryresultExists(inventoryresult.Id))
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
            ViewData["EquipmentId"] = new SelectList(_context.Equipment, "Id", "Id", inventoryresult.EquipmentId);
            ViewData["InventoryId"] = new SelectList(_context.Inventories, "Id", "Id", inventoryresult.InventoryId);
            return View(inventoryresult);
        }

        // GET: Inventoryresults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryresult = await _context.Inventoryresults
                .Include(i => i.Equipment)
                .Include(i => i.Inventory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryresult == null)
            {
                return NotFound();
            }

            return View(inventoryresult);
        }

        // POST: Inventoryresults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryresult = await _context.Inventoryresults.FindAsync(id);
            if (inventoryresult != null)
            {
                _context.Inventoryresults.Remove(inventoryresult);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryresultExists(int id)
        {
            return _context.Inventoryresults.Any(e => e.Id == id);
        }
    }
}
