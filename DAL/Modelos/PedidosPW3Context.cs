using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Modelos
{
    public partial class PedidosPW3Context : DbContext
    {
        public PedidosPW3Context()
        {
        }

        public PedidosPW3Context(DbContextOptions<PedidosPW3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<EstadoPedido> EstadoPedidos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoArticulo> PedidoArticulos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=STOFANO-AR;Database=PedidosPW3;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.IdArticulo);

                entity.ToTable("Articulo");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.FechaBorrado).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.BorradoPorNavigation)
                    .WithMany(p => p.ArticuloBorradoPorNavigations)
                    .HasForeignKey(d => d.BorradoPor)
                    .HasConstraintName("FK_Articulo_Usuario2");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.ArticuloCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .HasConstraintName("FK_Articulo_Usuario1");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.ArticuloModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_Articulo_Usuario");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .HasColumnName("CUIT");

                entity.Property(e => e.Direccion).HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(300);

                entity.Property(e => e.FechaBorrado).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.HasOne(d => d.BorradoPorNavigation)
                    .WithMany(p => p.ClienteBorradoPorNavigations)
                    .HasForeignKey(d => d.BorradoPor)
                    .HasConstraintName("FK_Cliente_Usuario1");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.ClienteCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .HasConstraintName("FK_Cliente_Usuario2");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.ClienteModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_Cliente_Usuario");
            });

            modelBuilder.Entity<EstadoPedido>(entity =>
            {
                entity.HasKey(e => e.IdEstadoPedido);

                entity.ToTable("EstadoPedido");

                entity.Property(e => e.IdEstadoPedido).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.ToTable("Pedido");

                entity.Property(e => e.FechaBorrado).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.BorradoPorNavigation)
                    .WithMany(p => p.PedidoBorradoPorNavigations)
                    .HasForeignKey(d => d.BorradoPor)
                    .HasConstraintName("FK_Pedido_Usuario2");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.PedidoCreadoPorNavigations)
                    .HasForeignKey(d => d.CreadoPor)
                    .HasConstraintName("FK_Pedido_Usuario1");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Cliente");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_EstadoPedido");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.PedidoModificadoPorNavigations)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_Pedido_Usuario");
            });

            modelBuilder.Entity<PedidoArticulo>(entity =>
            {
                entity.HasKey(e => new { e.IdPedido, e.IdArticulo });

                entity.ToTable("PedidoArticulo");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.PedidoArticulos)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoArticulo_Articulo");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoArticulos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoArticulo_PedidoArticulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.FechaBorrado).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.FechaUltLogin).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.BorradoPorNavigation)
                    .WithMany(p => p.InverseBorradoPorNavigation)
                    .HasForeignKey(d => d.BorradoPor)
                    .HasConstraintName("FK_Usuario_Usuario2");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.InverseCreadoPorNavigation)
                    .HasForeignKey(d => d.CreadoPor)
                    .HasConstraintName("FK_Usuario_Usuario1");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.InverseModificadoPorNavigation)
                    .HasForeignKey(d => d.ModificadoPor)
                    .HasConstraintName("FK_Usuario_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
