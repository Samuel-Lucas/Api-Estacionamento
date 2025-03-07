namespace Estacionamento.Domain.Models.DTO;

public class VeiculoInsertDTO
{
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public string Cor { get; set; } = null!;
    public string Placa { get; set; } = null!;
    public string IdPessoa { get; set; } = null!;
}