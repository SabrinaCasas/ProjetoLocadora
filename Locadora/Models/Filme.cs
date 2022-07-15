namespace Locadora.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public sealed class Filme
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Imagem { get; set; } = string.Empty;
    
    [DisplayName("Ano de lançamento")]
    public int? AnoLancamento { get; set; }
    public string? Sinopse { get; set; } 
    [DisplayName("Duração")]
    [DisplayFormat(DataFormatString = "{0} min", NullDisplayText = "-")]
    public int? Duracao { get; set; } 
    
    [DisplayName("Gênero")]
    public int GeneroId { get; set; }
    public Genero? Genero { get; set; }

}