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
    public class Customer_DetailController : Controller
    {
        private readonly Electronic_MVCContext _context;

        public Customer_DetailController(Electronic_MVCContext context)
        {
            _context = context;
        }

        // GET: Customer_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer_Detail.ToListAsync());
        }

        // GET: Customer_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer_Detail = await _context.Customer_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer_Detail == null)
            {
                return NotFound();
            }

            return View(customer_Detail);
        }

        // GET: Customer_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Customer_Name,Email,Phone,Delivery_Address")] Customer_Detail customer_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer_Detail);
        }

        // GET: Customer_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer_Detail = await _context.Customer_Detail.FindAsync(id);
            if (customer_Detail == null)
            {
                return NotFound();
            }
            return View(customer_Detail);
        }

        // POST: Customer_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Customer_Name,Email,Phone,Delivery_Address")] Customer_Detail customer_Detail)
        {
            if (id != customer_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customer_DetailExists(customer_Detail.Id))
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
            return View(customer_Detail);
        }

        // GET: Customer_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer_Detail = await _context.Customer_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer_Detail == null)
            {
                return NotFound();
            }

            return View(customer_Detail);
        }

        // POST: Customer_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer_Detail = await _context.Customer_Detail.FindAsync(id);
            _context.Customer_Detail.Remove(customer_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Customer_DetailExists(int id)
        {
            return _context.Customer_Detail.Any(e => e.Id == id);
        }
    }
}
