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
using AutoMapper;

namespace AgendaContatos.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly AgendaContatosContext _context;
        private readonly IMapper _mapper;
        private int _idUsuario;

        public ContatosController(AgendaContatosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        // GET: api/Contatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetContatos()
        {
            _idUsuario = Convert.ToInt32(User.Identity.Name);
            return await _context.Contatos
                .Where(x => x.Ativo == true && x.Id_Usuario == _idUsuario)
                .Include(x => x.Usuario)
                .Include(x => x.Emails)
                .Include(x => x.Telefones)
                .ToListAsync();
        }

        
        // GET: api/Contatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetContato(int id)
        {
            _idUsuario = Convert.ToInt32(User.Identity.Name);
            var contato = await _context.Contatos
                .Where(x => x.Ativo == true && x.Id_Contato == id && x.Id_Usuario == _idUsuario)
                .Include(x => x.Usuario)
                .Include(x => x.Emails)
                .Include(x => x.Telefones)
                .FirstAsync();

            if (contato == null)
            {
                return NotFound();
            }

            return contato;
        }
        
        // PUT: api/Contatos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContato(int id, Contato contato)
        {
            if (id != contato.Id_Contato)
            {
                return BadRequest();
            }

            _context.Entry(contato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(id))
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

        // POST: api/Contatos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Contato>> PostContato(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContato", new { id = contato.Id_Contato }, contato);
        }

        // DELETE: api/Contatos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contato>> DeleteContato(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }

            //_context.Contatos.Remove(contato);
            contato.Ativo = false;
            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return contato;
        }

        private bool ContatoExists(int id)
        {
            return _context.Contatos.Any(e => e.Id_Contato == id);
        }
    }
}
