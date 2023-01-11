public record ProdutoDto(
    string Nome, 
    string Code, 
    string Descricao, 
    int CategoriaID, 
    List<string> Tags)
{
    
}