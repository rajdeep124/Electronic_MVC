using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronic_MVC.Data;
using Electronic_MVC.Models;
using Microsoft.AspNetCore.Authorization;


namespace Electronic_MVC.Controllers
{
    public class Category_DetailController : Controller
    {
        private readonly Electronic_MVCContext _context;

        public Category_DetailController(Electronic_MVCContext context)
        {
            _context = context;
        }

        // GET: Category_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category_Detail.ToListAsync());
        }

        // GET: Category_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category_Detail = await _context.Category_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category_Detail == null)
            {
                return NotFound();
            }

            return View(category_Detail);
        }
        [Authorize]
        // GET: Category_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Category_Type")] Category_Detail category_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category_Detail);
        }
        [Authorize]
        // GET: Category_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category_Detail = await _context.Category_Detail.FindAsync(id);
            if (category_Detail == null)
            {
                return NotFound();
            }
            return View(category_Detail);
        }

        // POST: Category_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Category_Type")] Category_Detail category_Detail)
        {
            if (id != category_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Category_DetailExists(category_Detail.Id))
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
            return View(category_Detail);
        }
        [Authorize]
        // GET: Category_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category_Detail = await _context.Category_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category_Detail == null)
            {
                return NotFound();
            }

            return View(category_Detail);
        }

        // POST: Category_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category_Detail = await _context.Category_Detail.FindAsync(id);
            _context.Category_Detail.Remove(category_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Category_DetailExists(int id)
        {
            return _context.Category_Detail.Any(e => e.Id == id);
        }
    }
}
