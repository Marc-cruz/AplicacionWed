using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PumasUnah.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" +
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\PumasUnahDB.mdf")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Tienda> Tienda { get; set; }
    }
}
