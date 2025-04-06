using Estacionamento.Domain.Models.Entities;

namespace Estacionamento.Domain.Interfaces;

public interface IAuthenticationUseCases
{
    Task<Pessoa> SignInUserAsync(User user);
    string CreateJwToken(Pessoa pessoa);
}