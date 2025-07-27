using Estacionamento.Domain.Models.DTO;
using Estacionamento.Domain.Models.Entities;
using Estacionamento.Domain.Models.ViewModels;

namespace Estacionamento.Domain.Interfaces;

public interface IVeiculoUseCases
{
    Task<IEnumerable<VeiculoViewModel>> ObterVeiculosUseCaseAsync();
    Task<VeiculoViewModel?> ObterVeiculoUseCaseAsync(int idVeiculo);
    Task<int> ObterQuantidadeVeiculosCadastradosUseCaseAsync();
    Task<bool> AdicionarVeiculoUseCaseAsync(VeiculoInsertDTO veiculoDto);
    Task DeletarVeiculoUseCaseAsync(int idVeiculo);
    Task AtualizarVeiculoUseCaseAsync(VeiculoUpdateDTO veiculo);
}