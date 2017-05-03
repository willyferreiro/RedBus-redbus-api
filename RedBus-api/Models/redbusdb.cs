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
        }

        public virtual DbSet<Filho> Filho { get; set; }
        public virtual DbSet<Mensagem> Mensagem { get; set; }
        public virtual DbSet<Motorista> Motorista { get; set; }
        public virtual DbSet<Responsavel> Responsavel { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Viagem> Viagem { get; set; }
        public virtual DbSet<Viagem_Filho> Viagem_Filho { get; set; }
        public virtual DbSet<Viagem_Status> Viagem_Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filho>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Filho>()
                .HasMany(e => e.Viagem_Filho)
                .WithRequired(e => e.Filho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Filho>()
                .HasMany(e => e.Responsavel)
                .WithMany(e => e.Filho)
                .Map(m => m.ToTable("Responsavel_Filho").MapLeftKey("idFilho").MapRightKey("idResponsavel"));

            modelBuilder.Entity<Mensagem>()
                .Property(e => e.mensagem1)
                .IsUnicode(false);

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
                .HasMany(e => e.Mensagem)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuarioDe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Mensagem1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.idUsuarioPara)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasOptional(e => e.Motorista)
                .WithRequired(e => e.Usuario);

            modelBuilder.Entity<Usuario>()
                .HasOptional(e => e.Responsavel)
                .WithRequired(e => e.Usuario);

            modelBuilder.Entity<Viagem>()
                .HasMany(e => e.Viagem_Filho)
                .WithRequired(e => e.Viagem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Viagem_Status>()
                .Property(e => e.descricao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Viagem_Status>()
                .HasMany(e => e.Viagem)
                .WithRequired(e => e.Viagem_Status)
                .WillCascadeOnDelete(false);
        }
    }
}