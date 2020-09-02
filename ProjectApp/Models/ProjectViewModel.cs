using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectApp.Models

{
    public class ProjectViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This is a required field")]
        public string Name { get; set; }
        public string Language { get; set; }
        public string Info { get; set; }
        //[DisplayFormat(DataFormatString = "{dd.MM.yyyy}")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ApplicationUser ProjectUser { get; set; }
        public string ProjectUserId { get; set; }
        public ChartData ProjectData { get; set; }
        public int ProjectDataId { get; set; }

        //[NotMapped]
        //public bool checkboxAnswer { get; set; }
    }
}
