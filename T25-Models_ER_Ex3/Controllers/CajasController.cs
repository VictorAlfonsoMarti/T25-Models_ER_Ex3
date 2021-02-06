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
    public class CajasController : ControllerBase
    {
        private readonly APIContext _context;

        public CajasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caja>>> GetCajas()
        {
            return await _context.Cajas.ToListAsync();
        }

        // GET: api/Cajas/5
        [HttpGet("{NumReferencia}")]
        public async Task<ActionResult<Caja>> GetCaja(string NumReferencia)
        {
            var caja = await _context.Cajas.FindAsync(NumReferencia);

            if (caja == null)
            {
                return NotFound();
            }

            return caja;
        }

        // PUT: api/Cajas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{NumReferencia}")]
        public async Task<IActionResult> PutCaja(string NumReferencia, Caja caja)
        {
            if (NumReferencia != caja.NumReferencia)
            {
                return BadRequest();
            }

            _context.Entry(caja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajaExists(NumReferencia))
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

        // POST: api/Cajas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Caja>> PostCaja(Caja caja)
        {
            _context.Cajas.Add(caja);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CajaExists(caja.NumReferencia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCaja", new { id = caja.NumReferencia }, caja);
        }

        // DELETE: api/Cajas/5
        [HttpDelete("{NumReferencia}")]
        public async Task<ActionResult<Caja>> DeleteCaja(string NumReferencia)
        {
            var caja = await _context.Cajas.FindAsync(NumReferencia);
            if (caja == null)
            {
                return NotFound();
            }

            _context.Cajas.Remove(caja);
            await _context.SaveChangesAsync();

            return caja;
        }

        private bool CajaExists(string NumReferencia)
        {
            return _context.Cajas.Any(e => e.NumReferencia == NumReferencia);
        }
    }
}
