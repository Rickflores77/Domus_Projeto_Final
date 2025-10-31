// Data/DomusDbContext.cs
using Microsoft.EntityFrameworkCore;
using Domus_Projeto.Models;

public class DomusDbContext : DbContext
{
    public DomusDbContext(DbContextOptions<DomusDbContext> options) : base(options) { }

    public DbSet<Morador> Moradores { get; set; } = null!;
    public DbSet<Administrador> Administradores { get; set; } = null!;
    public DbSet<Conta> Contas { get; set; } = null!;
    public DbSet<Reserva> Reservas { get; set; } = null!;
    public DbSet<Visitante> Visitantes { get; set; } = null!;
    public DbSet<Documento> Documentos { get; set; } = null!;
    public DbSet<Votacao> Votacoes { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurações das chaves primárias, se não tiver feito
        modelBuilder.Entity<Administrador>().HasKey(a => a.Id);

        // Adiciona um admin inicial
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Nome = "Admin Principal",
                Email = "admin@condominio.com",
                Senha = "123456" // ⚠️ Apenas para teste! Use hashing para produção.
            }
        );
    }

}
