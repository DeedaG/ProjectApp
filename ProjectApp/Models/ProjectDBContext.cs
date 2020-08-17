using Microsoft.EntityFrameworkCore;

public class ProjectDBContext : DbContext
{
    public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
        : base(options)
    {
    }

    public DbSet<ProjectApp.Models.ProjectViewModel> ProjectViewModel { get; set; }
}