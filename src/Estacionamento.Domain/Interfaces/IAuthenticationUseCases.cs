using Estacionamento.Domain.Models.Entities;

namespace Estacionamento.Domain.Interfaces;

public interface IAuthenticationUseCases
{
    Task<Pessoa> SignInUser(User user);
}