﻿using Microsoft.AspNet.Identity.EntityFramework;
using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using static PartPicker.Models.IdentityModels;

namespace PartPicker.DAL
{
    public class PickerContext : IdentityDbContext<ApplicationUser>
    {
        public PickerContext() : base("PickerCString")
        {

        }

        public static PickerContext Create()
        {
            return new PickerContext();
        }

        static PickerContext()
        {
            Database.SetInitializer<PickerContext>(new PickerInitializer());
        }

        public DbSet<FormFactor> FormFactor { get; set; }
        public DbSet<Interface> Interface { get; set; }
        public DbSet<RamType> RamType { get; set; }
        public DbSet<GpuRam> GpuRam { get; set; }
        public DbSet<Socket> Socket { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Shop> Shop { get; set; }

        public DbSet<Case> Case { get; set; }
        public DbSet<Cpu> Cpu { get; set; }
        public DbSet<Gpu> Gpu { get; set; }
        public DbSet<Mobo> Mobo { get; set; }
        public DbSet<Psu> Psu { get; set; }
        public DbSet<Ram> Ram { get; set; }
        public DbSet<Storage> Storage { get; set; }

        public DbSet<Rate> Rate { get; set; }

        public DbSet<Build> Build { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}