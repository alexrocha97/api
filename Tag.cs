using System.ComponentModel.DataAnnotations;

public class Tag{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public int ProdutosId { get; set; }
}
