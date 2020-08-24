using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Models

{
    public class ProjectViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "This is a required field")]
        public string Name { get; set; }
        public string Language { get; set; }
        public string Info { get; set; }        
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}

