using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options){}

    public DbSet<Produtos> tblProdutos { get; set; }
    public DbSet<Categoria> tblCategoria { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Produtos>()
            .Property(p => p.Descricao).HasMaxLength(500).IsRequired(false);
        modelBuilder.Entity<Produtos>()
            .Property(p => p.Nome).HasMaxLength(120).IsRequired();
        modelBuilder.Entity<Produtos>()
            .Property(p => p.Code).HasMaxLength(20).IsRequired();
    }
}
