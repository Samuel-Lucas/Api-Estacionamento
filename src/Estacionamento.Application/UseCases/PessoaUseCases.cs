using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.Entities;

namespace Estacionamento.Application.UseCases;

public class PessoaUseCases : IPessoaUseCases
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaUseCases(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<IEnumerable<Pessoa>> ObterPessoasUseCaseAsync()
        => await _pessoaRepository.ObterPessoasRepositoryAsync();

    public async Task<Pessoa?> ObterPessoaUseCaseAsync(string id)
        => await _pessoaRepository.ObterPessoaRepositoryAsync(id);

    public async Task<Pessoa> AdicionarPessoaUseCaseAsync(Pessoa pessoa)
        => await _pessoaRepository.AdicionarPessoaRepositoryAsync(pessoa);

    public async Task AtualizarPessoaUseCaseAsync(Pessoa pessoa)
    {
        var consultaPessoa = ObterPessoaUseCaseAsync(pessoa.IdPessoa).Result;
        if (consultaPessoa is null) return;

        await _pessoaRepository.AtualizarPessoaRepositoryAsync(pessoa);

    }

    public async Task DeletarPessoaUseCaseAsync(string idPessoa)
    {
        var consultaPessoa = ObterPessoaUseCaseAsync(idPessoa).Result;
        if (consultaPessoa is null) return;
        await _pessoaRepository.DeletarPessoaRepositoryAsync(idPessoa);
    }
}