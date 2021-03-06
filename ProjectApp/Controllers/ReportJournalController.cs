using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

namespace ProjectApp.Controllers
{
    public class ReportJournalController : Controller
    {
        private readonly ProjectDBContext _context;

        public ReportJournalController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: ReportJournal
        public async Task<IActionResult> Index()
        {
            var reports = await _context.ReportJournal.AsNoTracking().ToListAsync();
            var reports1 = new List<ProjectApp.Models.ReportJournal>();
            foreach (var item in reports)
            {
                if (item.DevTime.Equals(null))
                {
                    item.DevTime = 0;
                }
                reports1.Add(item);
            }
            return View(reports1);
        }

        // GET: ReportJournal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportJournal = await _context.ReportJournal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportJournal == null)
            {
                return NotFound();
            }

            return View(reportJournal);
        }

        // GET: ReportJournal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportJournal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Author,NameChange,ProjLanguage,LanguageChange,DevTime,ChangeCount")] ReportJournal reportJournal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportJournal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportJournal);
        }

        // GET: ReportJournal/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var reportJournal = await _context.ReportJournal.FindAsync(id);
        //    if (reportJournal == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(reportJournal);
        //}

        // POST: ReportJournal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Author,NameChange,ProjLanguage,LanguageChange,DevTime,ChangeCount")] ReportJournal reportJournal)
        //{
        //    if (id != reportJournal.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(reportJournal);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReportJournalExists(reportJournal.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(reportJournal);
        //}

        //// GET: ReportJournal/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var reportJournal = await _context.ReportJournal
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (reportJournal == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(reportJournal);
        //}

        //// POST: ReportJournal/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var reportJournal = await _context.ReportJournal.FindAsync(id);
        //    _context.ReportJournal.Remove(reportJournal);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ReportJournalExists(int id)
        {
            return _context.ReportJournal.Any(e => e.Id == id);
        }
    }
}
