using System;
using Microsoft.EntityFrameworkCore;

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
                    Language = "Test1",
                    Info = "test1",
                    StartDate = null,
                    EndDate = null,
                    //ProjectUserId = "1",
                    ProjectDataId = 1
                },

            new ProjectViewModel
            {
                Id = 2,
                Name = "Test2",
                Language = "Test2",
                Info = "test2",
                StartDate = null,
                EndDate = null,
                //ProjectUserId = "1",
                ProjectDataId = 1
            });

            modelBuilder.Entity<ChartData>().HasData(
                new ChartData
                {
                    Id = 1,
                    //ChartUserId = "1"
                });
        }
    }
}
