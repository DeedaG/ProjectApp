using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //GET: ProjectViewModel
        public async Task<IActionResult> Details(int? id)
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

        public async Task<IActionResult> CreateAsync()
        {
            return View(await _context.ProjectViewModel.FirstOrDefaultAsync());
        }

        public async Task<IActionResult> DeleteAsync()
        {
            return View(await _context.ProjectViewModel.ToListAsync());
        }

       
        public async Task<IActionResult> EditAsync()
        {
            return View(await _context.ProjectViewModel.ToListAsync());
        }

    }
}
