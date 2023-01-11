using System.ComponentModel.DataAnnotations;

public class Categoria{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
}
