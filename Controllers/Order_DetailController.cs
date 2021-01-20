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
    [Authorize]
    public class Order_DetailController : Controller
    {
        private readonly Electronic_MVCContext _context;

        public Order_DetailController(Electronic_MVCContext context)
        {
            _context = context;
        }

        // GET: Order_Detail
        public async Task<IActionResult> Index()
        {
            var electronic_MVCContext = _context.Order_Detail.Include(o => o.Customer_Detail).Include(o => o.Product_Detail);
            return View(await electronic_MVCContext.ToListAsync());
        }

        // GET: Order_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Detail
                .Include(o => o.Customer_Detail)
                .Include(o => o.Product_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            return View(order_Detail);
        }

        // GET: Order_Detail/Create
        public IActionResult Create()
        {
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name");
            ViewData["Product_DetailId"] = new SelectList(_context.Product_Detail, "Id", "Product_Name");
            return View();
        }

        // POST: Order_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,Discount,Customer_DetailId,Product_DetailId")] Order_Detail order_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name", order_Detail.Customer_DetailId);
            ViewData["Product_DetailId"] = new SelectList(_context.Product_Detail, "Id", "Product_Name", order_Detail.Product_DetailId);
            return View(order_Detail);
        }
        [Authorize]
        // GET: Order_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Detail.FindAsync(id);
            if (order_Detail == null)
            {
                return NotFound();
            }
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name", order_Detail.Customer_DetailId);
            ViewData["Product_DetailId"] = new SelectList(_context.Product_Detail, "Id", "Product_Name", order_Detail.Product_DetailId);
            return View(order_Detail);
        }

        // POST: Order_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Discount,Customer_DetailId,Product_DetailId")] Order_Detail order_Detail)
        {
            if (id != order_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_DetailExists(order_Detail.Id))
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
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name", order_Detail.Customer_DetailId);
            ViewData["Product_DetailId"] = new SelectList(_context.Product_Detail, "Id", "Product_Name", order_Detail.Product_DetailId);
            return View(order_Detail);
        }

        // GET: Order_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Detail = await _context.Order_Detail
                .Include(o => o.Customer_Detail)
                .Include(o => o.Product_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            return View(order_Detail);
        }

        // POST: Order_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order_Detail = await _context.Order_Detail.FindAsync(id);
            _context.Order_Detail.Remove(order_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_DetailExists(int id)
        {
            return _context.Order_Detail.Any(e => e.Id == id);
        }
    }
}
