using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Zad5.Model
{
	public class SklepContext : DbContext
	{

		public DbSet<Klient> Klienci { get; set; }
		public DbSet<Zamowienia> Zamowienia { get; set; }
		public DbSet<PozycjeZamowienia> PozycjeZamowienia { get; set; }
		public DbSet<Produkt> Produkty { get; set; }
		public DbSet<ProduktKategoria> KategoriaProduktu { get; set; }


		public SklepContext(DbContextOptions options) : base(options)
		{


		}

		public SklepContext()
		{
		}

		/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer(@"Data Source=GRZES; Initial Catalog = ShopDatabase; Integrated Security=True;Encrypt=False;TrustServerCertificate=False;");
		*/

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseInMemoryDatabase("@Sklep");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
				
		}
	}
}
