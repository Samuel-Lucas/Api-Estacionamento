using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Domain.Models.Entities;

public class Pessoa(string nome, string sobreNome, string email, string senha, string confirmaSenha, string telefone, string role)
{
    [Key]
    public string IdPessoa { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Informe o seu nome")]
    [StringLength(20)]
    public string Nome { get; set; } = nome;

    [Required(ErrorMessage = "Informe o seu sobrenome")]
    [StringLength(20)]
    public string SobreNome { get; set; } = sobreNome;

    [Required(ErrorMessage = "Informe o seu email")]
    [StringLength(80)]
    [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de Email válido")]
    public string Email { get; set; } = email;

    [Required(ErrorMessage = "Informe a senha")]
    [StringLength(12, MinimumLength = 6, ErrorMessage = "A Senha precisa ter entre 6 e 12 caracteres")]
    public string Senha { get; set; } = senha;

    [Required(ErrorMessage = "Informe a confirmação da senha")]
    [StringLength(12, MinimumLength = 6, ErrorMessage = "A confirmação da senha precisa ter entre 6 e 12 caracteres")]
    [Compare(nameof(Senha), ErrorMessage = "Senha informada na confirmação não coincide com o campo Senha")]
    public string ConfirmaSenha { get; set; } = confirmaSenha;

    [StringLength(12)]
    public string Telefone { get; set; } = telefone;

    [MaxLength(20)]
    public string? Role { get; set; } = role;

    public IEnumerable<Veiculo> Veiculos { get; set; }
}