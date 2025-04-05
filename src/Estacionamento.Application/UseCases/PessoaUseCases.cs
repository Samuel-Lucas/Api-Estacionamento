using Estacionamento.Domain.Interfaces;
using Estacionamento.Domain.Models.DTO;
using Estacionamento.Domain.Models.ViewModels;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Estacionamento.Application.UseCases;

public class PessoaUseCases : IPessoaUseCases
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly ILogger<PessoaUseCases> _logger;

    public PessoaUseCases(IPessoaRepository pessoaRepository, ILogger<PessoaUseCases> logger)
    {
        _pessoaRepository = pessoaRepository;
        _logger = logger;
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
    {
        if (await _pessoaRepository.IsExistingEmail(pessoa.Email))
        {
            _logger.LogInformation($"{pessoa.Email} já cadastrado no site, informe outro email");
            return;
        }

        await _pessoaRepository.AdicionarPessoaRepositoryAsync(pessoa);
    }

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