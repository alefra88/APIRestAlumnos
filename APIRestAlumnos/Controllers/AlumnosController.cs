using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIRestAlumnos.Models.Context;
using APIRestAlumnos.Models.Entities;

namespace APIRestAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnosContext _context;

        public AlumnosController(AlumnosContext context)
        {
            _context = context;
        }

        // GET: api/Alumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumnos>>> GetAlumnos()
        {
          if (_context.Alumnos == null)
          {
              return NotFound();
          }
            return await _context.Alumnos.ToListAsync();
        }

        // GET: api/Alumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumnos>> GetAlumnos(int id)
        {
          if (_context.Alumnos == null)
          {
              return NotFound();
          }
            var alumnos = await _context.Alumnos.FindAsync(id);

            if (alumnos == null)
            {
                return NotFound();
            }

            return alumnos;
        }

        // PUT: api/Alumnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumnos(int id, Alumnos alumnos)
        {
            if (id != alumnos.Id)
            {
                return BadRequest();
            }

            _context.Entry(alumnos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnosExists(id))
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

        // POST: api/Alumnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alumnos>> PostAlumnos(Alumnos alumnos)
        {
          if (_context.Alumnos == null)
          {
              return Problem("Entity set 'AlumnosContext.Alumnos'  is null.");
          }
            _context.Alumnos.Add(alumnos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumnos", new { id = alumnos.Id }, alumnos);
        }

        // DELETE: api/Alumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumnos(int id)
        {
            if (_context.Alumnos == null)
            {
                return NotFound();
            }
            var alumnos = await _context.Alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return NotFound();
            }

            _context.Alumnos.Remove(alumnos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlumnosExists(int id)
        {
            return (_context.Alumnos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
