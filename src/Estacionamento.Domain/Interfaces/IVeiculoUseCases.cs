using Estacionamento.Domain.Models.DTO;
using Estacionamento.Domain.Models.Entities;
using Estacionamento.Domain.Models.ViewModels;

namespace Estacionamento.Domain.Interfaces;

public interface IVeiculoUseCases
{
    Task<IEnumerable<VeiculoViewModel>> ObterVeiculosUseCaseAsync();
    Task<Veiculo?> ObterVeiculoUseCaseAsync(int idVeiculo);
    Task AdicionarVeiculoUseCaseAsync(VeiculoInsertDTO veiculo);
    Task DeletarVeiculoUseCaseAsync(int idVeiculo);
    Task AtualizarVeiculoUseCaseAsync(Veiculo veiculo);
}