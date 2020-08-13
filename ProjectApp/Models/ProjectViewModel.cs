using System;
namespace ProjectApp.Models

{
    public class ProjectViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }  
        string Name { get; set; }
        string Language { get; set; }
        string Info { get; set; }
        DateTime? StartDate { get; set; }
        DateTime? EndDate { get; set; }
    }
}
