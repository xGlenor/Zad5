using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Zad5.Model
{
	public class Zamowienia
	{
		[Key]
		public int ZamowienieId { get; set; }
		public DateTime DataRozpoczecia { get; set; }
		public DateTime? DataZakonczenia { get; set; }
		public StatusZamowienia StatusZamowienia { get; set; }
		public virtual ICollection<PozycjeZamowienia> SzczegolyZamowienia { get; set; } = new List<PozycjeZamowienia>();
		public double KwotaZamowienia => SzczegolyZamowienia.Sum(p => p.WartoscBrutto);

		[ForeignKey("Klient")]
		public int KlientID { get; set; }
		public Klient Klient { get; set; }

	}
}
