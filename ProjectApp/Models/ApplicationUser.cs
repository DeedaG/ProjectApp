
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProjectApp.Models

{
    public class ApplicationUser : IdentityUser
    {
        public List<ProjectViewModel> Projects { get; set; }
        public List<ChartData> Charts { get; set; }
    }
}

