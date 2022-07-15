namespace Locadora.Commands;

using System.ComponentModel.DataAnnotations;

public class NovaLocacaoCommand
{
    public int FilmeId { get; set; }
    public string FilmeNome { get; set; } = null!;
    [Required]
    [MinLength(3)]
    [MaxLength(5)]
    public string CodigoCliente { get; set; } = null!;
}