using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net6APIWithJWT.Models;

namespace Net6APIWithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<AppUsers>>> GetAppUsers()
        {
            return await _context.AppUsers.ToListAsync();
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AppUsers>> GetAppUsers(int id)
        {
            var appUsers = await _context.AppUsers.FindAsync(id);

            if (appUsers == null)
            {
                return NotFound();
            }

            return appUsers;
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "HRAdmin")]
        public async Task<IActionResult> PutAppUsers(int id, AppUsers appUsers)
        {
            if (id != appUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUsersExists(id))
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

        // POST: api/AppUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "HRAdmin")]
        public async Task<ActionResult<AppUsers>> PostAppUsers(AppUsers appUsers)
        {
            _context.AppUsers.Add(appUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppUsers", new { id = appUsers.Id }, appUsers);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "HRAdmin")]
        public async Task<IActionResult> DeleteAppUsers(int id)
        {
            var appUsers = await _context.AppUsers.FindAsync(id);
            if (appUsers == null)
            {
                return NotFound();
            }

            _context.AppUsers.Remove(appUsers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppUsersExists(int id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}
