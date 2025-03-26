using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atletica_BD;
using Atletica_Back_End.Data;

namespace Atletica_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsedChampionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsedChampionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/UsedChampions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsedChampion>>> GetUsedChampions()
        {
            return await _context.UsedChampions.ToListAsync();
        }

        // GET: api/UsedChampions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsedChampion>> GetUsedChampion(Guid id)
        {
            var usedChampion = await _context.UsedChampions.FindAsync(id);

            if (usedChampion == null)
            {
                return NotFound();
            }

            return usedChampion;
        }

        // PUT: api/UsedChampions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsedChampion(Guid id, UsedChampion usedChampion)
        {
            if (id != usedChampion.Id)
            {
                return BadRequest();
            }

            _context.Entry(usedChampion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsedChampionExists(id))
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

        // POST: api/UsedChampions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsedChampion>> PostUsedChampion(UsedChampion usedChampion)
        {
            _context.UsedChampions.Add(usedChampion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsedChampion", new { id = usedChampion.Id }, usedChampion);
        }

        // DELETE: api/UsedChampions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsedChampion(Guid id)
        {
            var usedChampion = await _context.UsedChampions.FindAsync(id);
            if (usedChampion == null)
            {
                return NotFound();
            }

            _context.UsedChampions.Remove(usedChampion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsedChampionExists(Guid id)
        {
            return _context.UsedChampions.Any(e => e.Id == id);
        }
    }
}
