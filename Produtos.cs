using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Produtos{
    [Key]
    [Column(Order = 1)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Code { get; set; }
    public string Descricao { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public List<Tag> Tags { get; set; }
}
