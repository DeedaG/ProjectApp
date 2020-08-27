using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

public class ProjectDBContext : DbContext
{
    public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
        : base(options)
    {
    }

    public DbSet<ProjectApp.Models.ProjectViewModel> ProjectViewModel { get; set; }
    public DbSet<ProjectApp.Models.ChartData> ChartData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
}