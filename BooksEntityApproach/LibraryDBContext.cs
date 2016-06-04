using BooksEntityApproach.Configs;
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
            //: base("name=LibraryDB") {
            //: base("name=LibraryDBBA") { 
            : base("name=LibraryDBBAPUB") {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LibraryDBContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomersProductsDBContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomersProductsDBContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<LibraryDBContext>());
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Library> Library { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new LibraryConfig());

            //modelBuilder.Configurations.Add(new BookConfig());
        }
    }
}
