using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Models.Entities;

public class Veiculo(string marca, string modelo, string cor, string placa, string idPessoa)
{
    [Key]
    public int IdVeiculo { get; set; }

    [Required(ErrorMessage = "Informe o nome da marca do carro")]
    public string Marca { get; set; } = marca;

    [Required(ErrorMessage = "Informe o modelo carro")]
    public string Modelo { get; set; } = modelo;

    [Required(ErrorMessage = "Informe a cor do carro")]
    public string Cor { get; set; } = cor;

    [Required(ErrorMessage = "Informe a placa carro")]
    public string Placa { get; set; } = placa;
    public string IdPessoa { get; set; } = idPessoa;
    public Pessoa Pessoa { get; set; } = null!;
}