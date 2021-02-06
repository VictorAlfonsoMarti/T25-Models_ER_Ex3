using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T25_Models_ER_Ex3.Model;

namespace T25_Models_ER_Ex3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenesController : ControllerBase
    {
        private readonly APIContext _context;

        public AlmacenesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Almacenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Almacen>>> GetAlmacenes()
        {
            return await _context.Almacenes.ToListAsync();
        }

        // GET: api/Almacenes/5
        [HttpGet("{Codigo}")]
        public async Task<ActionResult<Almacen>> GetAlmacen(int Codigo)
        {
            var almacen = await _context.Almacenes.FindAsync(Codigo);

            if (almacen == null)
            {
                return NotFound();
            }

            return almacen;
        }

        // PUT: api/Almacenes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{Codigo}")]
        public async Task<IActionResult> PutAlmacen(int Codigo, Almacen almacen)
        {
            if (Codigo != almacen.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(almacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenExists(Codigo))
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

        // POST: api/Almacenes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Almacen>> PostAlmacen(Almacen almacen)
        {
            _context.Almacenes.Add(almacen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlmacen", new { Codigo = almacen.Codigo }, almacen);
        }

        // DELETE: api/Almacenes/5
        [HttpDelete("{Codigo}")]
        public async Task<ActionResult<Almacen>> DeleteAlmacen(int id)
        {
            var almacen = await _context.Almacenes.FindAsync(id);
            if (almacen == null)
            {
                return NotFound();
            }

            _context.Almacenes.Remove(almacen);
            await _context.SaveChangesAsync();

            return almacen;
        }

        private bool AlmacenExists(int Codigo)
        {
            return _context.Almacenes.Any(e => e.Codigo == Codigo);
        }
    }
}
