using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.Entities;

namespace Estacionamento.Application.UseCases;

public class AuthenticationUseCases : IAuthenticationUseCases
{
    private readonly IPessoaRepository _pessoaRepository;

    public AuthenticationUseCases(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<Pessoa> SignInUser(User user)
    {
        var registeredUser = await _pessoaRepository.ObterPessoaPorEmaileSenhaRepositoryAsync(user.Email, user.Senha);
        return registeredUser!;
    }
}