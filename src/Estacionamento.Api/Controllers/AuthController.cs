using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers;

[ApiController]
[Route("api/[controller]/v1")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationUseCases _authenticationUseCases;

    public AuthController(IAuthenticationUseCases authenticationUseCases)
    {
        _authenticationUseCases = authenticationUseCases;
    }

    [HttpPost("Authenticate")]
    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    public async Task<IActionResult> Authenticate([FromBody] User user)
    {
        if (user is null)
            return BadRequest("Dados do usuário não informado");

        var registeredUser = await _authenticationUseCases.SignInUserAsync(user);

        if (registeredUser is null)
            return NotFound("Usuário não cadastrado");
        
        var jwtToken = _authenticationUseCases.CreateJwToken(registeredUser);
        
        return Ok
        (
            new 
            {
                Token = jwtToken,
                Message = "Usuário autenticado"
            }
        );
    }
}