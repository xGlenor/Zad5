using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Zad5.Model;

namespace Zad5.View
{
	/// <summary>
	/// Logika interakcji dla klasy Zamowienia.xaml
	/// </summary>
	public partial class Zamowienia : TabItem
	{
		private readonly SklepContext sklepContext;

		private CollectionViewSource OrderSource;
		private CollectionViewSource ClientsSource;
		public Zamowienia()
		{
			InitializeComponent();

			sklepContext = App.GetShopContext();

			OrderSource = (CollectionViewSource)FindResource(nameof(OrderSource));
			ClientsSource = (CollectionViewSource)FindResource(nameof(ClientsSource));
		}
		private void Order_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			sklepContext.Zamowienia.Load();
			sklepContext.Klienci.Load();

			OrderSource.Source = sklepContext.Zamowienia.Local.ToObservableCollection();
			ClientsSource.Source = sklepContext.Klienci.Local.ToObservableCollection();
		}
		private void btnAddOrder_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if(cbox_AddOrdder.SelectedItem != null)
			{
				Klient k1 = (Klient)cbox_AddOrdder.SelectedItem;

				Model.Zamowienia zamowienie = new Model.Zamowienia()
				{
					Klient = k1,
					DataRozpoczecia = DateTime.Now,
					StatusZamowienia = StatusZamowienia.Rozpoczete
				};

				sklepContext.Zamowienia.Add(zamowienie);
				listView.Items.Refresh();
			}
		}

		private void btnDeleteOrder_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (listView.SelectedItem != null)
			{
				Model.Zamowienia zamowienie = (Model.Zamowienia)listView.SelectedItem;

				sklepContext.Zamowienia.Remove(zamowienie);
				sklepContext.SaveChanges();
				listView.Items.Refresh();
			}

		}

		private void btnFinishOrder_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (listView.SelectedItem != null)
			{
				Model.Zamowienia zamowienie = (Model.Zamowienia)listView.SelectedItem;

				zamowienie.StatusZamowienia = StatusZamowienia.Zakoczone;

				sklepContext.Zamowienia.Update(zamowienie);
				sklepContext.SaveChanges();
				listView.Items.Refresh();
			}
		}

		private void btn_OrderSave_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			sklepContext.SaveChanges();
        }
    }
}
