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
    public class Product_DetailController : Controller
    {
        private readonly Electronic_MVCContext _context;

        public Product_DetailController(Electronic_MVCContext context)
        {
            _context = context;
        }

        // GET: Product_Detail
        public async Task<IActionResult> Index()
        {
            var electronic_MVCContext = _context.Product_Detail.Include(p => p.Brand_Detail).Include(p => p.Category_Detail);
            return View(await electronic_MVCContext.ToListAsync());
        }

        // GET: Product_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Detail = await _context.Product_Detail
                .Include(p => p.Brand_Detail)
                .Include(p => p.Category_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_Detail == null)
            {
                return NotFound();
            }

            return View(product_Detail);
        }
        [Authorize]
        // GET: Product_Detail/Create
        public IActionResult Create()
        {
            ViewData["Brand_DetailId"] = new SelectList(_context.Brand_Detail, "Id", "Brand_Name");
            ViewData["Category_DetailId"] = new SelectList(_context.Category_Detail, "Id", "Product");
            return View();
        }

        // POST: Product_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product_Name,Price,Brand_DetailId,Category_DetailId")] Product_Detail product_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Brand_DetailId"] = new SelectList(_context.Brand_Detail, "Id", "Brand_Name", product_Detail.Brand_DetailId);
            ViewData["Category_DetailId"] = new SelectList(_context.Category_Detail, "Id", "Product", product_Detail.Category_DetailId);
            return View(product_Detail);
        }
        [Authorize]
        // GET: Product_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Detail = await _context.Product_Detail.FindAsync(id);
            if (product_Detail == null)
            {
                return NotFound();
            }
            ViewData["Brand_DetailId"] = new SelectList(_context.Brand_Detail, "Id", "Brand_Name", product_Detail.Brand_DetailId);
            ViewData["Category_DetailId"] = new SelectList(_context.Category_Detail, "Id", "Product", product_Detail.Category_DetailId);
            return View(product_Detail);
        }

        // POST: Product_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product_Name,Price,Brand_DetailId,Category_DetailId")] Product_Detail product_Detail)
        {
            if (id != product_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_DetailExists(product_Detail.Id))
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
            ViewData["Brand_DetailId"] = new SelectList(_context.Brand_Detail, "Id", "Brand_Name", product_Detail.Brand_DetailId);
            ViewData["Category_DetailId"] = new SelectList(_context.Category_Detail, "Id", "Product", product_Detail.Category_DetailId);
            return View(product_Detail);
        }
        [Authorize]
        // GET: Product_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Detail = await _context.Product_Detail
                .Include(p => p.Brand_Detail)
                .Include(p => p.Category_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_Detail == null)
            {
                return NotFound();
            }

            return View(product_Detail);
        }

        // POST: Product_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_Detail = await _context.Product_Detail.FindAsync(id);
            _context.Product_Detail.Remove(product_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_DetailExists(int id)
        {
            return _context.Product_Detail.Any(e => e.Id == id);
        }
    }
}
