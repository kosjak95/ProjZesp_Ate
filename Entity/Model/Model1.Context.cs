﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AteDatabase : DbContext
    {
        public AteDatabase()
            : base("name=AteDatabase")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Connector> Connectors { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
    }
}
