using DataAccess.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Projeto360.Dominio.Entidades;


namespace DataAccess.Contexto;

public class Projeto360Contexto : DbContext
{
    private readonly DbContextOptions _options;
    public DbSet<Usuario> Usuarios {get;set;}

    public Projeto360Contexto()
    {
        
    }

    public Projeto360Contexto(DbContextOptions options) : base(options)
    {
        _options = options;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();

        if(_options == null)
            optionsBuilder.UseSqlite(@"Filename=./projeto360.sqlite;");
        //"Server=DESKTOP-58UEHOH\\SQLEXPRESS;database=;Trusted_Connection=True;TrustServerCertificated=True"
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
    }
}