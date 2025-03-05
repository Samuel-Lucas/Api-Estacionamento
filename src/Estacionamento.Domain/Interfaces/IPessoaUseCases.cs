using Estacionamento.Domain.Models.DTO;
using Estacionamento.Domain.Models.Entities;
using Estacionamento.Domain.Models.ViewModels;

namespace Estacionamento.Domain.Interfaces;

public interface IPessoaUseCases
{
    Task<IEnumerable<PessoaViewModel>> ObterPessoasUseCaseAsync();
    Task<PessoaViewModel?> ObterPessoaUseCaseAsync(string id);
    Task AdicionarPessoaUseCaseAsync(PessoaDTO pessoa);
    Task DeletarPessoaUseCaseAsync(string idPessoa);
    Task AtualizarPessoaUseCaseAsync(Pessoa pessoa);
}