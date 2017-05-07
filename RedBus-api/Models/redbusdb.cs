namespace RedBus_api.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class redbusdb : DbContext
    {
        public redbusdb()
            : base("name=redbusdb")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Filho> Filho { get; set; }
        public virtual DbSet<Mensagem> Mensagem { get; set; }
        public virtual DbSet<Motorista> Motorista { get; set; }
        public virtual DbSet<Responsavel> Responsavel { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Viagem> Viagem { get; set; }
        public virtual DbSet<Viagem_Filho> Viagem_Filho { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filho>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Filho>()
                .HasMany(e => e.Viagem_Filho)
                .WithRequired(e => e.Filho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mensagem>()
                .Property(e => e.mensagem)
                .IsUnicode(false);

            modelBuilder.Entity<Motorista>()
                .HasMany(e => e.Filhos)
                .WithRequired(e => e.Motorista)
                .HasForeignKey(e => e.idMotorista)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Motorista>()
                .HasMany(e => e.Viagens)
                .WithRequired(e => e.Motorista)
                .HasForeignKey(e => e.idMotorista)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Responsavel>()
                .HasMany(e => e.Filhos)
                .WithRequired(e => e.Responsavel)
                .HasForeignKey(e => e.idResponsavel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.telefone)
                .HasPrecision(11, 0);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.senha)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.tipoUsuario)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.MensagensDe)
                .WithRequired(e => e.UsuarioDe)
                .HasForeignKey(e => e.idUsuarioDe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.MensagensPara)
                .WithRequired(e => e.UsuarioPara)
                .HasForeignKey(e => e.idUsuarioPara)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasOptional(e => e.Motorista)
                .WithRequired(e => e.Usuario);

            modelBuilder.Entity<Usuario>()
                .HasOptional(e => e.Responsavel)
                .WithRequired(e => e.Usuario);

            modelBuilder.Entity<Viagem>()
                .Property(e => e.statusViagem)
                .HasPrecision(1, 0);

            modelBuilder.Entity<Viagem>()
                .HasMany(e => e.Viagem_Filho)
                .WithRequired(e => e.Viagem)
                .WillCascadeOnDelete(false);
        }
    }
}
