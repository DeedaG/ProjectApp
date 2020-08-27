using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectDBContext _context;

        public HomeController(ProjectDBContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var projects = await _context.ProjectViewModel.ToListAsync();
            
            var langTypes = projects.GroupBy(x => x.Language).ToList();

            var langCount = langTypes.GroupBy(x => x).Select(x => x.Count()).ToList();

            //var chartData = langTypes.Zip(langCount, (a, b) => (a.Key, b));

            var resultData = langTypes.GroupBy(x => x).ToDictionary(x => x.Key.Key, x => x.Count());

            return View(resultData);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
