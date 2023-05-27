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

namespace Zad5.View
{
	/// <summary>
	/// Logika interakcji dla klasy Produkty.xaml
	/// </summary>
	public partial class Produkty : TabItem
	{
		private readonly SklepContext sklepContext;

		public Produkty()
		{
			InitializeComponent();

			sklepContext = App.GetShopContext();

			listView.ItemsSource = sklepContext.Produkty.ToList();
		}
	}
}
