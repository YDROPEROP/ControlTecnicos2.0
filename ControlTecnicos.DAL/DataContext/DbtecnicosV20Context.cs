using Microsoft.EntityFrameworkCore;
using ControlTecnicos.Models.Entities;

namespace ControlTecnicos.DAL.DataContext;

public partial class DbtecnicosV20Context : DbContext
{
    public DbtecnicosV20Context()
    {
    }

    public DbtecnicosV20Context(DbContextOptions<DbtecnicosV20Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Elemento> Elementos { get; set; }

    public virtual DbSet<ElementosTecnico> ElementosTecnicos { get; set; }

    public virtual DbSet<Sucursal> Sucursales { get; set; }

    public virtual DbSet<Tecnico> Tecnicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=DBTECNICOS_V2.0;Integrated Security=true; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Elemento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Elemento__3214EC0785D69609");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ElementosTecnico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Elemento__3214EC072C145086");

            entity.ToTable("ElementosTecnico");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Elemento).WithMany(p => p.ElementosTecnicos)
                .HasForeignKey(d => d.ElementoId)
                .HasConstraintName("FK__Elementos__Eleme__5FB337D6");

            entity.HasOne(d => d.Tecnico).WithMany(p => p.ElementosTecnicos)
                .HasForeignKey(d => d.TecnicoId)
                .HasConstraintName("FK__Elementos__Tecni__5EBF139D");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sucursal__3214EC07D086EFAD");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tecnicos__3214EC073A1E5800");

            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaDeCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaDeModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SueldoBase).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Tecnicos)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK__Tecnicos__Sucurs__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
