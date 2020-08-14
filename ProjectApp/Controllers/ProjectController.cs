using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(new ProjectViewModel());
        }

        //Post: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit(int id, [Bind("Id,Name,Language,Info,StartDate,EndDate")] ProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // Get: Project/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.ProjectViewModel.FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

    }
}
