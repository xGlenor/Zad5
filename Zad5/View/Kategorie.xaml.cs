using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Zad5.Core;
using Zad5.Model;
using Zad5.ViewModel;

namespace Zad5.View
{
	/// <summary>
	/// Logika interakcji dla klasy Kategorie.xaml
	/// </summary>
	public partial class Kategorie : TabItem
	{
		private readonly SklepContext sklepContext;
		public Kategorie()
		{
			InitializeComponent();

			sklepContext = App.GetShopContext();

			//listView.ItemsSource = sklepContext.KategoriaProduktu.ToList();

			DataContext = new KategorieViewModel();

		}

		private void btnAddCategory_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
