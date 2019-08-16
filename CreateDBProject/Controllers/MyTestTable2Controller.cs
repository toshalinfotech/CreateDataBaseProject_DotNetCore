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
    public class MyTestTable2Controller : Controller
    {
        private readonly MyDBContext _context;

        public MyTestTable2Controller(MyDBContext context)
        {
            _context = context;
        }

        // GET: MyTestTable2
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyTestTable_2.ToListAsync());
        }

        // GET: MyTestTable2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTestTable2 = await _context.MyTestTable_2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myTestTable2 == null)
            {
                return NotFound();
            }

            return View(myTestTable2);
        }

        // GET: MyTestTable2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyTestTable2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] MyTestTable2 myTestTable2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myTestTable2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myTestTable2);
        }

        // GET: MyTestTable2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTestTable2 = await _context.MyTestTable_2.FindAsync(id);
            if (myTestTable2 == null)
            {
                return NotFound();
            }
            return View(myTestTable2);
        }

        // POST: MyTestTable2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] MyTestTable2 myTestTable2)
        {
            if (id != myTestTable2.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myTestTable2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyTestTable2Exists(myTestTable2.ID))
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
            return View(myTestTable2);
        }

        // GET: MyTestTable2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTestTable2 = await _context.MyTestTable_2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myTestTable2 == null)
            {
                return NotFound();
            }

            return View(myTestTable2);
        }

        // POST: MyTestTable2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myTestTable2 = await _context.MyTestTable_2.FindAsync(id);
            _context.MyTestTable_2.Remove(myTestTable2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyTestTable2Exists(int id)
        {
            return _context.MyTestTable_2.Any(e => e.ID == id);
        }
    }
}
