using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

namespace ProjectApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProject : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public ApiProject(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/ApiProject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectViewModel>>> GetProjectViewModel()
        {
            return await _context.ProjectViewModel.ToListAsync();
        }

        // GET: api/ApiProject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectViewModel>> GetProjectViewModel(int id)
        {
            var projectViewModel = await _context.ProjectViewModel.FindAsync(id);

            if (projectViewModel == null)
            {
                return NotFound();
            }

            return projectViewModel;
        }

        // PUT: api/ApiProject/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectViewModel(int id, ProjectViewModel projectViewModel)
        {
            if (id != projectViewModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiProject
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectViewModel>> PostProjectViewModel(ProjectViewModel projectViewModel)
        {
            _context.ProjectViewModel.Add(projectViewModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectViewModel", new { id = projectViewModel.Id }, projectViewModel);
        }

        // DELETE: api/ApiProject/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectViewModel>> DeleteProjectViewModel(int id)
        {
            var projectViewModel = await _context.ProjectViewModel.FindAsync(id);
            if (projectViewModel == null)
            {
                return NotFound();
            }

            _context.ProjectViewModel.Remove(projectViewModel);
            await _context.SaveChangesAsync();

            return projectViewModel;
        }

        private bool ProjectViewModelExists(int id)
        {
            return _context.ProjectViewModel.Any(e => e.Id == id);
        }
    }
}
