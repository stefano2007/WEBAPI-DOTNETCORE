using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaContatos.Server.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _userService;

        public LoginController(ILoginService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody]UsuarioLoginDto userParam)
        {
            try
            {
                var userToken = await _userService.Authenticate(userParam);

                if (userToken == null)
                    return BadRequest(new { message = "Usuário ou senha incorreta." });

                return Ok(userToken);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }
    }
}