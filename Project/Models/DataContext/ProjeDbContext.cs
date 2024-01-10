using Project.Models.Data;
using System.Data.Entity;

namespace Project.Models.DataContext
{
	public class ProjeDbContext : DbContext
	{
        public ProjeDbContext():base("ProjeDb")
        {
            
        }
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<Kitap> Kitaps { get; set; }
    }
}