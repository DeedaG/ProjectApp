using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectDBContext _context;

        public ProjectController(ProjectDBContext context)
        {
            _context = context;
        }

        //GET: ProjectViewModel
        public async Task<IActionResult> Index()
            
        {
            return View(await _context.ProjectViewModel.ToListAsync());
        }

        //Get: Project/Create
        public IActionResult AddorEdit(int id=0)
        {
            if (id == 0)
                return View(new ProjectViewModel());
            else
                return View(_context.ProjectViewModel.Find(id));
        }

        //Post: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit(int Id, [Bind("Id,Name,Language,Info,StartDate,EndDate")] ProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                if (project.Id == 0)
                    _context.Add(project);
                else
                    _context.Update(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // Get: Project/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            var project = await _context.ProjectViewModel.FindAsync(id);
            _context.ProjectViewModel.Remove(project);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
