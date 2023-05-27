using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad5.Model
{
	public class PozycjeZamowienia
	{
		[Key]
		public int PozycjeZamowieniaId { get; set; }

		[ForeignKey("Zamowienia")]
		public int ZamowienieID { get; set; }
		[ForeignKey("Produkt")]
		public int ProduktID { get; set; }
		public int Ilosc { get; set; }
		public double CenaJednostokwa { get; set; }
		public double Znizka { get; set; }
		public double WartoscNetto { get; set; }
		public double WartoscBrutto
		{
			get
			{
				double kwota = (1+ (Produkt.VAT / 100)) * WartoscNetto;
				if (Znizka > 0) kwota = (1 - (Znizka / 100)) * kwota;

				return kwota;
			}
			set { WartoscBrutto = value; }
		}
		//wyliczana właściwość określająca kwotę wraz z Podatkiem VAT i z uwzględnieniem zniżki

		public Zamowienia Zamowienie { get; set; }
		public Produkt Produkt { get; set; }
	}
}
