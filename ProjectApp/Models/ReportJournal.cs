using System;
using System.Collections.Generic;
using ProjectApp.Models;

namespace ProjectApp.Models
{
    public class ReportJournal
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public bool NameChange { get; set; }
        public string ProjLanguage { get; set; }
        public bool LanguageChange { get; set; }
        public int? DevTime { get; set; }
        public int? ChangeCount { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
    }
}