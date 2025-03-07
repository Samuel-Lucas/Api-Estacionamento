using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.DTO;
using Estacionamento.Domain.Models.ViewModels;
using Mapster;

namespace Estacionamento.Application.UseCases;

public class PessoaUseCases : IPessoaUseCases
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaUseCases(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<IEnumerable<PessoaViewModel>> ObterPessoasUseCaseAsync()
    {
        var pessoas = await _pessoaRepository.ObterPessoasRepositoryAsync();
        var pessoaViewModelList = pessoas.Adapt<IEnumerable<PessoaViewModel>>();

        return pessoaViewModelList;
    }

    public async Task<PessoaViewModel?> ObterPessoaUseCaseAsync(string id)
    {
        var pessoa = await _pessoaRepository.ObterPessoaRepositoryAsync(id);
        return pessoa.Adapt<PessoaViewModel>();
    }

    public async Task AdicionarPessoaUseCaseAsync(PessoaDTO pessoa)
        => await _pessoaRepository.AdicionarPessoaRepositoryAsync(pessoa);

    public async Task AtualizarPessoaUseCaseAsync(PessoaUpdateDTO pessoa)
    {
        var consultaPessoa = await _pessoaRepository.ObterPessoaRepositoryAsync(pessoa.IdPessoa);
        if (consultaPessoa is null) return;

        // A Refatorar
        consultaPessoa.IdPessoa = pessoa.IdPessoa;
        consultaPessoa.Nome = pessoa.Nome;
        consultaPessoa.SobreNome = pessoa.SobreNome;
        consultaPessoa.Email = pessoa.Email;
        consultaPessoa.Telefone = pessoa.Telefone;

        await _pessoaRepository.AtualizarPessoaRepositoryAsync(consultaPessoa);
    }

    public async Task DeletarPessoaUseCaseAsync(string idPessoa)
    {
        var resultadoPessoa = await _pessoaRepository.ObterPessoaRepositoryAsync(idPessoa);
        if (resultadoPessoa is null) return;
        await _pessoaRepository.DeletarPessoaRepositoryAsync(resultadoPessoa);
    }
}