using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Zad5.Model;

namespace Zad5
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static SklepContext? SklepContext;

        public App()
        {
			SklepContext = new SklepContext();

			if (SklepContext.Database.EnsureCreated())
			{
				var k1 = new ProduktKategoria() { Name = "Warzywa" };
				var k2 = new ProduktKategoria() { Name = "Owoce" };
				var k3 = new ProduktKategoria() { Name = "Pieczywo" };
				var k4 = new ProduktKategoria() { Name = "Nabiał" };


				SklepContext.KategoriaProduktu.AddRange(k1, k2, k3, k4);

				var p1 = new Produkt() { ProduktKategoria = k1, Nazwa = "Marchew", IloscNaStanie = 1, CenaJednostkowa = 12.99 };
				var p2 = new Produkt() { ProduktKategoria = k3, Nazwa = "Chleb", IloscNaStanie = 20, CenaJednostkowa = 5.99 };
				var p3 = new Produkt() { ProduktKategoria = k3, Nazwa = "Bułeczka", IloscNaStanie = 20, CenaJednostkowa = 0.40 };

				SklepContext.Produkty.AddRange(p1, p2, p3);

				var kl1 = new Klient() { Nazwa = "Grzegorz Duraj", Adres = "ul. Przykladowa 11 Bielsko-Biała", NIP = 0000000001 };
				var kl2 = new Klient() { Nazwa = "Jan Kowalski", Adres = "ul. Przykladowa 11 Bielsko-Biała", NIP = 0000000002 };

				SklepContext.Klienci.AddRange(kl1, kl2);

				var z1 = new Zamowienia() { Klient = kl1, StatusZamowienia = StatusZamowienia.Rozpoczete, DataRozpoczecia = DateTime.Now };
				var z2 = new Zamowienia() { Klient = kl2, StatusZamowienia = StatusZamowienia.WRealizacji, DataRozpoczecia = DateTime.Now.AddDays(2) };
				var z3 = new Zamowienia() { Klient = kl1, StatusZamowienia = StatusZamowienia.Zakoczone, DataRozpoczecia = DateTime.Now.AddDays(10) };

				SklepContext.Zamowienia.AddRange(z1, z2, z3);

				SklepContext.SaveChanges();
			}

		}

		public static SklepContext GetShopContext() => SklepContext;


	}
}
