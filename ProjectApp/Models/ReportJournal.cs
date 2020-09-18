using System;
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
        public int ShortTime { get; set; }
        public int LongTime { get; set; }
    }
}