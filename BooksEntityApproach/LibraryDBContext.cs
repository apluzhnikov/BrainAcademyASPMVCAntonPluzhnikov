﻿
using DataObjectsLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksEntityApproach
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext()
            : base("name=LibraryDB") {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LibraryDBContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomersProductsDBContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomersProductsDBContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<CustomersProductsDBContext>());
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Library> Library { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Configurations.Add(new BookConfig());
            modelBuilder.Configurations.Add(new CustomerConfig());
            modelBuilder.Configurations.Add(new CustomersProductsConfig());*/
        }
    }
}