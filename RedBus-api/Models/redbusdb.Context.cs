﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedBus_api.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class redbusdb : DbContext
    {
        public redbusdb()
            : base("name=redbusdb")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Filho> Filho { get; set; }
        public virtual DbSet<Mensagem> Mensagem { get; set; }
        public virtual DbSet<Motorista> Motorista { get; set; }
        public virtual DbSet<Responsavel> Responsavel { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Viagem> Viagem { get; set; }
        public virtual DbSet<ViagemFilho> ViagemFilho { get; set; }
        public virtual DbSet<UltimaViagemFilhoView> UltimaViagemFilhoView { get; set; }
    }
}
