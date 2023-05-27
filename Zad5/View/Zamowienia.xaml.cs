using System.Linq;
using System.Windows.Controls;
using Zad5.Model;

namespace Zad5.View
{
	/// <summary>
	/// Logika interakcji dla klasy Zamowienia.xaml
	/// </summary>
	public partial class Zamowienia : TabItem
	{
		private readonly SklepContext sklepContext;
		public Zamowienia()
		{
			InitializeComponent();

			sklepContext = App.GetShopContext();

			dataGrid.ItemsSource = sklepContext.Zamowienia.ToList();
		}
	}
}
