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
using AgendaContatos.Server.Dtos;
using AutoMapper;

namespace AgendaContatos.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly AgendaContatosContext _context;
        private readonly IMapper _mapper;

        public EmailsController(AgendaContatosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Emails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmails()
        {
            return await _context.Emails
                //.Include(x => x.Contato)
                .ToListAsync();
        }

        // GET: api/Emails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> GetEmail(int id)
        {
            var email = await _context.Emails
                //.Include(x => x.Contato)
                .Where(x => x.Id_Email == id)
                .FirstAsync();

            if (email == null)
            {
                return NotFound();
            }

            return email;
        }

        // PUT: api/Emails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail(int id, EmailDto email)
        {
            if (id != email.Id_Email)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        // POST: api/Emails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(EmailDto emailDto)
        {
            var email = _mapper.Map<Email>(emailDto);
            email.Valido = true;
            email.DtInclusao = DateTime.Now;
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmail", new { id = email.Id_Email }, email);
        }

        // DELETE: api/Emails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Email>> DeleteEmail(int id)
        {
            var email = await _context.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            //_context.Emails.Remove(email);
            email.Valido = false;
            _context.Entry(email).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return email;
        }

        private bool EmailExists(int id)
        {
            return _context.Emails.Any(e => e.Id_Email == id);
        }
    }
}
