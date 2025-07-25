using fbbn.API.DTOs;
using fbbn.API.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace fbbn.API.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("admin/login")]
        public IActionResult Login([FromBody] LoginDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.Senha))
            {
                return BadRequest("Senha é obrigatória.");
            }
            try
            {
                var token = _tokenService.Login(request);
                return Ok(token);
            }
            catch (UnauthorizedAccessException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
