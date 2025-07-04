using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Infrastructure.Data;

public partial class VdiIntranet2Context : DbContext
{
    public VdiIntranet2Context()
    {
    }

    public VdiIntranet2Context(DbContextOptions<VdiIntranet2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Accesos> Accesos { get; set; }

    public virtual DbSet<AccesosFormularioProfesores> AccesosFormularioProfesores { get; set; }

    public virtual DbSet<Asignaciones> Asignaciones { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<FaqChatbot> FaqChatbot { get; set; }

    public virtual DbSet<IssnConsulta> IssnConsulta { get; set; }

    public virtual DbSet<ListasCerradas> ListasCerradas { get; set; }

    public virtual DbSet<ListasCerradasGuardadas> ListasCerradasGuardadas { get; set; }

    public virtual DbSet<Notificaciones> Notificaciones { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Propuestas> Propuestas { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JEFFFERSON;Database=VDI_Intranet_3;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accesos>(entity =>
        {
            entity.HasKey(e => e.AccesoId).HasName("PK__Accesos__66CA117924A660AE");

            entity.Property(e => e.AccesoId).HasColumnName("AccesoID");
            entity.Property(e => e.FechaHoraAcceso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Accesos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Accesos__Usuario__2D27B809");
        });



        modelBuilder.Entity<AccesosFormularioProfesores>(entity =>
        {
            entity.HasKey(e => e.AccesoId).HasName("PK__AccesosF__66CA1179B42C0C85");

            entity.Property(e => e.AccesoId).HasColumnName("AccesoID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correos)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.Trabajador)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Asignaciones>(entity =>
        {
            entity.HasKey(e => e.AsignacionId).HasName("PK__Asignaci__D82B5BB7426C479E");

            entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ListasCerradasId).HasColumnName("Listas_CerradasID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.ListasCerradas).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.ListasCerradasId)
                .HasConstraintName("FK__Asignacio__Lista__3C69FB99");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Asignacio__Usuar__3B75D760");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C56A64EF3E");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.NombreCategoria).HasMaxLength(255);
        });

        modelBuilder.Entity<FaqChatbot>(entity =>
        {
            entity.HasKey(e => e.Faqid).HasName("PK__FAQ_Chat__4B89D1E2D21E31A0");

            entity.ToTable("FAQ_Chatbot");

            entity.Property(e => e.Faqid).HasColumnName("FAQID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PreguntaClave).HasMaxLength(255);
            entity.Property(e => e.Visible).HasDefaultValue(true);
        });

        modelBuilder.Entity<IssnConsulta>(entity =>
        {
            entity.HasKey(e => e.IssnConsultaId).HasName("PK__Issn_con__B7DA1DD07847DE6A");

            entity.ToTable("Issn_consulta");

            entity.Property(e => e.IssnConsultaId).HasColumnName("Issn_consultaID");
            entity.Property(e => e.Abdc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ABDC");
            entity.Property(e => e.AbdcExiste).HasColumnName("ABDC_Existe");
            entity.Property(e => e.AbdcS).HasColumnName("ABDC_S");
            entity.Property(e => e.Ajg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AJG");
            entity.Property(e => e.Ajg4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AJG_4_");
            entity.Property(e => e.AjgExiste).HasColumnName("AJG_Existe");
            entity.Property(e => e.AjgS).HasColumnName("AJG_S");
            entity.Property(e => e.AlMenosEnUnaLista)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Al_menos_en_una_lista");
            entity.Property(e => e.BeallsList)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BEALLS_LIST");
            entity.Property(e => e.Cnrs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNRS");
            entity.Property(e => e.CnrsExiste).HasColumnName("CNRS_Existe");
            entity.Property(e => e.CnrsS).HasColumnName("CNRS_S");
            entity.Property(e => e.CoautoriaEsan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Coautoria_ESAN");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EsciQ)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESCI_Q");
            entity.Property(e => e.EsciScieloSinScopus).HasColumnName("ESCI_Scielo_sin_Scopus");
            entity.Property(e => e.Especial216b).HasColumnName("Especial_2_1_6B");
            entity.Property(e => e.Insights)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("INSIGHTS");
            entity.Property(e => e.Issn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISSN");
            entity.Property(e => e.Jif)
                .HasColumnType("decimal(5, 3)")
                .HasColumnName("JIF");
            entity.Property(e => e.LatamSinEsciExiste).HasColumnName("Latam_sin_ESCI_Existe");
            entity.Property(e => e.Mdpi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MDPI");
            entity.Property(e => e.MultidisciplinaryScopus).HasColumnName("Multidisciplinary_SCOPUS");
            entity.Property(e => e.MultidisciplinaryWos).HasColumnName("Multidisciplinary_WOS");
            entity.Property(e => e.MultidisciplinaryWosOScopus).HasColumnName("Multidisciplinary_WOS_o_SCOPUS");
            entity.Property(e => e.MultyYAlMenosUnaLista).HasColumnName("Multy_y_al_menos_una_lista");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PosicionDelAutor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Posicion_del_autor");
            entity.Property(e => e.Scielo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Scopus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SCOPUS");
            entity.Property(e => e.ScopusExiste).HasColumnName("Scopus_Existe");
            entity.Property(e => e.SoloEnUnaLista)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Solo_en_una_lista");
            entity.Property(e => e.SoloScieloExiste).HasColumnName("Solo_Scielo_Existe");
            entity.Property(e => e.Top50)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TOP50");
            entity.Property(e => e.WoSEsci).HasColumnName("WoS_ESCi");
            entity.Property(e => e.WoSEsciExiste).HasColumnName("WoS_ESCI_Existe");
            entity.Property(e => e.WoSLatam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WoS_LATAM");
            entity.Property(e => e.WoSQ)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WoS_Q");
            entity.Property(e => e.WoSS).HasColumnName("WoS_S");
            entity.Property(e => e.WoSTopExiste).HasColumnName("WoS_top_Existe");
        });

        modelBuilder.Entity<ListasCerradas>(entity =>
        {
            entity.HasKey(e => e.ListasCerradasId).HasName("PK__Listas_C__BECE5D7538B30618");

            entity.ToTable("Listas_Cerradas");

            entity.Property(e => e.ListasCerradasId).HasColumnName("Listas_CerradasID");
            entity.Property(e => e.Abdc).HasColumnName("ABDC");
            entity.Property(e => e.Ajg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AJG");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Cnrs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNRS");
            entity.Property(e => e.EsciQ)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESCI_Q");
            entity.Property(e => e.IncentivoUsd)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("Incentivo_USD");
            entity.Property(e => e.Issn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ISSN");
            entity.Property(e => e.Issn2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ISSN2");
            entity.Property(e => e.Issn3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ISSN3");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Puntaje).HasColumnType("decimal(5, 4)");
            entity.Property(e => e.Scopus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SCOPUS");
            entity.Property(e => e.WoSLatam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WoS_LATAM");
            entity.Property(e => e.WoSQ)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WoS_Q");

            entity.HasOne(d => d.Categoria).WithMany(p => p.ListasCerradas)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Listas_Ce__WoS_L__31EC6D26");
        });

        modelBuilder.Entity<ListasCerradasGuardadas>(entity =>
        {
            entity.HasKey(e => e.ListasCerradasGuardadasId).HasName("PK__Listas_C__B775B7CD6C15A5F6");

            entity.ToTable("Listas_CerradasGuardadas");

            entity.Property(e => e.ListasCerradasGuardadasId).HasColumnName("Listas_CerradasGuardadasID");
            entity.Property(e => e.FechaGuardado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ListasCerradasId).HasColumnName("Listas_CerradasID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.ListasCerradas).WithMany(p => p.ListasCerradasGuardadas)
                .HasForeignKey(d => d.ListasCerradasId)
                .HasConstraintName("FK__Listas_Ce__Lista__36B12243");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ListasCerradasGuardadas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Listas_Ce__Usuar__35BCFE0A");
        });

        modelBuilder.Entity<Notificaciones>(entity =>
        {
            entity.HasKey(e => e.NotificacionId).HasName("PK__Notifica__BCC120C4E6D54D72");

            entity.Property(e => e.NotificacionId).HasColumnName("NotificacionID");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Leido).HasDefaultValue(false);
            entity.Property(e => e.Mensaje).HasMaxLength(500);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Notificac__Usuar__4316F928");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D14F029789");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.NombreRol).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7989F7E95BB");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A1901F2FD7E").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__RolID__29572725");
        });

        modelBuilder.Entity<Propuestas>(entity =>
        {
            entity.HasKey(e => e.PropuestaId).HasName("PK__Propuest__B0A1F2C3D5E8F4B6");
            entity.Property(e => e.PropuestaId).HasColumnName("PropuestaID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Tema)
                .HasMaxLength(255);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000);
            entity.Property(e => e.Incentivo)
                .HasMaxLength(255);
            entity.HasOne(d => d.Usuario)
                .WithMany(p => p.Propuestas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Propuestas__UsuarioID");

            entity.HasOne(d => d.Categoria)
                .WithMany(p => p.Propuestas)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Propuestas__CategoriaID");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
