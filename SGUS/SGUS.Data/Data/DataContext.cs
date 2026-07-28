using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SGUS.Model.Modelos;

namespace SGUS.Data.Data;

public partial class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
      : base(options)
    {
        _configuration = configuration;
    }

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DataContext()
    { }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoUsuario> ProductoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var conn = _configuration.GetConnectionString("DefaultConnection");
            conn ??= "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\repos\\davidalexandermites\\SGFT\\BDD\\SGIT.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True;";
            optionsBuilder.UseSqlServer(conn);
        }
    }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_dbo.Producto");
        });

        modelBuilder.Entity<ProductoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdProductoUsuario).HasName("PK_dbo.ProductoUsuario");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoUsuarios).HasConstraintName("FK_ProductoUsuario_Producto");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ProductoUsuarios).HasConstraintName("FK_ProductoUsuario_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_dbo.Usuario");
        });

        ////OnModelCreatingPartial(modelBuilder);
    }

    ////partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
