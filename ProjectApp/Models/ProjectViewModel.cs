using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectApp.Models

{
    public class ProjectViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [ReadOnly(true)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string Language { get; set; }
        public string Info { get; set; }
        //[DisplayFormat(DataFormatString = "{dd.MM.yyyy}")]
        [Required(ErrorMessage = "This is a required field")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ApplicationUser ProjectUser { get; set; }
        [ReadOnly(true)]
        [ScaffoldColumn(false)]
        public string ProjectUserId { get; set; }
        public ChartData ProjectData { get; set; }
        [ReadOnly(true)]
        [ScaffoldColumn(false)]
        public int ProjectDataId { get; set; }
        public ReportJournal Report { get; set; }
        [ReadOnly(true)]
        [ScaffoldColumn(false)]
        public int ReportJournalId { get; set; }

        //[NotMapped]
        //public bool checkboxAnswer { get; set; }
    }
}
