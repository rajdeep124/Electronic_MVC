using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronic_MVC.Data;
using Electronic_MVC.Models;

namespace Electronic_MVC.Controllers
{
    public class Brand_DetailController : Controller
    {
        private readonly Electronic_MVCContext _context;

        public Brand_DetailController(Electronic_MVCContext context)
        {
            _context = context;
        }

        // GET: Brand_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brand_Detail.ToListAsync());
        }

        // GET: Brand_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand_Detail = await _context.Brand_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand_Detail == null)
            {
                return NotFound();
            }

            return View(brand_Detail);
        }

        // GET: Brand_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brand_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand_Name,Brand_Branch_Location,Brand_Email")] Brand_Detail brand_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand_Detail);
        }

        // GET: Brand_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand_Detail = await _context.Brand_Detail.FindAsync(id);
            if (brand_Detail == null)
            {
                return NotFound();
            }
            return View(brand_Detail);
        }

        // POST: Brand_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand_Name,Brand_Branch_Location,Brand_Email")] Brand_Detail brand_Detail)
        {
            if (id != brand_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Brand_DetailExists(brand_Detail.Id))
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
            return View(brand_Detail);
        }

        // GET: Brand_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand_Detail = await _context.Brand_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand_Detail == null)
            {
                return NotFound();
            }

            return View(brand_Detail);
        }

        // POST: Brand_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand_Detail = await _context.Brand_Detail.FindAsync(id);
            _context.Brand_Detail.Remove(brand_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Brand_DetailExists(int id)
        {
            return _context.Brand_Detail.Any(e => e.Id == id);
        }
    }
}
