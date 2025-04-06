using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Estacionamento.Application.UseCases;

public class AuthenticationUseCases : IAuthenticationUseCases
{
    private readonly IPessoaRepository _pessoaRepository;

    public AuthenticationUseCases(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<Pessoa> SignInUserAsync(User user)
    {
        var registeredUser = await _pessoaRepository.ObterPessoaPorEmaileSenhaRepositoryAsync(user.Email, user.Senha);
        return registeredUser!;
    }

    public string CreateJwToken(Pessoa pessoa)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("veryveryveryveryverytremendoussecretkey.........");
        var identity = new ClaimsIdentity
        (
            new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, pessoa.IdPessoa),
                new Claim(ClaimTypes.Name, pessoa.Email),
                new Claim(ClaimTypes.Role, pessoa.Role!)
            }
        );

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = credentials
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        return jwtTokenHandler.WriteToken(token);
    }
}