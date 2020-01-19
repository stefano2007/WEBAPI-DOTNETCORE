using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaContatos.Domain;
using AgendaContatos.Repository;
using Microsoft.AspNetCore.Authorization;

namespace AgendaContatos.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipotelefonesController : ControllerBase
    {
        private readonly AgendaContatosContext _context;

        public TipotelefonesController(AgendaContatosContext context)
        {
            _context = context;
        }

        // GET: api/Tipotelefones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipotelefone>>> GetTipotelefones()
        {
            return await _context.Tipotelefones.ToListAsync();
        }

        // GET: api/Tipotelefones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipotelefone>> GetTipotelefone(int id)
        {
            var tipotelefone = await _context.Tipotelefones.FindAsync(id);

            if (tipotelefone == null)
            {
                return NotFound();
            }

            return tipotelefone;
        }

        // PUT: api/Tipotelefones/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipotelefone(int id, Tipotelefone tipotelefone)
        {
            if (id != tipotelefone.Id_Tipotelefone)
            {
                return BadRequest();
            }

            _context.Entry(tipotelefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipotelefoneExists(id))
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

        // POST: api/Tipotelefones
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tipotelefone>> PostTipotelefone(Tipotelefone tipotelefone)
        {
            _context.Tipotelefones.Add(tipotelefone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipotelefone", new { id = tipotelefone.Id_Tipotelefone }, tipotelefone);
        }

        // DELETE: api/Tipotelefones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tipotelefone>> DeleteTipotelefone(int id)
        {
            var tipotelefone = await _context.Tipotelefones.FindAsync(id);
            if (tipotelefone == null)
            {
                return NotFound();
            }

            _context.Tipotelefones.Remove(tipotelefone);
            await _context.SaveChangesAsync();

            return tipotelefone;
        }

        private bool TipotelefoneExists(int id)
        {
            return _context.Tipotelefones.Any(e => e.Id_Tipotelefone == id);
        }
    }
}
