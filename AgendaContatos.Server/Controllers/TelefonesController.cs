using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaContatos.Domain;
using AgendaContatos.Repository;

namespace AgendaContatos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesController : ControllerBase
    {
        private readonly AgendaContatosContext _context;

        public TelefonesController(AgendaContatosContext context)
        {
            _context = context;
        }

        // GET: api/Telefones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefones()
        {
            return await _context.Telefones
                .Include(x => x.Contato)
                .Include(x => x.Tipotelefone)
                .ToListAsync();
        }

        // GET: api/Telefones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> GetTelefone(int id)
        {
            var telefone = await _context.Telefones
                .Include(x => x.Contato)
                .Include(x => x.Tipotelefone)
                .Where(x => x.Id_Telefone == id)
                .FirstAsync();

            if (telefone == null)
            {
                return NotFound();
            }

            return telefone;
        }

        // PUT: api/Telefones/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefone(int id, Telefone telefone)
        {
            if (id != telefone.Id_Telefone)
            {
                return BadRequest();
            }

            _context.Entry(telefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(id))
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

        // POST: api/Telefones
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Telefone>> PostTelefone(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelefone", new { id = telefone.Id_Telefone }, telefone);
        }

        // DELETE: api/Telefones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Telefone>> DeleteTelefone(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }

            _context.Telefones.Remove(telefone);
            await _context.SaveChangesAsync();

            return telefone;
        }

        private bool TelefoneExists(int id)
        {
            return _context.Telefones.Any(e => e.Id_Telefone == id);
        }
    }
}
