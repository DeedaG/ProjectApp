using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectDBContext _context;

        private UserManager<ApplicationUser> _userManager;

        public ProjectController(ProjectDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //GET: ProjectViewModel
        public async Task<IActionResult> Index(string searchString)
            
        {
            var projects = from p in _context.ProjectViewModel
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(s => s.Name.Contains(searchString) || s.Language.Contains(searchString));
            }

            //return View(await projects.ToListAsync());

            return View(await _context.ProjectViewModel.ToListAsync());
        }


        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        //Get: Project/Create
        [Authorize]
        public IActionResult AddorEdit(int id=0)
        {
            if (id == 0)
                return View(new ProjectViewModel());
            else
                return View(_context.ProjectViewModel.Find(id));
        }

        //Post: Project/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit(int Id,
            [Bind("Id,Name,Language,Info,StartDate,EndDate,ProjectDataId")]
            ProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                if (project.Id == 0)
                {
                    var userId = _userManager.GetUserId(this.HttpContext.User);
                    project.ProjectUserId = userId;

                    var allChartData = _context.ChartData;
                       
                    foreach (var c in allChartData)
                    {
                        if (userId == c.ChartUserId)
                        {
                            project.ProjectDataId = c.Id;
                            //c.DataForProjects.Add(project);

                            _context.Update(project);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            var newChartData = new ChartData
                            {
                                ChartUserId = userId
                            };
                            
                            //newChartData.DataForProjects.Add(project);
                            _context.Add(project);
                            //_context.Update(chartData)
                            _context.Add(newChartData);
                            await _context.SaveChangesAsync();
                            project.ProjectDataId = newChartData.Id;
                        }
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    _context.Update(project);
                    //_context.Update(chart);
                    await _context.SaveChangesAsync();
                }
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
