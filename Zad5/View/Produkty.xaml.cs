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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zad5.Model;
using static Azure.Core.HttpHeader;

namespace Zad5.View
{
	/// <summary>
	/// Logika interakcji dla klasy Produkty.xaml
	/// </summary>
	public partial class Produkty : TabItem
	{
		private readonly SklepContext sklepContext;

		private CollectionViewSource ProductViewSource;
		private CollectionViewSource CategoryViewSource;

		public Produkty()
		{
			InitializeComponent();

			sklepContext = App.GetShopContext();

			ProductViewSource = (CollectionViewSource)FindResource(nameof(ProductViewSource));
			CategoryViewSource = (CollectionViewSource)FindResource(nameof(CategoryViewSource));

		}
		private void Product_Loaded(object sender, RoutedEventArgs e)
		{
			sklepContext.KategoriaProduktu.Load();
			sklepContext.Produkty.Load();

			ProductViewSource.Source = sklepContext.Produkty.Local.ToObservableCollection();
			CategoryViewSource.Source = sklepContext.KategoriaProduktu.Local.ToObservableCollection();
		}
	}

}
