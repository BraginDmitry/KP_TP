﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class tpEntities1 : DbContext
    {
        public tpEntities1()
            : base("name=tpEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dogovor> Dogovor { get; set; }
        public virtual DbSet<GroupDog> GroupDog { get; set; }
        public virtual DbSet<StrSl> StrSl { get; set; }
        public virtual DbSet<Tarif> Tarif { get; set; }
    }
}