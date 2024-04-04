using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api6969.Context;
using api6969.Models;

namespace api6969.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Carro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarros()
        {
          if (_context.carros == null)
          {
              return NotFound();
          }
            return await _context.carros.ToListAsync();
        }

        // GET: api/Carro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarro(string id)
        {
          if (_context.carros == null)
          {
              return NotFound();
          }
            var carro = await _context.carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        // PUT: api/Carro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(string id, Carro carro)
        {
            if (id != carro.chassi)
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
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

        // POST: api/Carro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
          if (_context.carros == null)
          {
              return Problem("Entity set 'AppDbContext.Carros'  is null.");
          }
            _context.carros.Add(carro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarroExists(carro.chassi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarro", new { id = carro.chassi }, carro);
        }

        // DELETE: api/Carro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(string id)
        {
            if (_context.carros == null)
            {
                return NotFound();
            }
            var carro = await _context.carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.carros.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(string id)
        {
            return (_context.carros?.Any(e => e.chassi == id)).GetValueOrDefault();
        }
    }
}
