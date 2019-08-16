using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CreateDataBaseProject_DotNetCore.Models;

namespace CreateDataBaseProject_DotNetCore.Controllers
{
    public class MyTestTable1Controller : Controller
    {
        private readonly MyDBContext _context;

        public MyTestTable1Controller(MyDBContext context)
        {
            _context = context;
        }

        // GET: MyTestTable1
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyTestTable_1.ToListAsync());
        }

        // GET: MyTestTable1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTestTable1 = await _context.MyTestTable_1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myTestTable1 == null)
            {
                return NotFound();
            }

            return View(myTestTable1);
        }

        // GET: MyTestTable1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyTestTable1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] MyTestTable1 myTestTable1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myTestTable1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myTestTable1);
        }

        // GET: MyTestTable1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTestTable1 = await _context.MyTestTable_1.FindAsync(id);
            if (myTestTable1 == null)
            {
                return NotFound();
            }
            return View(myTestTable1);
        }

        // POST: MyTestTable1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] MyTestTable1 myTestTable1)
        {
            if (id != myTestTable1.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myTestTable1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyTestTable1Exists(myTestTable1.ID))
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
            return View(myTestTable1);
        }

        // GET: MyTestTable1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTestTable1 = await _context.MyTestTable_1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myTestTable1 == null)
            {
                return NotFound();
            }

            return View(myTestTable1);
        }

        // POST: MyTestTable1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myTestTable1 = await _context.MyTestTable_1.FindAsync(id);
            _context.MyTestTable_1.Remove(myTestTable1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyTestTable1Exists(int id)
        {
            return _context.MyTestTable_1.Any(e => e.ID == id);
        }
    }
}
