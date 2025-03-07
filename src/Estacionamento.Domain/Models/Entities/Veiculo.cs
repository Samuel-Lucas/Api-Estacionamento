using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamento.Domain.Models.Entities;

[Table("veiculo")]
public class Veiculo(string marca, string modelo, string cor, string placa, string idPessoa)
{
    [Key]
    [Column("id_veiculo")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdVeiculo { get; set; }

    [Required(ErrorMessage = "Informe o nome da marca do carro")]
    [Column("marca")]
    public string Marca { get; set; } = marca;

    [Required(ErrorMessage = "Informe o modelo carro")]
    [Column("modelo")]
    public string Modelo { get; set; } = modelo;

    [Required(ErrorMessage = "Informe a cor do carro")]
    [Column("cor")]
    public string Cor { get; set; } = cor;

    [Required(ErrorMessage = "Informe a placa carro")]
    [Column("placa")]
    public string Placa { get; set; } = placa;

    [Required(ErrorMessage = "Informe o id da pessoa")]
    [Column("id_pessoa")]
    public string IdPessoa { get; set; } = idPessoa;

    [NotMapped]
    public Pessoa? Pessoa { get; set; }
}