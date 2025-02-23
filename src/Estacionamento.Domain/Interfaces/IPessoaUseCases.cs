using Estacionamento.Domain.Models.Entities;

namespace Estacionamento.Domain.Interfaces;

public interface IPessoaUseCases
{
    Task<IEnumerable<Pessoa>> ObterPessoasUseCaseAsync();
    Task<Pessoa?> ObterPessoaUseCaseAsync(string id);
    Task<Pessoa> AdicionarPessoaUseCaseAsync(Pessoa pessoa);
    Task DeletarPessoaUseCaseAsync(string idPessoa);
    Task AtualizarPessoaUseCaseAsync(Pessoa pessoa);
}