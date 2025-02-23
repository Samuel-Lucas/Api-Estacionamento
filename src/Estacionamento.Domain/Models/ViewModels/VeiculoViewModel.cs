namespace Estacionamento.Domain.Models.ViewModels;

public record VeiculoViewModel(int idVeiculo, string marca, string modelo, string cor, string placa, string IdPessoa, string nome, string sobreNome);