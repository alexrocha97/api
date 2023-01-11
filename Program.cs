using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<Context>(builder.Configuration["ConnectionStrings:Connection"]);

var app = builder.Build();
var configuration = app.Configuration;


// CRUD BÁSICO
// Get
app.MapGet("/Produtos", (Context context) => {
    return Results.Ok(context
        .tblProdutos
        .Include(c => c.Categoria)
        .Include(c => c.Tags)
        .ToList());
});

//GetBy
app.MapGet("/Produto/{Id}", (int Id, Context context) => {
    var produto = context.tblProdutos
        .Include(p => p.Categoria)
        .Include(p => p.Tags)
        .Where(x => x.Id == Id)
        .FirstOrDefault();
    if(produto != null)
        return Results.Ok(produto);
    return Results.NotFound("Produto não encontrado...");
});

// Post
app.MapPost("/Produto", (ProdutoDto produtodto, Context context) => {
    if(produtodto != null){

        var categoria = context.tblCategoria
            .Where(x => x.Id == produtodto.CategoriaID).First();
        
        var produto = new Produtos{
            Code = produtodto.Code,
            Nome = produtodto.Nome,
            Descricao = produtodto.Descricao,
            Categoria = categoria
        };
        if(produtodto.Tags != null){
            produto.Tags = new List<Tag>();
            foreach (var item in produtodto.Tags){
                produto.Tags.Add(new Tag{ Nome = item});
            }
        }
        context.tblProdutos.Add(produto);
        context.SaveChanges();

        return Results.Created($"/Produto/{produto.Id}", produto.Id);
    }
    return Results.BadRequest();
});

// Put
app.MapPut("/Produto/{Id}", (int Id ,ProdutoDto produtoDto, Context context) => {
    
    var produto = context.tblProdutos
        .Include(p => p.Tags)
        .Where(x => x.Id == Id)
        .FirstOrDefault();

    var categoria = context.tblCategoria
            .Where(x => x.Id == produtoDto.CategoriaID).First();

    produto.Nome = produtoDto.Nome;
    produto.Code = produtoDto.Code;
    produto.Descricao = produtoDto.Descricao;
    produto.Categoria = categoria;
    produto.Tags = new List<Tag>();
    if(produtoDto.Tags != null){
        produto.Tags = new List<Tag>();
        foreach (var item in produtoDto.Tags){
            produto.Tags.Add(new Tag{ Nome = item});
        }
    }
    context.SaveChanges();
    return Results.Ok(); 
});

// Delete
app.MapDelete("/Produto/{code}", (string code) => {
    var produto = ProdutoRepositorio.GetBy(code);
    if(produto != null){
        ProdutoRepositorio.Remove(produto);
        return Results.Ok("Produto deletado com sucesso!");
    }
    return Results.BadRequest("Ocorreu um erro ao deletar o produto");
});


app.Run();
