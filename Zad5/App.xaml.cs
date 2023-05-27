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
/*
			var k1 = new ProduktKategoria() { Name = "Warzywa" };
			var k2 = new ProduktKategoria() { Name = "Owoce" };
			var k3 = new ProduktKategoria() { Name = "Pieczywo" };
			var k4 = new ProduktKategoria() { Name = "Nabiał" };


			SklepContext.KategoriaProduktu.AddRange(k1, k2, k3, k4);

			var p1 = new Produkt() { ProduktKategoria = k1, Nazwa = "Marchew", IloscNaStanie = 1, CenaJednostkowa = 12.99 };
			var p2 = new Produkt() { ProduktKategoria = k3, Nazwa = "Chleb", IloscNaStanie = 20, CenaJednostkowa = 5.99 };

			SklepContext.Produkty.AddRange(p1, p2);

			var kl1 = new Klient() { Nazwa = "Grzegorz Duraj", Adres = "ul. Przykladowa 11 Bielsko-Biała", NIP = 0000000001 };

			SklepContext.Klienci.Add(kl1);

			SklepContext.SaveChanges();*/

		}

		public static SklepContext GetShopContext() => SklepContext;


	}
}
