using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FindSmiley.API.Models.Import;

namespace FindSmiley.API.Models
{
    public class FindSmileyDbContext : DbContext
    {
        public DbSet<Kontrolrapport.Kontrolrapport> Kontrolrapporter { get; set; }
        public DbSet<Virksomhed.Virksomhed> Virksomheder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Kontrolrapport.Kontrolrapport>().Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Virksomhed.Virksomhed>().Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }

    public class SmileyDbContextDbInitializer : DropCreateDatabaseIfModelChanges<FindSmileyDbContext>
    {
        protected override void Seed(FindSmileyDbContext context)
        {
            var importService = new ImportService(context);

            importService.ImportAll();
        }
    }
}
