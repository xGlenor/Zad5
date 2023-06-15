using Microsoft.EntityFrameworkCore;
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


namespace Zad5.View
{
	/// <summary>
	/// Logika interakcji dla klasy Kategorie.xaml
	/// </summary>
	public partial class Kategorie : TabItem
	{
		private readonly SklepContext sklepContext;

		private CollectionViewSource CategoryViewSource;
		public Kategorie()
		{
			InitializeComponent();

			sklepContext = App.GetShopContext();

			CategoryViewSource = (CollectionViewSource)FindResource(nameof(CategoryViewSource));
		}

		private void Category_Loaded(object sender, RoutedEventArgs e)
		{
			sklepContext.KategoriaProduktu.Load();
			CategoryViewSource.Source = sklepContext.KategoriaProduktu.Local.ToObservableCollection();
		}

		private void btn_CategorySave_Click(object sender, RoutedEventArgs e)
		{
			sklepContext.SaveChanges();
		}
		private void btnAddCategory_Click(object sender, RoutedEventArgs e)
		{
			if (tbox_AddCategory.Text != string.Empty)
			{
				sklepContext.KategoriaProduktu.Add(new ProduktKategoria() { Name = tbox_AddCategory.Text });
				tbox_AddCategory.Text = string.Empty;

				sklepContext.SaveChanges();
				listView.Items.Refresh();
			}
		}

		private void btn_CategoryDelete_Click(object sender, RoutedEventArgs e)
		{
			sklepContext.Remove(sklepContext.KategoriaProduktu.Single(kp => kp.ProduktKategoriaId == int.Parse(tbox_CategoryID.Text)));
			sklepContext.SaveChanges();
			listView.Items.Refresh();
		}
	}
}
