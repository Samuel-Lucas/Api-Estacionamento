using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.DTO;
using Estacionamento.Domain.Models.ViewModels;

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
        var pessoaViewModelList = new List<PessoaViewModel>();
        var pessoas = await _pessoaRepository.ObterPessoasRepositoryAsync();

        foreach (var pessoa in pessoas)
        {
            var pessoaViewModel = new PessoaViewModel(pessoa.IdPessoa, pessoa.Nome, pessoa.SobreNome, pessoa.Email, pessoa.Telefone);
            pessoaViewModelList.Add(pessoaViewModel);
        }

        return pessoaViewModelList;
    }

    public async Task<PessoaViewModel?> ObterPessoaUseCaseAsync(string id)
    {
        var pessoa = await _pessoaRepository.ObterPessoaRepositoryAsync(id);

        return new PessoaViewModel(pessoa!.IdPessoa, pessoa.Nome, pessoa.SobreNome, pessoa.Email, pessoa.Telefone);
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