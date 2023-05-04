﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTemp.Models;

namespace WebTemp.Controllers
{
    public class ShippersController : Controller
    {
        private readonly NorthwindContext _context;

        public ShippersController(NorthwindContext context)
        {
            _context = context;
        }

        //public ShippersController()
        //{
        //    _context =new NorthwindContext();
        //}

        // GET: Shippers
        public async Task<IActionResult> Index()
        {
              return _context.Shippers != null ? 
                          View(await _context.Shippers.ToListAsync()) :
                          Problem("Entity set 'NorthwindContext.Shippers'  is null.");
        }

        // GET: Shippers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shippers == null)
            {
                return NotFound();
            }

            var shippers = await _context.Shippers
                .FirstOrDefaultAsync(m => m.ShipperId == id);
            if (shippers == null)
            {
                return NotFound();
            }

            return View(shippers);
        }

        // GET: Shippers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shippers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipperId,CompanyName,Phone")] Shippers shippers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shippers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shippers);
        }

        // GET: Shippers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shippers == null)
            {
                return NotFound();
            }

            var shippers = await _context.Shippers.FindAsync(id);
            if (shippers == null)
            {
                return NotFound();
            }
            return View(shippers);
        }

        // POST: Shippers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipperId,CompanyName,Phone")] Shippers shippers)
        {
            if (id != shippers.ShipperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shippers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippersExists(shippers.ShipperId))
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
            return View(shippers);
        }

        // GET: Shippers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shippers == null)
            {
                return NotFound();
            }

            var shippers = await _context.Shippers
                .FirstOrDefaultAsync(m => m.ShipperId == id);
            if (shippers == null)
            {
                return NotFound();
            }

            return View(shippers);
        }

        // POST: Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shippers == null)
            {
                return Problem("Entity set 'NorthwindContext.Shippers'  is null.");
            }
            var shippers = await _context.Shippers.FindAsync(id);
            if (shippers != null)
            {
                _context.Shippers.Remove(shippers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippersExists(int id)
        {
          return (_context.Shippers?.Any(e => e.ShipperId == id)).GetValueOrDefault();
        }
    }
}
