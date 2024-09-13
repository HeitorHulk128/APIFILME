using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIFILME.Data;
using APIFILME.models;

namespace APIFILME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FILMEsController : ControllerBase
    {
        private readonly DbFilmesContext _context;

        public FILMEsController(DbFilmesContext context)
        {
            _context = context;
        }

        // GET: api/FILMEs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FILME>>> GetFILME()
        {
          if (_context.FILME == null)
          {
              return NotFound();
          }
            return await _context.FILME.ToListAsync();
        }

        // GET: api/FILMEs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FILME>> GetFILME(int id)
        {
          if (_context.FILME == null)
          {
              return NotFound();
          }
            var fILME = await _context.FILME.FindAsync(id);

            if (fILME == null)
            {
                return NotFound();
            }

            return fILME;
        }

        // PUT: api/FILMEs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFILME(int id, FILME fILME)
        {
            if (id != fILME.Id)
            {
                return BadRequest();
            }

            _context.Entry(fILME).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FILMEExists(id))
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

        // POST: api/FILMEs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FILME>> PostFILME(FILME fILME)
        {
          if (_context.FILME == null)
          {
              return Problem("Entity set 'DbFilmesContext.FILME'  is null.");
          }
            _context.FILME.Add(fILME);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFILME", new { id = fILME.Id }, fILME);
        }

        // DELETE: api/FILMEs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFILME(int id)
        {
            if (_context.FILME == null)
            {
                return NotFound();
            }
            var fILME = await _context.FILME.FindAsync(id);
            if (fILME == null)
            {
                return NotFound();
            }

            _context.FILME.Remove(fILME);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FILMEExists(int id)
        {
            return (_context.FILME?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
