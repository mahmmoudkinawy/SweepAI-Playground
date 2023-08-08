using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweepAI_Playground.Data;
using SweepAI_Playground.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweepAI_Playground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly EntityContext _context;

        public EntityController(EntityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Entity>> Get()
        {
            return await _context.Entities.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Entity>> Post(Entity entity)
        {
            _context.Entities.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Entity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Entities.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}