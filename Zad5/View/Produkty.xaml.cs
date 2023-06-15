using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		private CollectionViewSource ProductSource;
		private CollectionViewSource CategoryListSource;

		public Produkty()
		{
			InitializeComponent();

			sklepContext = App.GetShopContext();

			ProductSource = (CollectionViewSource)FindResource(nameof(ProductSource));
			CategoryListSource = (CollectionViewSource)FindResource(nameof(CategoryListSource));

		}
		private void Product_Loaded(object sender, RoutedEventArgs e)
		{
			sklepContext.KategoriaProduktu.Load();
			sklepContext.Produkty.Load();

			ProductSource.Source = sklepContext.Produkty.Local.ToObservableCollection();
			CategoryListSource.Source = sklepContext.KategoriaProduktu.Select(c => c.Name).ToList();
		}

		private void btnAddProduct_Click(object sender, RoutedEventArgs e)
		{
			AddProduct addProduct = new AddProduct();
			addProduct.Show();

		}
	
		private void btn_ProductDelete_Click(object sender, RoutedEventArgs e)
		{
			sklepContext.Remove(sklepContext.Produkty.Single(p => p.ProduktId == int.Parse(tbox_EditProductID.Text)));
			sklepContext.SaveChanges();
			listView.Items.Refresh();
		}
	}


}
