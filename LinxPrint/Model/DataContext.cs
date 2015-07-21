/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Model
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("LinxPrintContext")
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<DataContext>(null);
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
