using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
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
            var projects = await _context.ProjectViewModel
                .Where(x => x.ProjectUserId
                .Equals(userId))
                .AsNoTracking()
                .ToListAsync();

            var langTypes = projects.GroupBy(x => x.Language).ToList();

            var resultData = langTypes.ToDictionary(x => x.Key.ToString(), x => x.Count());

            var projDates = new List<KeyValuePair<string, string>>();

            foreach (var p in projects)
            {
                projDates.Add(new KeyValuePair<string, string>(p.Name.ToString(), p.StartDate?.ToString("MM/dd/yyyy")));
            }

            var resultData2 = new List<string>();

                for (int i = 0; i < projDates.Count - 1; i++)
                {
                    resultData2.Add(@"[""" + projDates[i].Key + @"""," + projDates[i].Value + "]" + ",");
                }

            resultData2.Add(@"[""" + projDates[projects.Count - 1].Key + @"""," + projDates[projects.Count - 1].Value + "]");
            resultData2.Insert(0, @"[""Name"", ""Start Date""],");

            dynamic mymodel = new ExpandoObject();
            mymodel.resultData = resultData;
            mymodel.resultData2 = @resultData2;
            mymodel.langTypes = langTypes;
            return View(mymodel);
        }

        public IActionResult Privacy()
        {
            return View();
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
