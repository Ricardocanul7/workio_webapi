using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace workio_webapi.Models
{
    public partial class dbworkioContext : DbContext
    {
        public dbworkioContext()
        {
        }

        public dbworkioContext(DbContextOptions<dbworkioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AplicarTrabajo> AplicarTrabajo { get; set; }
        public virtual DbSet<Calificaciones> Calificaciones { get; set; }
        public virtual DbSet<CategoriaTrabajo> CategoriaTrabajo { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<ElementoPermitido> ElementoPermitido { get; set; }
        public virtual DbSet<Elementos> Elementos { get; set; }
        public virtual DbSet<ElementosPermisos> ElementosPermisos { get; set; }
        public virtual DbSet<EstadoPublicacionTrabajo> EstadoPublicacionTrabajo { get; set; }
        public virtual DbSet<EstadoUsuario> EstadoUsuario { get; set; }
        public virtual DbSet<LogBusquedaCategorias> LogBusquedaCategorias { get; set; }
        public virtual DbSet<LogLogin> LogLogin { get; set; }
        public virtual DbSet<Mensaje> Mensaje { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilModulo> PerfilModulo { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PublicacionTrabajo> PublicacionTrabajo { get; set; }
        public virtual DbSet<ReportesPersona> ReportesPersona { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TiposReportes> TiposReportes { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=db-workio.mssql.somee.com;packet size=4096;user id=workio_webapi;pwd=123456789;data source=db-workio.mssql.somee.com;persist security info=False;initial catalog=db-workio");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AplicarTrabajo>(entity =>
            {
                entity.ToTable("APLICAR_TRABAJO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime");

                entity.Property(e => e.PersonaId).HasColumnName("PERSONA_ID");

                entity.Property(e => e.Presupuesto)
                    .HasColumnName("PRESUPUESTO")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PublicacionId).HasColumnName("PUBLICACION_ID");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.AplicarTrabajo)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APLICAR_T__PERSO__5FB337D6");

                entity.HasOne(d => d.Publicacion)
                    .WithMany(p => p.AplicarTrabajo)
                    .HasForeignKey(d => d.PublicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APLICAR_T__PUBLI__5EBF139D");
            });

            modelBuilder.Entity<Calificaciones>(entity =>
            {
                entity.ToTable("CALIFICACIONES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comentarios).HasColumnName("COMENTARIOS");

                entity.Property(e => e.EmpleadorId).HasColumnName("EMPLEADOR_ID");

                entity.Property(e => e.Estrellas).HasColumnName("ESTRELLAS");

                entity.Property(e => e.TrabajadorId).HasColumnName("TRABAJADOR_ID");

                entity.HasOne(d => d.Empleador)
                    .WithMany(p => p.CalificacionesEmpleador)
                    .HasForeignKey(d => d.EmpleadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CALIFICAC__EMPLE__6477ECF3");

                entity.HasOne(d => d.Trabajador)
                    .WithMany(p => p.CalificacionesTrabajador)
                    .HasForeignKey(d => d.TrabajadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CALIFICAC__TRABA__6383C8BA");
            });

            modelBuilder.Entity<CategoriaTrabajo>(entity =>
            {
                entity.ToTable("CATEGORIA_TRABAJO");

                entity.HasIndex(e => e.Descripcion)
                    .HasName("UQ__CATEGORI__794449EF86BD8AC2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.ToTable("DOCUMENTO");

                entity.HasIndex(e => new { e.PersonaId, e.TipoDocumentoId })
                    .HasName("UQ_DOCUMENTO")
                    .IsUnique();

                entity.Property(e => e.IdDocumento).HasColumnName("ID_DOCUMENTO");

                entity.Property(e => e.Estatus).HasColumnName("ESTATUS");

                entity.Property(e => e.FechaAceptacion)
                    .HasColumnName("FECHA_ACEPTACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCaducidad)
                    .HasColumnName("FECHA_CADUCIDAD")
                    .HasColumnType("datetime");

                entity.Property(e => e.FotoUrl)
                    .HasColumnName("FOTO_URL")
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.PersonaId).HasColumnName("PERSONA_ID");

                entity.Property(e => e.Texto)
                    .HasColumnName("TEXTO")
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumentoId).HasColumnName("TIPO_DOCUMENTO_ID");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DOCUMENTO__PERSO__6C190EBB");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DOCUMENTO__TIPO___6B24EA82");
            });

            modelBuilder.Entity<ElementoPermitido>(entity =>
            {
                entity.ToTable("ELEMENTO_PERMITIDO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElementosPermisosId).HasColumnName("ELEMENTOS_PERMISOS_ID");

                entity.Property(e => e.PerfilId).HasColumnName("PERFIL_ID");

                entity.HasOne(d => d.ElementosPermisos)
                    .WithMany(p => p.ElementoPermitido)
                    .HasForeignKey(d => d.ElementosPermisosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ELEMENTO___ELEME__3C69FB99");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.ElementoPermitido)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ELEMENTO___PERFI__3B75D760");
            });

            modelBuilder.Entity<Elementos>(entity =>
            {
                entity.ToTable("ELEMENTOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModulosId).HasColumnName("MODULOS_ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Modulos)
                    .WithMany(p => p.Elementos)
                    .HasForeignKey(d => d.ModulosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ELEMENTOS__MODUL__31EC6D26");
            });

            modelBuilder.Entity<ElementosPermisos>(entity =>
            {
                entity.ToTable("ELEMENTOS_PERMISOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ElementosId).HasColumnName("ELEMENTOS_ID");

                entity.Property(e => e.PermisosId).HasColumnName("PERMISOS_ID");

                entity.HasOne(d => d.Elementos)
                    .WithMany(p => p.ElementosPermisos)
                    .HasForeignKey(d => d.ElementosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ELEMENTOS__ELEME__37A5467C");

                entity.HasOne(d => d.Permisos)
                    .WithMany(p => p.ElementosPermisos)
                    .HasForeignKey(d => d.PermisosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ELEMENTOS__PERMI__38996AB5");
            });

            modelBuilder.Entity<EstadoPublicacionTrabajo>(entity =>
            {
                entity.ToTable("ESTADO_PUBLICACION_TRABAJO");

                entity.HasIndex(e => e.Descripcion)
                    .HasName("UQ__ESTADO_P__794449EF1876D9E8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoUsuario>(entity =>
            {
                entity.ToTable("ESTADO_USUARIO");

                entity.HasIndex(e => e.Estatus)
                    .HasName("UQ__ESTADO_U__29E79E552C6378DA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasColumnName("ESTATUS")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogBusquedaCategorias>(entity =>
            {
                entity.ToTable("LOG_BUSQUEDA_CATEGORIAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoriaId).HasColumnName("CATEGORIA_ID");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.LogBusquedaCategorias)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOG_BUSQU__CATEG__787EE5A0");
            });

            modelBuilder.Entity<LogLogin>(entity =>
            {
                entity.ToTable("LOG_LOGIN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.LogLogin)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOG_LOGIN__USUAR__75A278F5");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.ToTable("MENSAJE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmisorId).HasColumnName("EMISOR_ID");

                entity.Property(e => e.FechaEnviado)
                    .HasColumnName("FECHA_ENVIADO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaLeido)
                    .HasColumnName("FECHA_LEIDO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mensaje1)
                    .IsRequired()
                    .HasColumnName("MENSAJE");

                entity.Property(e => e.ReceptorId).HasColumnName("RECEPTOR_ID");

                entity.HasOne(d => d.Emisor)
                    .WithMany(p => p.MensajeEmisor)
                    .HasForeignKey(d => d.EmisorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MENSAJE__EMISOR___45F365D3");

                entity.HasOne(d => d.Receptor)
                    .WithMany(p => p.MensajeReceptor)
                    .HasForeignKey(d => d.ReceptorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MENSAJE__RECEPTO__46E78A0C");
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.ToTable("METODO_PAGO");

                entity.HasIndex(e => e.Descripcion)
                    .HasName("UQ__METODO_P__794449EFA99D42F3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modulos>(entity =>
            {
                entity.ToTable("MODULOS");

                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__MODULOS__B21D0AB9C3B729E6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.ToTable("PAGOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("CANTIDAD")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime");

                entity.Property(e => e.MetodoPagoId).HasColumnName("METODO_PAGO_ID");

                entity.Property(e => e.PublicacionId).HasColumnName("PUBLICACION_ID");

                entity.Property(e => e.TrabajadorId).HasColumnName("TRABAJADOR_ID");

                entity.HasOne(d => d.MetodoPago)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.MetodoPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PAGOS__METODO_PA__59FA5E80");

                entity.HasOne(d => d.Publicacion)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.PublicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PAGOS__PUBLICACI__5AEE82B9");

                entity.HasOne(d => d.Trabajador)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.TrabajadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PAGOS__TRABAJADO__5BE2A6F2");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("PERFIL");

                entity.HasIndex(e => e.TipoUsuario)
                    .HasName("UQ__PERFIL__D13E583BFEC8BFC4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasColumnName("TIPO_USUARIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerfilModulo>(entity =>
            {
                entity.ToTable("PERFIL_MODULO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModulosId).HasColumnName("MODULOS_ID");

                entity.Property(e => e.PerfilId).HasColumnName("PERFIL_ID");

                entity.HasOne(d => d.Modulos)
                    .WithMany(p => p.PerfilModulo)
                    .HasForeignKey(d => d.ModulosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERFIL_MO__MODUL__2F10007B");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.PerfilModulo)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERFIL_MO__PERFI__2E1BDC42");
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.ToTable("PERMISOS");

                entity.HasIndex(e => e.Codigo)
                    .HasName("UQ__PERMISOS__CC87E126F7536734")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("CODIGO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("PERSONA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApellidoM)
                    .HasColumnName("APELLIDO_M")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoP)
                    .IsRequired()
                    .HasColumnName("APELLIDO_P")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasColumnName("CELULAR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("FECHA_NACIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FotoUrl)
                    .HasColumnName("FOTO_URL")
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("NOMBRES")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PublicacionTrabajo>(entity =>
            {
                entity.ToTable("PUBLICACION_TRABAJO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoriaId).HasColumnName("CATEGORIA_ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");

                entity.Property(e => e.FechaCompletado)
                    .HasColumnName("FECHA_COMPLETADO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaPublicacion)
                    .HasColumnName("FECHA_PUBLICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.PersonaOrigenId).HasColumnName("PERSONA_ORIGEN_ID");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UbicacionId).HasColumnName("UBICACION_ID");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.PublicacionTrabajo)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PUBLICACI__CATEG__5535A963");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.PublicacionTrabajo)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PUBLICACI__ESTAD__571DF1D5");

                entity.HasOne(d => d.PersonaOrigen)
                    .WithMany(p => p.PublicacionTrabajo)
                    .HasForeignKey(d => d.PersonaOrigenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PUBLICACI__PERSO__5441852A");

                entity.HasOne(d => d.Ubicacion)
                    .WithMany(p => p.PublicacionTrabajo)
                    .HasForeignKey(d => d.UbicacionId)
                    .HasConstraintName("FK__PUBLICACI__UBICA__5629CD9C");
            });

            modelBuilder.Entity<ReportesPersona>(entity =>
            {
                entity.ToTable("REPORTES_PERSONA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime");

                entity.Property(e => e.PersonaId).HasColumnName("PERSONA_ID");

                entity.Property(e => e.TipoReporteId).HasColumnName("TIPO_REPORTE_ID");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.ReportesPersona)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REPORTES___PERSO__71D1E811");

                entity.HasOne(d => d.TipoReporte)
                    .WithMany(p => p.ReportesPersona)
                    .HasForeignKey(d => d.TipoReporteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REPORTES___TIPO___72C60C4A");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento);

                entity.ToTable("TIPO_DOCUMENTO");

                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__TIPO_DOC__B21D0AB99B33FA56")
                    .IsUnique();

                entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TIPO_DOCUMENTO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposReportes>(entity =>
            {
                entity.ToTable("TIPOS_REPORTES");

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__TIPOS_RE__B6FCAAA2D6687A0F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.ToTable("UBICACION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Direccion)
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Latitud)
                    .HasColumnName("LATITUD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Longitud)
                    .HasColumnName("LONGITUD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Referencias)
                    .HasColumnName("REFERENCIAS")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIO__161CF724A6998098")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__USUARIO__B15BE12E1B6F0294")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contrasenia)
                    .HasColumnName("CONTRASENIA")
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(320)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusId).HasColumnName("ESTATUS_ID");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("FECHA_REGISTRO")
                    .HasColumnType("datetime");

                entity.Property(e => e.PerfilId).HasColumnName("PERFIL_ID");

                entity.Property(e => e.PersonaId).HasColumnName("PERSONA_ID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.EstatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__ESTATUS__4316F928");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__PERFIL___4222D4EF");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__PERSONA__412EB0B6");
            });
        }
    }
}
