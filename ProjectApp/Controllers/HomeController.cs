using System;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectDBContext _context;

        private UserManager<ApplicationUser> _userManager;

        public HomeController(ProjectDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(this.HttpContext.User);
            var projects = await _context.ProjectViewModel.Where(x => x.ProjectUserId
                .Equals(userId))
                .AsNoTracking()
                .ToListAsync();

            var langTypes = projects.GroupBy(x => x.Language).ToList();

            var langCount = langTypes.GroupBy(x => x).Select(x => x.Count()).ToList();

            var resultData = langTypes.GroupBy(x => x).ToDictionary(x => x.Key.Key.ToString(), x => x.Count());

            dynamic mymodel = new ExpandoObject();
            mymodel.resultData = resultData;
            mymodel.projects = projects;
            mymodel.langTypes = langTypes;
            return View(mymodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public async Task<IActionResult> _DataForCharts()

        {
            //return View(await projects.ToListAsync());

            return PartialView(await _context.ProjectViewModel.ToListAsync());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            });


        }

    }
}
