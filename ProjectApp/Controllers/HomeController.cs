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
            var freqOrder = new List<string>();
            var freqData = langTypes.ToDictionary(x => x.Key.ToString(), x => x.Count());
            foreach (var item in freqData)
            {
                freqOrder.Add(@"[""" + item.Key + @"""," + item.Value + @"]");
            }
            var resultData = new List<string>();
            for (int i = 0; i < freqOrder.Count - 1; i++)
            {
                resultData.Add(freqOrder[i] + @",");
            }
            resultData.Add(freqOrder.Last());
            resultData.Insert(0, @"[""Language"", ""Frequency""],");


            var projTime = new List<KeyValuePair<string, string>>();
            foreach (var p in projects)
            {
                if (p.EndDate != null)
                {
                    TimeSpan? difference = p.EndDate - p.StartDate;
                    projTime.Add(new KeyValuePair<string, string>(p.Language.ToString(), difference.Value.TotalDays.ToString()));
                }
            }
            var resultData2 = new List<string>();
            for (int i = 0; i < projTime.Count - 1; i++)
            {
                resultData2.Add(@"[""" + projTime[i].Key + @"""," + projTime[i].Value + "]" + ",");
            }
            if (projTime.Count >= 1)
            {
                resultData2.Add(@"[""" + projTime[projTime.Count - 1].Key + @"""," + projTime[projTime.Count - 1].Value + "]");
            }
            resultData2.Insert(0, @"[""Language"", ""Days Coding""],");


            var projDates = new List<KeyValuePair<string, string>>();
            foreach (var p in projects)
            {
                if (p.EndDate == null) {
                    projDates.Add(new KeyValuePair<string, string>(p.Name.ToString(), p.StartDate?.ToString("MM/dd/yyyy")));
                }
            }
            var resultData3 = new List<string>();
                for (int i = 0; i < projDates.Count - 1; i++)
                {
                    resultData3.Add(@"[""" + projDates[i].Key + @"""," + projDates[i].Value + "]" + ",");
                }
            if (projDates.Count >= 1)
            {
                resultData3.Add(@"[""" + projDates[projDates.Count - 1].Key + @"""," + projDates[projDates.Count - 1].Value + "]");
            }
            resultData3.Insert(0, @"[""Name"", ""Start Date""],");


            dynamic mymodel = new ExpandoObject();
            mymodel.resultData = resultData;
            mymodel.resultData2 = @resultData2;
            mymodel.resultData3 = @resultData3;
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
