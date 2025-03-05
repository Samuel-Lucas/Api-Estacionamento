using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estacionamento.Domain.Models.Entities;

[Table("pessoa")]
public class Pessoa(string nome, string sobreNome, string email, string senha, string telefone, string role)
{
    [Key]
    [Column("id_pessoa")]
    public string IdPessoa { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Informe o seu nome")]
    [StringLength(20)]
    [Column("nome")]
    public string Nome { get; set; } = nome;

    [Required(ErrorMessage = "Informe o seu sobrenome")]
    [StringLength(20)]
    [Column("sobrenome")]
    public string SobreNome { get; set; } = sobreNome;

    [Required(ErrorMessage = "Informe o seu email")]
    [StringLength(80)]
    [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de Email válido")]
    [Column("email")]
    public string Email { get; set; } = email;

    [Required(ErrorMessage = "Informe a senha")]
    [StringLength(12, MinimumLength = 6, ErrorMessage = "A Senha precisa ter entre 6 e 12 caracteres")]
    [Column("senha")]
    public string Senha { get; set; } = senha;

    [StringLength(12)]
    [Column("telefone")]
    public string Telefone { get; set; } = telefone;

    [MaxLength(20)]
    [Column("role")]
    public string? Role { get; set; } = role;

    [NotMapped]
    public IEnumerable<Veiculo>? Veiculos { get; set; }
}