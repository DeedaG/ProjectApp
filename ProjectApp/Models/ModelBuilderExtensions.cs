//using System;
using System;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

namespace ProjectApp.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectViewModel>().HasData(
                new ProjectViewModel
                {
                    Id = 1,
                    Name = "Test1",
                    Language = "Ruby",
                    Info = "test1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    ProjectUserId = "93879f86-de21-4285-8b8f-2f76770859cc",
                    ProjectDataId = 1
                },

            new ProjectViewModel
            {
                Id = 2,
                Name = "Test2",
                Language = "React",
                Info = "test2",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ProjectUserId = "93879f86-de21-4285-8b8f-2f76770859cc",
                ProjectDataId = 1
            },

            new ProjectViewModel
            {
                Id = 3,
                Name = "Test3",
                Language = "C#",
                Info = "test2",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ProjectUserId = "93879f86-de21-4285-8b8f-2f76770859cc",
                ProjectDataId = 1
            });

            modelBuilder.Entity<ChartData>().HasData(
                new ChartData
                {
                    Id = 1,
                    ChartUserId = "93879f86-de21-4285-8b8f-2f76770859cc"
                });
        }
    }
}
