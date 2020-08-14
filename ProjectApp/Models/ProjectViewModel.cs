using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Models

{
    public class ProjectViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }
        public string Language { get; set; }
        public string Info { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
