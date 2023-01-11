public static class ProdutoRepositorio{
    public static List<Produtos> ListaDeProdutos { get; set; }

    public static void AddProdutos(Produtos produtos){
        if(ListaDeProdutos == null){
            ListaDeProdutos = new List<Produtos>();
        }
        ListaDeProdutos.Add(produtos);
    }

    public static Produtos GetBy(string code){
        var produto = ListaDeProdutos.FirstOrDefault(x => x.Code == code);
        return produto;
    }

    public static List<Produtos> ListProdutos(){
        return ListaDeProdutos.ToList();
    }

    public static void Remove(Produtos produto){
        ListaDeProdutos.Remove(produto);
    }
}