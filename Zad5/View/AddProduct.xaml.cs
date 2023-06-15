using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zad5.Model;

namespace Zad5.View
{
	/// <summary>
	/// Logika interakcji dla klasy AddProduct.xaml
	/// </summary>
	public partial class AddProduct : Window
	{
		private readonly SklepContext sklepContext;

		private CollectionViewSource CategoryListSource;

		public AddProduct()
		{
			InitializeComponent();

			sklepContext = App.GetShopContext();

			CategoryListSource = (CollectionViewSource)FindResource(nameof(CategoryListSource));

		}

		private void AddProduct_Loaded(object sender, RoutedEventArgs e)
		{
			sklepContext.KategoriaProduktu.Load();
			CategoryListSource.Source = sklepContext.KategoriaProduktu.Local.ToObservableCollection();
		}

		private void AddCategory_Click(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(NameProduct.Text))
			{
				Produkt produkt = new Produkt()
				{
					Nazwa = NameProduct.Text,
					CenaJednostkowa = double.Parse(CenaProduct.Text),
					IloscNaStanie = int.Parse(IloscProduct.Text),
					ProduktKategoria = (ProduktKategoria)CategoryProduct.SelectedValue
				};

				sklepContext.Add(produkt);
				sklepContext.SaveChanges();
				Close();
				
			}
		}
	}
}
