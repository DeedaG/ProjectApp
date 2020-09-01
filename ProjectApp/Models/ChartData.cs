using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectApp.Models
{
    public class ChartData
    {
        public int Id { get; set; }
        public List<ProjectViewModel> DataForProjects { get; set; }
        public ApplicationUser ChartUser { get; set; }
        public string ChartUserId { get; set; }
        //public Dictionary<string, DateTime?> StartDateData { get; set; }
        //public Dictionary<string, int> DayCountData { get; set; }
        //public Dictionary<string, int> FrequencyData { get; set; }
    }
}
